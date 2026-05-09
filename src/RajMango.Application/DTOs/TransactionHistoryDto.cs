namespace RajMango.Application.DTOs
{
    public class TransactionHistoryDto : AuditedDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TransactionId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Method { get; set; }
        public string RefCode { get; set; }
        public string TransactionDetail { get; set; }
        public int Amount { get; set; }
        public decimal AmountRecieved { get; set; }
        public string PaymentDetails { get; set; }
        public byte Status { get; set; }
    }
}
