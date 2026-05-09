namespace RajMango.Application.DTOs
{
    public class RoleDto : FullAuditedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string PermissionJson { get; set; }

        public List<PermissionModel> Permissions { get; set; }
    }
}
