using RajMango.Domain.Common;
using RajMango.Shared;
using RajMango.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("Complaints")]
    public class Complaint : AuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser AppUser { get; set; }

        public ComplaintCategory Category { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public ComplaintStatus Status { get; set; } = ComplaintStatus.Submitted;

        [StringLength(1000)]
        public string AdminNote { get; set; }

        public int? ResolvedBy { get; set; }

        public DateTime? ResolvedAt { get; set; }

        public ICollection<ComplaintImage> Images { get; set; } = new List<ComplaintImage>();
    }
}
