using MediatR;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public record DeleteOrderCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }
}
