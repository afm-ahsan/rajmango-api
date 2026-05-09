using System.ComponentModel.DataAnnotations;

namespace RajMango.Application.DTOs
{
    public class ExpenseDto : FullAuditedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExpenseTypeId { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }
    }
}
