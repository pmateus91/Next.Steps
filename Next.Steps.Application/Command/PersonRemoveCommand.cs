using MediatR;

namespace Next.Steps.Application.Command
{
    public class PersonRemoveCommand : IRequest<bool>
    {
        public int Id;
    }
}