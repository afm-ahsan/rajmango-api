using MediatR;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public record DeleteMangoTypeCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }
}
