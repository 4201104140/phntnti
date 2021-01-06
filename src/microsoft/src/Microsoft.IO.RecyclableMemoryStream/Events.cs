

namespace Microsoft.IO
{
    using System;
    using System.Diagnostics.Tracing;

    public sealed partial class RecyclableMemoryStreamManager 
    {
        /// <summary>
        /// ETW events for RecyclableMemoryStream
        /// </summary>
        [EventSource(Name = "Microsoft-IO-RecyclableMemoryStream", Guid = "{B80CD4E4-890E-468D-9CBA-90EB7C82DFC7}")]
        public sealed class Events : EventSource
        {
            /// <summary>
            /// Static log object, through which all events are written.
            /// </summary>
            public static Events Writer = new Events();

            /// <summary>
            /// Type of buffer
            /// </summary>
            public enum MemoryStreamBufferType
            {
                /// <summary>
                /// Small block buffer
                /// </summary>
                Small,
                /// <summary>
                /// Large pool buffer
                /// </summary>
                Large
            }

            /// <summary>
            /// The possible reasons for discarding a buffer
            /// </summary>
            public enum MemoryStreamDiscardReason
            {
                /// <summary>
                /// Buffer was too large to be re-pooled
                /// </summary>
                TooLarge,
                /// <summary>
                /// There are enough free bytes in the pool
                /// </summary>
                EnoughFree
            }

            /// <summary>
            /// Logged when a stream object is created.
            /// </summary>
            /// <param name="guid">A unique ID for this stream.</param>
            /// <param name="tag">A temporary ID for this stream, usually indicates current usage.</param>
            /// <param name="requestedSize">Requested size of the stream</param>
            [Event(1, Level = EventLevel.Verbose)]
            public void MemoryStreamCreated(Guid guid, string tag, int requestedSize)
            {
                if (this.IsEnabled(EventLevel.Verbose, EventKeywords.None))
                {
                    WriteEvent(1, guid, tag ?? string.Empty, requestedSize);
                }
            }

            /// <summary>
            /// Logged when the stream is disposed
            /// </summary>
            /// <param name="guid">A unique ID for this stream.</param>
            /// <param name="tag">A temporary ID for this stream, usually indicates current usage.</param>
            [Event(2, Level = EventLevel.Verbose)]
            public void MemoryStreamDisposed(Guid guid, string tag)
            {
                if (this.IsEnabled(EventLevel.Verbose, EventKeywords.None))
                {
                    WriteEvent(2, guid, tag ?? string.Empty);
                }
            }

            /// <summary>
            /// Logged when the RecyclableMemoryStreamManager is initialized.
            /// </summary>
            /// <param name="blockSize">Size of blocks, in bytes.</param>
            /// <param name="largeBufferMultiple">Size of the large buffer multiple, in bytes.</param>
            /// <param name="maximumBufferSize">Maximum buffer size, in bytes.</param>
            [Event(6, Level = EventLevel.Informational)]
            public void MemoryStreamManagerInitialized(int blockSize, int largeBufferMultiple, int maximumBufferSize)
            {
                if (this.IsEnabled())
                {
                    WriteEvent(6, blockSize, largeBufferMultiple, maximumBufferSize);
                }
            }

            /// <summary>
            /// Logged when a new large buffer is created.
            /// </summary>
            /// <param name="requiredSize">Requested size</param>
            /// <param name="largePoolInUseBytes">Number of bytes in the large pool in use.</param>
            [Event(8, Level = EventLevel.Verbose)]
            public void MemoryStreamNewLargeBufferCreated(int requiredSize, long largePoolInUseBytes)
            {
                if (this.IsEnabled(EventLevel.Verbose, EventKeywords.None))
                {
                    WriteEvent(8, requiredSize, largePoolInUseBytes);
                }
            }

            /// <summary>
            /// Logged when a buffer is created that is too large to pool.
            /// </summary>
            /// <param name="requiredSize">Size requested by the caller</param>
            /// <param name="tag">A temporary ID for this stream, usually indicates current usage.</param>
            /// <param name="allocationStack">Call stack of the requested stream.</param>
            /// <remarks>Note: Stacks will only be populated if RecyclableMemoryStreamManager.GenerateCallStacks is true.</remarks>
            [Event(9, Level = EventLevel.Verbose)]
            public void MemoryStreamNonPooledLargeBufferCreated(int requiredSize, string tag, string allocationStack)
            {
                if (this.IsEnabled(EventLevel.Verbose, EventKeywords.None))
                {
                    WriteEvent(9, requiredSize, tag ?? string.Empty, allocationStack ?? string.Empty);
                }
            }

            /// <summary>
            /// Logged when a stream grows beyond the maximum capacity.
            /// </summary>
            /// <param name="requestedCapacity">The requested capacity.</param>
            /// <param name="maxCapacity">Maximum capacity, as configured by RecyclableMemoryStreamManager.</param>
            /// <param name="tag">A temporary ID for this stream, usually indicates current usage.</param>
            /// <param name="allocationStack">Call stack for the capacity request.</param>
            /// <remarks>Note: Stacks will only be populated if RecyclableMemoryStreamManager.GenerateCallStacks is true.</remarks>
            [Event(11, Level = EventLevel.Error)]
            public void MemoryStreamOverCapacity(int requestedCapacity, long maxCapacity, string tag,
                                                 string allocationStack)
            {
                if (this.IsEnabled())
                {
                    WriteEvent(11, requestedCapacity, maxCapacity, tag ?? string.Empty, allocationStack ?? string.Empty);
                }
            }
        }
    }
}
