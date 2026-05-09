using RajMango.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("ExpenseAttachments")]
    public class ExpenseAttachment : IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ExpenseId { get; set; }

        [ForeignKey(nameof(ExpenseId))]
        public Expense Expense { get; set; }

        [Required]
        [StringLength(512)]
        public string FilePath { get; set; }
    }
}
