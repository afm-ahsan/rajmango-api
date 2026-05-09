namespace RajMango.Domain.Common
{
    public abstract class AuditedEntity : IAuditable
    {
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
    }
}
