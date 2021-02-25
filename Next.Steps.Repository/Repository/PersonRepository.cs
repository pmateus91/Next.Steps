using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Repositories;
using Next.Steps.Infrastructure.Context;
using System.Collections.Generic;

namespace Next.Steps.Infrastructure.Repository
{
    public class PersonRepository : BaseRepository<Person>, IRepositoryPerson
    {
        private readonly NextStepsContext _nextStepsContext;

        public PersonRepository(NextStepsContext _nextStepsContext) : base(_nextStepsContext)
        {
            this._nextStepsContext = _nextStepsContext;
        }

        public IEnumerable<Person> Search(string firstname, string lastname)

        {
            return (IEnumerable<Person>)_nextStepsContext.Set<Person>().Find(firstname, lastname);
        }
    }
}