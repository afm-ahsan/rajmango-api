using RajMango.Application.DTOs;

namespace RajMango.Application.Features.Queries
{
    public class GetExpenseTypeWithPaginationDto : FullAuditedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
