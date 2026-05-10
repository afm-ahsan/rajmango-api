using MediatR;
using RajMango.Application.DTOs.Order;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public record UpdateOrderCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int? CourierStationId { get; set; }

        public string FallbackAddress { get; set; }

        public string ReceiverName { get; set; }

        public string ReceiverPhone { get; set; }

        public string DeliveryNote { get; set; }

        public IEnumerable<OrderDetailInputDto> OrderDetails { get; set; }
    }
}
