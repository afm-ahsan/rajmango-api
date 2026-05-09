using RajMango.Domain.Common;
using RajMango.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("Customers")]
    public class Customer : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [StringLength(20)]
        public string PhoneNumber1 { get; set; }

        [StringLength(20)]
        public string PhoneNumber2 { get; set; }

        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }
        
        [StringLength(512)]
        public string AddressLine1 { get; set; }

        [StringLength(512)]
        public string AddressLine2 { get; set; }
        
        public CustomerType CustomerType { get; set; }
        
        public bool IsActive { get; set; }
    }
}
