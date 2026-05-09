using RajMango.Shared;
using MediatR;

namespace RajMango.Application.Features.Commands
{
    public record DeleteExpenseCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }
}
