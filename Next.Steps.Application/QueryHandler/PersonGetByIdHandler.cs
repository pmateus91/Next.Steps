using AutoMapper;
using MediatR;
using Next.Steps.Application.Dtos;
using Next.Steps.Application.Query;
using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Steps.Application.QueryHandler
{
    public class PersonGetByIdHandler : RequestHandler<PersonGetByIdQuery>
    {
        private readonly IServicePerson _servicePerson;
        private readonly IMapper _mapper;

        public PersonGetByIdHandler(IServicePerson servicePerson, IMapper mapper)
        {
            _servicePerson = servicePerson;
            _mapper = mapper;
        }

        protected override void Handle(PersonGetByIdQuery request)
        {
            var person = _mapper.Map<PersonReadDto, Person>(request.Id);
            _servicePerson.GetById(request.Id);
        }
    }
}