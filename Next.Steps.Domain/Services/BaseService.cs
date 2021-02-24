using Next.Steps.Domain.Interfaces.Repositories;
using Next.Steps.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Next.Steps.Domain.Services
{
    public class BaseService<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private IRepositoryBase<TEntity> _repo;

        public BaseService(IRepositoryBase<TEntity> repo)
        {
            _repo = repo;
        }

        public bool Add(TEntity obj)
        {
            if (obj != null)
            {
                _repo.Add(obj);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repo.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repo.GetById(id);
        }

        public bool Remove(int id)
        {
            if (id > 0)
            {
                _repo.Remove(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(TEntity obj)
        {
            if (obj != null)
            {
                _repo.Update(obj);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<TEntity> Search(string firstname, string lastname)
        {
            if (firstname == "" || lastname == "")
            {
                return null;
            }
            else
            {
                return _repo.Search(firstname, lastname);
            }
        }
    }
}