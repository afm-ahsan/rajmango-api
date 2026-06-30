using RajMango.Domain.Common;
using RajMango.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("Payments")]
    public class Payment : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [StringLength(100)]
        public string TransactionId { get; set; }

        public decimal GrossAmount { get; set; }

        public decimal DiscountAmount { get; set; }        
        
        public decimal VatAmount { get; set; }

        //[NotMapped]
        //public decimal NetAmount => GrossAmount - DiscountAmount + VatAmount;
        public decimal NetAmount { get; set; }

        public decimal PaidAmount { get; set; }

        //[NotMapped]
        //public decimal DueAmount => NetAmount - PaidAmount;
        public decimal DueAmount { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        // bKash gateway fields — null for non-bKash payments
        [StringLength(100)]
        public string GatewayPaymentId { get; set; }

        /// <summary>The bKash checkout URL returned by Create Payment — kept so an in-progress
        /// (Pending, not yet expired) payment can be resumed without calling bKash again.</summary>
        [StringLength(1000)]
        public string BkashUrl { get; set; }

        [StringLength(100)]
        public string GatewayTransactionId { get; set; }

        [StringLength(100)]
        public string MerchantInvoiceNumber { get; set; }

        [StringLength(50)]
        public string BkashCallbackStatus { get; set; }

        public string RawCreateResponse { get; set; }

        public string RawExecuteResponse { get; set; }

        public DateTime? PaidAt { get; set; }

        public ICollection<PaymentAttachment> PaymentAttachments { get; set; } = new List<PaymentAttachment>();
    }
}
