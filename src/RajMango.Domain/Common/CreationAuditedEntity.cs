using RajMango.Shared;

namespace RajMango.Domain.Common
{
    public abstract class CreationAuditedEntity : ICreationAuditable
    {
        public DateTime CreatedAt { get; set; } = Clock.Now();
        public int CreatedBy { get; set; }
    }
}
