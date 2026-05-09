using RajMango.Shared;
using MediatR;

namespace RajMango.Application.Features.Commands
{
    public record CreatePaymentCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public int PaymentMethod { get; set; }
        public double Discount { get; set; }
        public double RecipientAmount { get; set; }
        public double Subtotal { get; set; }
        public double DiscountAmount { get; set; }
        public double VatAmount { get; set; }
        public double TotalPayable { get; set; }
        public double Balance { get; set; }
        public decimal CashAmount { get; set; }
        public decimal ChangeAmount { get; set; }
        public int Type { get; set; }
        public string CardType { get; set; }
        public string WalletTransactionId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
