using MediatR;
using Next.Steps.Application.Dtos;

namespace Next.Steps.Application.Command
{
    public class PersonUpdateCommand : IRequest
    {
        public PersonUpdateDto Person;
    }
}