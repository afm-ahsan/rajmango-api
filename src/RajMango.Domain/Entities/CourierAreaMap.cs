using RajMango.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("CourierAreaMaps")]
    public class CourierAreaMap : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CourierStationId { get; set; }

        [ForeignKey(nameof(CourierStationId))]
        public CourierStation CourierStation { get; set; }

        [Required]
        [StringLength(100)]
        public string Area { get; set; }
    }
}
