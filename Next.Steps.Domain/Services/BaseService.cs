using Next.Steps.Domain.Interfaces.Repositories;
using Next.Steps.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Next.Steps.Domain.Services
{
    public class BaseService<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repo;

        public BaseService(IRepositoryBase<TEntity> repo)
        {
            _repo = repo;
        }

        public bool Add(TEntity obj)
        {
            _repo.Add(obj);
            return true;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repo.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repo.GetById(id);
        }

        public bool Remove(TEntity obj)
        {
            _repo.Remove(obj);
            return true;
        }

        public bool Update(TEntity obj)
        {
            _repo.Update(obj);
            return true;
        }
    }
}