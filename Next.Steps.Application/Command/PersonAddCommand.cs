using MediatR;
using Next.Steps.Application.Dtos;

namespace Next.Steps.Application.Command
{
    public class PersonAddCommand : IRequest
    {
        public PersonWriteDto Person;
    }
}