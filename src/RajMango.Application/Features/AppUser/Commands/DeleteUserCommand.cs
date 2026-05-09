using MediatR;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public record DeleteUserCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }
}
