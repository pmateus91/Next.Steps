using AutoMapper;
using MediatR;
using Next.Steps.Application.Command;
using Next.Steps.Application.Dtos;
using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Services;

namespace Next.Steps.Application.CommandHandler
{
    public class PersonAddHandler : RequestHandler<PersonAddCommand>
    {
        private readonly IServicePerson _servicePerson;
        private readonly IMapper _mapper;

        public PersonAddHandler(IServicePerson personService, IMapper mapper)
        {
            _servicePerson = personService;
            _mapper = mapper;
        }

        protected override void Handle(PersonAddCommand request)
        {
            var person = _mapper.Map<PersonWriteDto, Person>(request.Person);
            _servicePerson.Add(person);
        }
    }
}