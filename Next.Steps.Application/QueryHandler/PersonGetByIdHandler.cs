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
    public class PersonGetByIdHandler : RequestHandler<PersonGetByIdQuery, PersonReadDto>
    {
        private readonly IServicePerson _servicePerson;
        private readonly IMapper _mapper;

        public PersonGetByIdHandler(IServicePerson servicePerson, IMapper mapper)
        {
            _servicePerson = servicePerson;
            _mapper = mapper;
        }

        protected override PersonReadDto Handle(PersonGetByIdQuery request)
        {
            var person = _servicePerson.GetById(request.Id);
            if (person != null)
            {
                return _mapper.Map<Person, PersonReadDto>(person);
            }
            else
            {
                return null;
            }
        }
    }
}