using System.Collections.Generic;

namespace Next.Steps.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        bool Add(TEntity obj);

        bool Update(TEntity obj);

        bool Remove(int id);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        IEnumerable<TEntity> Search(string firstname, string lastname);
    }
}