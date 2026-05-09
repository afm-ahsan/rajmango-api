namespace RajMango.Application.DTOs
{
    public class RoleUserDto : AuditedDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
