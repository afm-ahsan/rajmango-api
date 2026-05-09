namespace RajMango.Application.DTOs
{
    public class FullAuditedDto : AuditedDto
    {
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
