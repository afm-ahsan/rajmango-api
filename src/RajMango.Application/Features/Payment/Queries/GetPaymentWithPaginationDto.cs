using RajMango.Application.DTOs;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Queries
{
    public class GetPaymentWithPaginationDto : AuditedDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string TransactionId { get; set; }
    }
}
