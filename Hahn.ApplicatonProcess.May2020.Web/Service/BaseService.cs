using Hahn.ApplicatonProcess.May2020.Data.Repositories;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces.Repository;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Web.Service
{
    public class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepositor)
        {
            _baseRepository = baseRepositor;
        }

        public bool Any(Func<TEntity, bool> predicate)
        {
            return _baseRepository.Any(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _baseRepository.Get(predicate);
        }

        public void Insert(TEntity obj)
        {
            _baseRepository.Insert(obj);
        }

        public void Remove(TEntity obj)
        {
            _baseRepository.Remove(obj);
        }

        public void SaveChanges()
        {
            _baseRepository.SaveChanges();
        }

        public void Update(TEntity obj, params object[] key)
        {
            _baseRepository.Update(obj, key);
        }

        public void Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}
