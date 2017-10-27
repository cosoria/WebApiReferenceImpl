using System;
using System.Threading;

namespace Rigel.Core
{
    public abstract class Disposable : IDisposable
    {
        private int _disposed;

        protected Disposable()
        {
            _disposed = 0;
        }

        public bool IsDisposed
        {
            get { return _disposed == 1; }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Interlocked.CompareExchange(ref _disposed, 1, 0) != 0)
            {
                return;
            }
            
            if (disposing)
            {
                DisposeManagedResources();
            }

            DisposeUnmanagedResources();
        }

        protected void ThrowExceptionIfDisposed()
        {
            if (_disposed == 1)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }

        protected virtual void DisposeManagedResources()
        {
        }

        protected virtual void DisposeUnmanagedResources()
        {
        }
    }
}