using System.Text.Json.Serialization;

namespace RajMango.Application.DTOs
{
    public class RoleDto : FullAuditedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore]
        public string PermissionJson { get; set; }

        public List<string> Permissions { get; set; } = new();
    }
}
