namespace Microsoft.IO.UnitTests
{
    using System;
    using System.Buffers;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.IO;
    using NUnit.Framework;

    public abstract class BaseRecyclableMemoryStreamTests
    {
        protected const int DefaultBlockSize = 16384;
        protected const int DefaultLargeBufferMultiple = 1 << 20;
        protected const int DefaultMaximumBufferSize = 8 * (1 << 20);
        protected const string DefaultTag = "NUnit";
        private const int MemoryStreamDisposed = 2;
        private const int MemoryStreamDoubleDispose = 3;

        private readonly Random random = new Random();

        #region RecyclableMemoryManager Tests

        public virtual void RecyclableMemoryManagerUsingMultipleOrExponentialLargeBuffer()
        {
            var memMgr = this
        }


        #endregion

        #region Test Helpers


        protected virtual RecyclableMemoryStreamManager GetMemoryManager()
        {
            return new RecyclableMemoryStreamManager()
        }
        #endregion
    }

    [TestFixture]
    public sealed class RecyclableMemoryStreamTestsWithPassiveBufferRelease
    {

        

        [Test]
        public void OldBuffersAreKeptInStreamUntilDispose()
        {
            
        }
    }
}
