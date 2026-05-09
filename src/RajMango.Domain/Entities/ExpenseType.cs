using RajMango.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("ExpenseTypes")]
    public class ExpenseType : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        [StringLength(50)]
        public string ColorCode { get; set; }

        public int Sequence { get; set; }

        public bool IsSystem { get; set; }

        public bool IsActive { get; set; }
    }
}
