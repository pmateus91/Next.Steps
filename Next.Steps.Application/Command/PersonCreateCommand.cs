using MediatR;
using Next.Steps.Application.Dtos;

namespace Next.Steps.Application.Command
{
    public class PersonCreateCommand : IRequest
    {
        public PersonWriteDto Person;
    }
}