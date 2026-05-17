using RajMango.Shared;
using MediatR;

namespace RajMango.Application.Features.Commands
{
    public record UpdateExpenseCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExpenseTypeId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentReference { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
