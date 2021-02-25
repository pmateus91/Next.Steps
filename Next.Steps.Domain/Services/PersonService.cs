using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Repositories;
using Next.Steps.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Next.Steps.Domain.Services
{
    public class PersonService : BaseService<Person>, IServicePerson
    {
        private readonly IRepositoryPerson _repo;

        public PersonService(IRepositoryPerson repo) : base(repo)
        {
            _repo = repo;
        }

        public bool Remove(int id)
        {
            return _repo.Remove(id);
        }

        public IEnumerable<Person> Search(string firstname, string lastname)
        {
            return _repo.Search(firstname, lastname);
        }
    }
}