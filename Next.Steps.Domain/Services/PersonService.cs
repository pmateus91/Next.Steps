using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Repositories;
using Next.Steps.Domain.Interfaces.Services;

namespace Next.Steps.Domain.Services
{
    public class PersonService : BaseService<Person>, IServicePerson
    {
        private IRepositoryPerson _repo;

        public PersonService(IRepositoryPerson repo) : base(repo)
        {
            _repo = repo;
        }
    }
}