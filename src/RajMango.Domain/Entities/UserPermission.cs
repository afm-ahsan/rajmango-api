using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    /// <summary>
    /// Per-user permission overrides. IsGranted=true grants an extra permission;
    /// IsGranted=false revokes a role-inherited permission.
    /// </summary>
    [Table("UserPermissions")]
    public class UserPermission
    {
        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser AppUser { get; set; }

        [Required]
        public int PermissionId { get; set; }

        [ForeignKey(nameof(PermissionId))]
        public Permission Permission { get; set; }

        public bool IsGranted { get; set; } = true;
    }
}
