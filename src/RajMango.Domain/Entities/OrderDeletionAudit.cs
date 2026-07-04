using RajMango.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    /// <summary>
    /// Immutable audit record written whenever an admin soft-deletes an order.
    /// The order row is not physically removed so this table provides the human-readable
    /// context (reason, snapshot) that the Order's own audit columns cannot capture.
    /// No FK back to Orders.Id so the record survives even if the row is later purged.
    /// </summary>
    [Table("OrderDeletionAudit")]
    public class OrderDeletionAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>Order.Id at the time of deletion.</summary>
        public int OrderId { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; }

        /// <summary>Order.UserId — the customer who owned the order.</summary>
        public int CustomerUserId { get; set; }

        /// <summary>ICurrentUserService.UserId of the admin who triggered the deletion.</summary>
        public int DeletedByUserId { get; set; }

        public DateTime DeletedAt { get; set; } = Clock.Now();

        [Required]
        [StringLength(500)]
        public string Reason { get; set; }

        /// <summary>JSON snapshot of the order and its key child data at deletion time.</summary>
        [Required]
        public string OrderSnapshotJson { get; set; }

        public DateTime CreatedAt { get; set; } = Clock.Now();
    }
}
