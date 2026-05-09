using MediatR;
using RajMango.Application.DTOs.Order;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public record CreateOrderCommand : IRequest<Result<int>>
    {
        public int UserId { get; set; }

        public int? CourierStationId { get; set; }

        public string FallbackAddress { get; set; }
        
        public IEnumerable<OrderDetailInputDto> OrderDetails { get; set; }
    }
}
