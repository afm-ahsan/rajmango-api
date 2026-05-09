namespace RajMango.Application.DTOs
{
    public class PaymentDto : FullAuditedDto
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public int PaymentMethod { get; set; }
        public decimal Discount { get; set; }
        public decimal RecipientAmount { get; set; }
        public decimal Subtotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal VatAmount { get; set; }
        public decimal TotalPayable { get; set; }
        public decimal Balance { get; set; }
        public decimal CashAmount { get; set; }
        public decimal ChangeAmount { get; set; }
        public string CardType { get; set; }
        public string WalletTransactionId { get; set; }
    }
}
