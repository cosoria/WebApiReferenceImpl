using System.Threading;

namespace WebApiReferenceImpl.Core.Threading
{
    public class WriteLock : BaseLock
    {
        public WriteLock(ReaderWriterLockSlim lockObject) : base(lockObject)
        {
            Locks.GetWriteLock(_lockObject);
        }

        public override void Dispose()
        {
            Locks.ReleaseWriteLock(_lockObject);
        }
    }
}