using RajMango.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("CourierStations")]
    public class CourierStation : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CourierProviderId { get; set; }

        [ForeignKey(nameof(CourierProviderId))]
        public CourierProvider CourierProvider { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string AddressLine{ get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Area { get; set; }

        [Required]
        [StringLength(15)]
        public string SupportPhone1 { get; set; }

        [StringLength(15)]
        public string SupportPhone2 { get; set; }

        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        [StringLength(2048)]
        public string GoogleMapUrl { get; set; }

        public bool IsActive { get; set; }

        public ICollection<CourierAreaMap> CourierAreaMaps { get; set; } = new HashSet<CourierAreaMap>();
    }
}
