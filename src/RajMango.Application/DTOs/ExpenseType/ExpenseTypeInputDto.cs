namespace RajMango.Application.DTOs
{
    public class ExpenseTypeInputDto : FullAuditedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
