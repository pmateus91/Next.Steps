using MediatR;
using Next.Steps.Application.Dtos;

namespace Next.Steps.Application.Query
{
    public class PersonGetByIdQuery : IRequest<PersonReadDto>
    {
        public int Id { get; set; }
    }
}