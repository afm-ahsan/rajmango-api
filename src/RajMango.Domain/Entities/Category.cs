using Microsoft.EntityFrameworkCore;
using RajMango.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("Categories")]
    [Index(nameof(Name), IsUnique = true)]
    public class Category : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? ParentCategoryId { get; set; }

        [ForeignKey(nameof(ParentCategoryId))]
        public Category ParentCategory { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }  // Mango, Gift, Accessory

        [StringLength(512)]
        public string Description { get; set; }

        [StringLength(255)]
        public string IconPath { get; set; } // Optional: UI icon

        [StringLength(100)]
        public string Slug { get; set; } // Optional: SEO-friendly URL part

        public bool IsActive { get; set; } = true;

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public virtual ICollection<Category> SubCategories { get; set; } = new HashSet<Category>();
    }
}
