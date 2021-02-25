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
        private readonly NextStepsContext _nextStepsContext;

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
            try
            {
                _nextStepsContext.Set<TEntity>().Add(obj);
                _nextStepsContext.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool Update(TEntity obj)
        {
            try
            {
                _nextStepsContext.Entry(obj).State = EntityState.Modified;
                _nextStepsContext.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool Remove(TEntity obj)
        {
            try
            {
                _nextStepsContext.Set<TEntity>().Remove(obj);
                _nextStepsContext.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //public bool Remove(int id)
        //{
        //    try
        //    {
        //        var person = _nextStepsContext.Persons.Where(p => p.Id == id).Include(p => p.Hobbies).FirstOrDefault();
        //        _nextStepsContext.Persons.Remove(person);
        //        _nextStepsContext.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //}
    }
}