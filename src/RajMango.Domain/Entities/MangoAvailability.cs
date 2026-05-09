using RajMango.Domain.Common;
using RajMango.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("MangoAvailabilities")]
    public class MangoAvailability : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int MangoTypeId { get; set; }

        [ForeignKey(nameof(MangoTypeId))]
        public MangoType MangoType { get; set; }

        public int SeasonYear { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public decimal PricePerKg { get; set; }

        public MangoAvailabilityStatus Status { get; set; } = MangoAvailabilityStatus.Upcoming;

        [StringLength(500)]
        public string Notes { get; set; }
    }
}
