using RajMango.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("AuditLogs")]
    public class AuditLog : AuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public string TableName { get; set; }

        public int EntityId { get; set; }

        [StringLength(50)]
        public string ActionType { get; set; } // Create, Update, Delete

        [StringLength(100)]
        public string PerformedBy { get; set; }

        public DateTime PerformedAt { get; set; }

        public string PreviousData { get; set; }

        public string NewData { get; set; }
    }
}
