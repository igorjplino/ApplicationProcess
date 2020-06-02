using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Interfaces.Service
{
    public interface IBaseService<TEntity> : IDisposable where TEntity : class
    {
        bool Any(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Update(TEntity obj, params object[] key);
        void Insert(TEntity obj);
        void Remove(TEntity obj);
        void SaveChanges();
    }
}
