using RajMango.Domain.Common;
using RajMango.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("CourierRateConfigurations")]
    public class CourierRateConfiguration : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CourierProviderId { get; set; }

        [ForeignKey(nameof(CourierProviderId))]
        public CourierProvider CourierProvider { get; set; }

        [Required]
        public CourierLocationType CourierLocationType { get; set; }

        [Required]
        public decimal RatePerKg { get; set; }

        public decimal? MinimumCharge { get; set; }

        public bool IsActive { get; set; } = true;

        public int Sequence { get; set; }
    }
}
