using MediatR;
using RajMango.Application.DTOs.Order;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    public record CreateOrderCommand : IRequest<Result<int>>
    {
        public int UserId { get; set; }

        public int? CourierStationId { get; set; }

        public string FallbackAddress { get; set; }

        public ReceiverType ReceiverType { get; set; }

        public string ReceiverName { get; set; }

        public string ReceiverMobileNumber { get; set; }

        public string DeliveryNote { get; set; }

        public IEnumerable<OrderDetailInputDto> OrderDetails { get; set; }
    }
}
