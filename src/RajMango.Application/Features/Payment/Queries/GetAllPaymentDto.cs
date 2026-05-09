using RajMango.Application.DTOs;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public class GetAllPaymentDto : FullAuditedDto
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
        public string CardType { get; set; }
        public string WalletTransactionId { get; set; }
    }
}
