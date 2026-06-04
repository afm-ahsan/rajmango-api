using RajMango.Domain.Common;
using RajMango.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("SmsLogs")]
    public class SmsLog : CreationAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>User who owns the order. Nullable to tolerate future account deletions.</summary>
        public int? UserId { get; set; }

        /// <summary>Phone number snapshot at send time (international format, no leading +).</summary>
        [StringLength(20)]
        public string MobileNumber { get; set; }

        [StringLength(50)]
        public string OrderNumber { get; set; }

        /// <summary>Identifies which event triggered the SMS (e.g. "OrderStatus_Confirmed", "DeliveryDate").</summary>
        [StringLength(50)]
        public string TriggerEvent { get; set; }

        [StringLength(280)]
        public string Message { get; set; }

        public SmsLogStatus Status { get; set; }

        public int? HttpStatusCode { get; set; }

        [StringLength(1000)]
        public string ProviderResponse { get; set; }

        [StringLength(500)]
        public string ErrorMessage { get; set; }

        public DateTime? SentAt { get; set; }
    }
}
