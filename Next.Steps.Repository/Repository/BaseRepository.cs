using Microsoft.EntityFrameworkCore;
using Next.Steps.Domain.Interfaces.Repositories;
using Next.Steps.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Next.Steps.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected NextStepsContext _nextStepsContext;

        public BaseRepository(NextStepsContext nextStepsContext)
        {
            this._nextStepsContext = nextStepsContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _nextStepsContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _nextStepsContext.Set<TEntity>().Find(id);
        }

        public bool Add(TEntity obj)
        {
            _nextStepsContext.Set<TEntity>().Add(obj);
            _nextStepsContext.SaveChanges();
            return true;
        }

        public bool Update(TEntity obj)
        {
            _nextStepsContext.Entry(obj).State = EntityState.Modified;
            _nextStepsContext.SaveChanges();
            return true;
        }

        public bool Remove(TEntity obj)
        {
            _nextStepsContext.Set<TEntity>().Remove(obj);
            _nextStepsContext.SaveChanges();
            return true;
        }
    }
}