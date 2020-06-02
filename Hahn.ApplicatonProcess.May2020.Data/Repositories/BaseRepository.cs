using Hahn.ApplicatonProcess.May2020.Data.Context;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Data.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        protected ApplicationProcessContext context = new ApplicationProcessContext();

        public bool Any(Func<TEntity, bool> predicate)
        {
            return context.Set<TEntity>().Any(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate);
        }

        public void Update(TEntity obj, params object[] key)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Object is null.");
            }

            context.Entry(obj).State = EntityState.Modified;
            SaveChanges();
        }

        public void Insert(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Object is null.");
            }

            context.Set<TEntity>().Add(obj);
            SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Object is null.");
            }

            context.Set<TEntity>().Remove(obj);
            SaveChanges();
        }

        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException UpdEx)
            {
                //TODO: add log

                throw UpdEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
