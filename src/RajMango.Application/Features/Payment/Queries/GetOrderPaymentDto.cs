using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Queries
{
    public class GetOrderPaymentDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public string GatewayPaymentId { get; set; }
        public string GatewayTransactionId { get; set; }
        public string MerchantInvoiceNumber { get; set; }
        public DateTime? PaidAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
