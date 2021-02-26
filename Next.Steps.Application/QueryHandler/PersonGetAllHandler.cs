using AutoMapper;
using MediatR;
using Next.Steps.Application.Dtos;
using Next.Steps.Application.Query;
using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Next.Steps.Application.QueryHandler
{
    public class PersonGetAllHandler : RequestHandler<PersonGetAllQuery, IEnumerable<PersonReadDto>>
    {
        private readonly IServicePerson _personService;
        private readonly IMapper _mapper;

        public PersonGetAllHandler(IServicePerson personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        protected override IEnumerable<PersonReadDto> Handle(PersonGetAllQuery request)
        {
            throw new System.NotImplementedException();
        }
    }
}