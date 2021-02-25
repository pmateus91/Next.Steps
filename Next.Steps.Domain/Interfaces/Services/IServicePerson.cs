using Next.Steps.Domain.Entities;
using System.Collections.Generic;

namespace Next.Steps.Domain.Interfaces.Services
{
    public interface IServicePerson : IServiceBase<Person>
    {
        IEnumerable<Person> Search(string firstname, string lastname);
    }
}