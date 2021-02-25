using MediatR;
using Next.Steps.Application.Dtos;
using System.Collections.Generic;

namespace Next.Steps.Application.Query
{
    public class PersonGetAllQuery : IRequest<IEnumerable<PersonReadDto>>
    {
    }
}