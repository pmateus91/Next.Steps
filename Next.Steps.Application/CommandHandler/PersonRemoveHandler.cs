using MediatR;
using Next.Steps.Application.Command;
using Next.Steps.Domain.Interfaces.Services;

namespace Next.Steps.Application.CommandHandler
{
    public class PersonRemoveHandler : RequestHandler<PersonRemoveCommand, bool>
    {
        private readonly IServicePerson _servicePerson;

        public PersonRemoveHandler(IServicePerson servicePerson)
        {
            _servicePerson = servicePerson;
        }

        protected override bool Handle(PersonRemoveCommand request)
        {
            return _servicePerson.Remove(request.Id);
        }
    }
}