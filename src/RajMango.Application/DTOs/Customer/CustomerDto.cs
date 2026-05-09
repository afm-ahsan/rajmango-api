using RajMango.Shared;
using System.ComponentModel.DataAnnotations;

namespace RajMango.Application.DTOs
{
    public class CustomerDto : FullAuditedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int CustomerType { get; set; }
        public bool IsActive { get; set; }
    }
}
