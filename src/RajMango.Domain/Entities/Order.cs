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

        // --- Admin-on-behalf-of audit ---

        /// <summary>
        /// Set when an admin places this order on behalf of a customer.
        /// UserId still holds the customer (business owner of the order);
        /// this field records the admin who actually submitted it.
        /// CreatedBy (FullAuditedEntity) is also the admin's UserId when IsPlacedByAdmin is true.
        /// </summary>
        public int? PlacedByAdminUserId { get; set; }

        /// <summary>True when this order was created by an admin acting on behalf of the customer.</summary>
        public bool IsPlacedByAdmin { get; set; }

        public int? CourierStationId { get; set; }

        [ForeignKey(nameof(CourierStationId))]
        public CourierStation CourierStation { get; set; }

        public int? CourierProviderId { get; set; }

        [ForeignKey(nameof(CourierProviderId))]
        public CourierProvider CourierProvider { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; }

        [StringLength(100)]
        public string TrackingNumber { get; set; }

        public int TotalQuantity { get; set; }

        /// <summary>Sum of all OrderDetail.TotalPrice values (mango product cost only).</summary>
        public decimal ProductTotalAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal DueAmount { get; set; }

        // --- Courier charge snapshot ---

        public CourierLocationType? CourierLocationType { get; set; }

        /// <summary>Rate snapshot at the time of order creation/update.</summary>
        public decimal CourierRatePerKg { get; set; }

        /// <summary>Calculated courier charge: max(TotalWeightKg * RatePerKg, MinimumCharge).</summary>
        public decimal CourierCharge { get; set; }

        /// <summary>Admin-set override amount; null means no override.</summary>
        public decimal? CourierChargeOverrideAmount { get; set; }

        public bool IsCourierChargeOverridden { get; set; }

        [StringLength(500)]
        public string CourierChargeNote { get; set; }

        // --- Status & delivery ---

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

        public ReceiverType ReceiverType { get; set; } = ReceiverType.Self;

        [StringLength(100)]
        public string ReceiverName { get; set; }

        [StringLength(20)]
        public string ReceiverMobileNumber { get; set; }

        [StringLength(500)]
        public string DeliveryNote { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();

        public virtual ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();

        public virtual ICollection<Feedback> Feedbacks { get; set; } = new HashSet<Feedback>();
    }
}
