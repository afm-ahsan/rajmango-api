using Microsoft.EntityFrameworkCore;
using RajMango.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace RajMango.Domain.Entities
{
    [Table("Roles")]
    [Index(nameof(Name), IsUnique = true)]
    public class Role : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Code { get; set; } // e.g., "admin", "sys_admin" "sales_manager"

        [StringLength(256)]
        public string Description { get; set; }

        //[StringLength(3000)]
        public string PermissionJson { get; set; }

        public bool IsActive { get; set; }

        [NotMapped]
        public List<string> Permissions
        {
            get => string.IsNullOrEmpty(PermissionJson)
                ? []
                : JsonSerializer.Deserialize<List<string>>(PermissionJson);

            set => PermissionJson = JsonSerializer.Serialize(value);
        }
    }
}
