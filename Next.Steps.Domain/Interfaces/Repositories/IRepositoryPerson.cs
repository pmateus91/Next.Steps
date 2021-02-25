using Next.Steps.Domain.Entities;
using System.Collections.Generic;

namespace Next.Steps.Domain.Interfaces.Repositories
{
    public interface IRepositoryPerson : IRepositoryBase<Person>
    {
        IEnumerable<Person> Search(string firstname, string lastname);
    }
}