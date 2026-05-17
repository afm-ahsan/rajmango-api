using RajMango.Domain.Common;
using RajMango.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("Products")]
    public class Product : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        [StringLength(255)]
        public string ImagePath { get; set; }

        [Required]
        public decimal PricePerUnit { get; set; }

        public int StockQuantity { get; set; }

        public decimal WeightPerUnitKg { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }

        [StringLength(100)]
        public string OriginRegion { get; set; } 

        public UnitType UnitType { get; set; } = UnitType.None;

        public bool IsSeasonal { get; set; } = true;

        public bool IsActive { get; set; } = true;
    }
}
