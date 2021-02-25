using System.Collections.Generic;

namespace Next.Steps.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        bool Add(TEntity obj);

        bool Update(TEntity obj);

        bool Remove(TEntity obj);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);
    }
}