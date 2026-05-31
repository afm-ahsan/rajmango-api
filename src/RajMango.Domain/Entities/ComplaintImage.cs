using RajMango.Domain.Common;
using RajMango.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("ComplaintImages")]
    public class ComplaintImage : CreationAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ComplaintId { get; set; }

        [ForeignKey(nameof(ComplaintId))]
        public Complaint Complaint { get; set; }

        [Required]
        [StringLength(512)]
        public string ImagePath { get; set; }

        public int SortOrder { get; set; } = 0;

        public DateTime UploadedAt { get; set; } = Clock.Now();
    }
}
