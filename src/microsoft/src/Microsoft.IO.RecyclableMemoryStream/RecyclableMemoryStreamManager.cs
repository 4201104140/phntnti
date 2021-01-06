

namespace Microsoft.IO
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// Manages pools of RecyclableMemoryStream objects.
    /// </summary>
    /// <remarks>
    /// There are two pools managed in here. The small pool contains same-sized buffers that are handed to streams
    /// as they write more data.
    ///
    /// For scenarios that need to call GetBuffer(), the large pool contains buffers of various sizes, all
    /// multiples/exponentials of LargeBufferMultiple (1 MB by default). They are split by size to avoid overly-wasteful buffer
    /// usage. There should be far fewer 8 MB buffers than 1 MB buffers, for example.
    /// </remarks>
    public partial class RecyclableMemoryStreamManager
    {
        /// <summary>
        /// Generic delegate for handling events without any arguments.
        /// </summary>
        public delegate void EventHandler();

        /// <summary>
        /// Delegate for handling large buffer discard reports.
        /// </summary>
        /// <param name="reason">Reason the buffer was discarded.</param>
        public delegate void LargeBufferDiscardedEventHandler(Events.MemoryStreamDiscardReason reason);

        /// <summary>
        /// Delegate for handling reports of stream size when streams are allocated
        /// </summary>
        /// <param name="bytes">Bytes allocated.</param>
        public delegate void StreamLengthReportHandler(long bytes);

        /// <summary>
        /// Delegate for handling periodic reporting of memory use statistics.
        /// </summary>
        /// <param name="smallPoolInUseBytes">Bytes currently in use in the small pool.</param>
        /// <param name="smallPoolFreeBytes">Bytes currently free in the small pool.</param>
        /// <param name="largePoolInUseBytes">Bytes currently in use in the large pool.</param>
        /// <param name="largePoolFreeBytes">Bytes currently free in the large pool.</param>
        public delegate void UsageReportEventHandler(
            long smallPoolInUseBytes, long smallPoolFreeBytes, long largePoolInUseBytes, long largePoolFreeBytes);

        /// <summary>
        /// Default block size, in bytes
        /// </summary>
        public const int DefaultBlockSize = 128 * 1024;
        /// <summary>
        /// Default large buffer multiple, in bytes
        /// </summary>
        public const int DefaultLargeBufferMultiple = 1024 * 1024;
        /// <summary>
        /// Default maximum buffer size, in bytes
        /// </summary>
        public const int DefaultMaximumBufferSize = 128 * 1024 * 1024;

        private readonly long[] largeBufferFreeSize;
        private readonly long[] largeBufferInUseSize;


        private readonly ConcurrentStack<byte[]>[] largePools;

        private readonly ConcurrentStack<byte[]> smallPool;

        private long smallPoolFreeSize;
        private long smallPoolInUseSize;

        /// <summary>
        /// Initializes the memory manager with the given block requiredSize.
        /// </summary>
        /// <param name="blockSize">Size of each block that is pooled. Must be > 0.</param>
        /// <param name="largeBufferMultiple">Each large buffer will be a multiple/exponential of this value.</param>
        /// <param name="maximumBufferSize">Buffers larger than this are not pooled</param>
        /// <param name="useExponentialLargeBuffer">Switch to exponential large buffer allocation strategy</param>
        /// <exception cref="ArgumentOutOfRangeException">blockSize is not a positive number, or largeBufferMultiple is not a positive number, or maximumBufferSize is less than blockSize.</exception>
        /// <exception cref="ArgumentException">maximumBufferSize is not a multiple/exponential of largeBufferMultiple</exception>
        public RecyclableMemoryStreamManager(int blockSize, int largeBufferMultiple, int maximumBufferSize, bool useExponentialLargeBuffer)
        {
            if (blockSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(blockSize), blockSize, "blockSize must be a positive number");
            }

            if (largeBufferMultiple <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(largeBufferMultiple),
                                                      "largeBufferMultiple must be a positive number");
            }

            if (maximumBufferSize < blockSize)
            {
                throw new ArgumentOutOfRangeException(nameof(maximumBufferSize),
                                                      "maximumBufferSize must be at least blockSize");
            }

            this.BlockSize = blockSize;
            this.LargeBufferMultiple = largeBufferMultiple;
            this.MaximumBufferSize = maximumBufferSize;
            this.UseExponentialLargeBuffer = useExponentialLargeBuffer;

            if (!this.IsLargeBufferSize(maximumBufferSize))
            {
                throw new ArgumentException(String.Format("maximumBufferSize is not {0} of largeBufferMultiple",
                                                          this.UseExponentialLargeBuffer ? "an exponential" : "a multiple"),
                                            nameof(maximumBufferSize));
            }

            this.smallPool = new ConcurrentStack<byte[]>();
            var numLargePools = useExponentialLargeBuffer
                                    ? ((int)Math.Log(maximumBufferSize / largeBufferMultiple, 2) + 1)
                                    : (maximumBufferSize / largeBufferMultiple);

            // +1 to store size of bytes in use that are too large to be pooled
            this.largeBufferInUseSize = new long[numLargePools + 1];
            this.largeBufferFreeSize = new long[numLargePools];

            this.largePools = new ConcurrentStack<byte[]>[numLargePools];

            for (var i = 0; i < this.largePools.Length; ++i)
            {
                this.largePools[i] = new ConcurrentStack<byte[]>();
            }

            Events.Writer.MemoryStreamManagerInitialized(blockSize, largeBufferMultiple, maximumBufferSize);
        }

        /// <summary>
        /// The size of each block. It must be set at creation and cannot be changed.
        /// </summary>
        public int BlockSize { get; }

        /// <summary>
        /// All buffers are multiples/exponentials of this number. It must be set at creation and cannot be changed.
        /// </summary>
        public int LargeBufferMultiple { get; }

        /// <summary>
        /// Use multiple large buffer allocation strategy. It must be set at creation and cannot be changed.
        /// </summary>
        public bool UseMultipleLargeBuffer => !this.UseExponentialLargeBuffer;

        /// <summary>
        /// Use exponential large buffer allocation strategy. It must be set at creation and cannot be changed.
        /// </summary>
        public bool UseExponentialLargeBuffer { get; }

        /// <summary>
        /// Gets the maximum buffer size.
        /// </summary>
        /// <remarks>Any buffer that is returned to the pool that is larger than this will be
        /// discarded and garbage collected.</remarks>
        public int MaximumBufferSize { get; }


        /// <summary>
        /// Maximum stream capacity in bytes. Attempts to set a larger capacity will
        /// result in an exception.
        /// </summary>
        /// <remarks>A value of 0 indicates no limit.</remarks>
        public long MaximumStreamCapacity { get; set; }

        /// <summary>
        /// Whether to save callstacks for stream allocations. This can help in debugging.
        /// It should NEVER be turned on generally in production.
        /// </summary>
        public bool GenerateCallStacks { get; set; }


        internal byte[] GetLargeBuffer(int requiredSize, string tag)
        {
            requiredSize = this.RoundToLargeBufferSize(requiredSize);

            var poolIndex = this.GetPoolIndex(requiredSize);

            byte[] buffer;
            if (poolIndex < this.largePools.Length)
            {
                if (!this.largePools[poolIndex].TryPop(out buffer))
                {
                    buffer = new byte[requiredSize];

                    Events.Writer.MemoryStreamNewLargeBufferCreated(requiredSize, this.LargeBufferMultiple);
                }
                else
                {
                    Interlocked.Add(ref this.largeBufferFreeSize[poolIndex], -buffer.Length);
                }
            }
            else
            {
                poolIndex = this.largeBufferInUseSize.Length - 1;

                buffer = new byte[requiredSize];
                string callStack = null;
                if (this.GenerateCallStacks)
                {
                    callback = Environment.StackTrace;
                }
                Events.Writer.MemoryStreamNonPooledLargeBufferCreated(requiredSize, tag, callStack);
                
            }
        }

        private int RoundToLargeBufferSize(int requiredSize)
        {
            if (this.UseExponentialLargeBuffer)
            {
                int pow = 1;
                while (this.LargeBufferMultiple * pow < requiredSize)
                {
                    pow <<= 1;
                }
                return this.LargeBufferMultiple * pow;
            }
            else
            {
                return ((requiredSize + this.LargeBufferMultiple - 1) / this.LargeBufferMultiple) * this.LargeBufferMultiple;
            }
        }

        private bool IsLargeBufferSize(int value)
        {
            return (value != 0) && (this.UseExponentialLargeBuffer
                                        ? (value == RoundToLargeBufferSize(value))
                                        : (value % this.LargeBufferMultiple) == 0);
        }

        private int GetPoolIndex(int length)
        {
            if (this.UseExponentialLargeBuffer)
            {
                int index = 0;
                while ((this.LargeBufferMultiple << index) < length)
                {
                    ++index;
                }
                return index;
            }
            else
            {
                return length / this.LargeBufferMultiple - 1;
            }
        }

        internal void ReportLargeBufferCreated()
        {
            this.LargeBufferCreated
        }
    }
}
