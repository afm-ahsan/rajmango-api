using Microsoft.EntityFrameworkCore;
using RajMango.Domain.Common;
using RajMango.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("Expenses")]
    [Index(nameof(Name), IsUnique = true)]
    public class Expense : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ExpenseTypeId { get; set; }

        [ForeignKey(nameof(ExpenseTypeId))]
        public ExpenseType ExpenseType { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        public DateTime ExpenseDate { get; set; }

        [StringLength(50)]
        public string TransactionId { get; set; }

        [StringLength(100)]
        public string PaidTo { get; set; }

        public decimal Amount { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public bool IsActive { get; set; }
    }
}
