using MediatR;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    public record UpdateOrderStatusCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public OrderStatus NewStatus { get; set; }
        public string TrackingNumber { get; set; }
        public int UpdatedBy { get; set; }
    }
}
