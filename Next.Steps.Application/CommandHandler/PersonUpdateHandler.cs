using AutoMapper;
using MediatR;
using Next.Steps.Application.Command;
using Next.Steps.Application.Dtos;
using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Services;

namespace Next.Steps.Application.CommandHandler
{
    public class PersonUpdateHandler : RequestHandler<PersonUpdateCommand>
    {
        private readonly IServicePerson _servicePerson;
        private readonly IMapper _mapper;

        public PersonUpdateHandler(IServicePerson servicePerson, IMapper mapper)
        {
            _servicePerson = servicePerson;
            _mapper = mapper;
        }

        protected override void Handle(PersonUpdateCommand request)
        {
            var person = _mapper.Map<PersonUpdateDto, Person>(request.Person);
            _servicePerson.Update(person);
        }
    }
}