using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApiReferenceImpl.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class, IEntity
    {
        TEntity Get(object key);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllMatching(Expression<Func<TEntity, bool>> filter);
        void Add(TEntity entry);
        void Delete(object key);
        void Update(TEntity entry);
    }

    public interface IRepository<TEntity, in TKey> : IDisposable where TEntity : class, IEntity
    {
        TEntity Get(TKey key);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllMatching(Expression<Func<TEntity, bool>> filter);
        void Add(TKey key, TEntity entry);
        void Delete(TKey key);
        void Update(TKey key, TEntity entry);
    }
}