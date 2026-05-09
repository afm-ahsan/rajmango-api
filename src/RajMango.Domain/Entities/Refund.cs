using RajMango.Domain.Common;
using RajMango.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("Refunds")]
    public class Refund : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PaymentId { get; set; }

        [ForeignKey(nameof(PaymentId))]
        public Payment Payment { get; set; }

        public decimal RefundAmount { get; set; }
        
        public DateTime RefundDate { get; set; }
        
        [StringLength(255)]
        public string RefundReason { get; set; }
        
        [StringLength(100)]
        public string RefundedBy { get; set; }

        [StringLength(100)]
        public string RefundReference { get; set; } 
        
        public bool IsGatewayRefunded { get; set; }

        public RefundStatus RefundStatus { get; set; } = RefundStatus.None;

        [StringLength(255)]
        public string GatewayResponseMessage { get; set; }

        [StringLength(100)]
        public string GatewayTransactionId { get; set; }
    }
}
