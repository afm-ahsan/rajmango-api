using RajMango.Domain.Common;
using RajMango.Shared;
using RajMango.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("Orders")]
    public class Order : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser AppUser { get; set; }

        public int? CourierStationId { get; set; }

        [ForeignKey(nameof(CourierStationId))]
        public CourierStation CourierStation { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; }

        [StringLength(100)]
        public string TrackingNumber { get; set; }

        public int TotalQuantity { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal DueAmount { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = Clock.Now();

        public DateTime? DeliveryDate { get; set; }

        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;

        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Unpaid;

        public DeliveryStatus DeliveryStatus { get; set; } = DeliveryStatus.Pending;

        public bool IsDelivered { get; set; }

        public bool IsValidOrder { get; set; } = true;
        
        [StringLength(500)]
        public string FallbackAddress { get; set; }

        [StringLength(100)]
        public string ReceiverName { get; set; }

        [StringLength(20)]
        public string ReceiverPhone { get; set; }

        [StringLength(500)]
        public string DeliveryNote { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
        
        public virtual ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
        
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new HashSet<Feedback>();
    }
}
