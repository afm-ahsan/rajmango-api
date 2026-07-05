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

        /// <summary>Send SMS to the delivery receiver (gift recipient or self). Default: true.</summary>
        public bool ShouldNotifyReceiver { get; set; } = true;

        /// <summary>Send SMS to the order placer (sender/customer). Default: false.</summary>
        public bool ShouldNotifySender { get; set; } = false;

        /// <summary>
        /// Payment method to use when auto-creating a manual payment record for a Paid status transition.
        /// Defaults to Cash if not specified.
        /// </summary>
        public PaymentMethod? ManualPaymentMethod { get; set; }

        /// <summary>
        /// Optional admin reference note for the auto-created payment record (stored as TransactionId).
        /// Defaults to a timestamped admin-adjustment reference.
        /// </summary>
        public string AdminPaymentNote { get; set; }
    }
}
