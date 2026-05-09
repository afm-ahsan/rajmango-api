using Microsoft.EntityFrameworkCore;
using RajMango.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("CourierProviders")]
    [Index(nameof(Name), IsUnique = true)]
    public class CourierProvider : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(15)]
        public string SupportPhone { get; set; }

        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        public int Sequence { get; set; }

        public bool IsActive { get; set; }

        public ICollection<CourierStation> CourierStations { get; set; } = new HashSet<CourierStation>();
    }
}
