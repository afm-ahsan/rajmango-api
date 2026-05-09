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

        public ICollection<PaymentAttachment> PaymentAttachments { get; set; } = new List<PaymentAttachment>();
    }
}
