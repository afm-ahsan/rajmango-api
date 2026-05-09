using RajMango.Domain.Common;
using RajMango.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("JwtAuth")]
    public class JwtAuth : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }

        [Required]
        [StringLength(512)]
        public string AuthToken { get; set; }

        [Required]
        [StringLength(512)]
        public string RefreshToken { get; set; }

        public DateTime IssuedAt { get; set; } = Clock.Now();

        public DateTime ExpiresIn { get; set; }

        public bool IsRevoked { get; set; } = false;
        
        public DateTime? RevokedAt { get; set; }

        public int RevokedBy { get; set; }

        [StringLength(50)]
        public string IpAddress { get; set; }

        [StringLength(255)]
        public string DeviceInfo { get; set; }
    }
}
