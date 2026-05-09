using RajMango.Application.DTOs;

namespace RajMango.Application.Features.Queries
{
    public class GetExpenseByIdDto : FullAuditedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExpenseTypeId { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }
    }
}
