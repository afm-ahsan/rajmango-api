using Microsoft.EntityFrameworkCore;
using RajMango.Domain.Common;
using RajMango.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("MangoTypes")]
    [Index(nameof(Name), IsUnique = true)]
    public class MangoType : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }     
        
        [StringLength(1024)]
        public string Description { get; set; }

        [StringLength(512)]
        public string ImagePath { get; set; }
        
        public decimal PricePerKg { get; set; }

        [StringLength(50)]
        public string Region { get; set; }

        [StringLength(50)]
        public string AverageWeight { get; set; }

        public MangoGrade MangoGrade { get; set; }

        public int Sequence { get; set; } = 0;

        public bool IsAvailable { get; set; }
    }
}
