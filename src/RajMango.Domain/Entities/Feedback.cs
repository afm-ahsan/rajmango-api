using RajMango.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("Feedbacks")]
    public class Feedback : AuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser AppUser { get; set; }

        /// <summary>1–5 star rating.</summary>
        public int Rating { get; set; }

        [StringLength(1000)]
        public string Note { get; set; }

        public ICollection<FeedbackImage> Images { get; set; } = new List<FeedbackImage>();
    }
}
