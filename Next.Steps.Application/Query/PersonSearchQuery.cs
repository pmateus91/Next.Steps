using MediatR;
using Next.Steps.Application.Dtos;
using System.Collections.Generic;

namespace Next.Steps.Application.Query
{
    public class PersonSearchQuery : IRequest<IEnumerable<PersonReadDto>>
    {
        public string Firstname;

        public string Lastname;
    }
}