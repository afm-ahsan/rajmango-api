using Microsoft.EntityFrameworkCore;
using RajMango.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("Permissions")]
    [Index(nameof(Name), IsUnique = true)]
    public class Permission : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Module { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<RolePermission> RolePermissions { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }
    }
}
