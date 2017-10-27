using System;
using System.Threading;

namespace WebApiReferenceImpl.Core.Threading
{
    public abstract class BaseLock : IDisposable 
    {
        protected readonly ReaderWriterLockSlim _lockObject;

        protected BaseLock(ReaderWriterLockSlim lockObject)
        {
            Ensure.Argument.NotNull(lockObject);
            _lockObject = lockObject;
        }

        public abstract void Dispose();
    }
}