using RajMango.Shared;

namespace RajMango.Domain.Common
{
    public abstract class FullAuditedEntity : IFullAuditable
    {
        public DateTime CreatedAt { get; set; } = Clock.Now();
        public int CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }

        public DateTime? DeletedAt { get; set; }
        public int DeletedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
