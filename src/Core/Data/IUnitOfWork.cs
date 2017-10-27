using System;

namespace WebApiReferenceImpl.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}