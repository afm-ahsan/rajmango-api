using RajMango.Domain.Common;
using RajMango.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajMango.Domain.Entities
{
    [Table("FeedbackImages")]
    public class FeedbackImage : CreationAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int FeedbackId { get; set; }

        [ForeignKey(nameof(FeedbackId))]
        public Feedback Feedback { get; set; }

        [StringLength(512)]
        public string ImagePath { get; set; }

        public int SortOrder { get; set; } = 0; // 0 = first, higher = later

        public DateTime UploadedAt { get; set; } = Clock.Now();
    }
}
