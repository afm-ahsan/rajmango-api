using MediatR;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    public record CreatePaymentCommand : IRequest<Result<int>>
    {
        public int OrderId { get; set; }
        public decimal PaidAmount { get; set; }
        /// <summary>Admin discount applied to this payment. Reduces what the customer owes. Defaults to 0.</summary>
        public decimal DiscountAmount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string TransactionId { get; set; }
    }
}
