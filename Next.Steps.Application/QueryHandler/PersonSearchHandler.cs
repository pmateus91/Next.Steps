using AutoMapper;
using MediatR;
using Next.Steps.Application.Dtos;
using Next.Steps.Application.Query;
using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Next.Steps.Application.QueryHandler
{
    public class PersonSearchHandler : RequestHandler<PersonSearchQuery, IEnumerable<PersonReadDto>>
    {
        private readonly IServicePerson _servicePerson;
        private readonly IMapper _mapper;

        public PersonSearchHandler(IServicePerson servicePerson, IMapper mapper)
        {
            _servicePerson = servicePerson;
            _mapper = mapper;
        }

        protected override IEnumerable<PersonReadDto> Handle(PersonSearchQuery request)
        {
            var person = _servicePerson.Search(request.Firstname, request.Lastname);

            if (person != null)
            {
                return _mapper.Map<IEnumerable<Person>, IEnumerable<PersonReadDto>>(person);
            }
            else
            {
                return null;
            }
        }
    }
}