using RajMango.Domain.Common;
using RajMango.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("Policies")]
    public class Policy : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public PolicyType PolicyType { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
