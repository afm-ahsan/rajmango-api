using MediatR;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    public record UpdateAdminOrderStatusCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
