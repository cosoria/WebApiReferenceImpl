using System;

namespace WebApiReferenceImpl.Core.Data
{
    public interface IDataContext : IDisposable
    {
        void Save();
    }
}