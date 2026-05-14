namespace RajMango.Application.DTOs
{
    public class RoleInputDto : FullAuditedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<string> Permissions { get; set; } = new();
    }
}
