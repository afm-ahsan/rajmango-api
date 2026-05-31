using RajMango.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("PaymentAttachments")]
    public class PaymentAttachment : CreationAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PaymentId { get; set; }

        [ForeignKey(nameof(PaymentId))]
        public Payment Payment { get; set; }

        [Required]
        [StringLength(512)]
        public string FilePath { get; set; }

        [StringLength(100)]
        public string FileName { get; set; }

        [StringLength(50)]
        public string ContentType { get; set; }

        public int SortOrder { get; set; } = 0;
    }
}
