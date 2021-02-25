using AutoMapper;
using MediatR;
using Next.Steps.Application.Command;
using Next.Steps.Application.Dtos;
using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Services;

namespace Next.Steps.Application.CommandHandler
{
    public class PersonRemoveHandler : RequestHandler<PersonRemoveCommand, bool>
    {
        private readonly IServicePerson _servicePerson;
        private readonly IMapper _mapper;

        public PersonRemoveHandler(IServicePerson servicePerson, IMapper mapper)
        {
            _servicePerson = servicePerson;
            _mapper = mapper;
        }

        protected override bool Handle(PersonRemoveCommand request)
        {
            return _servicePerson.Remove(request.Id);
        }
    }
}