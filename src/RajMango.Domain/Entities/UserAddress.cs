using RajMango.Domain.Common;
using RajMango.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("UserAddresses")]
    public class UserAddress : FullAuditedEntity, IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser AppUser { get; set; }

        [Required]
        [StringLength(255)]
        public string AddressLine { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string Area { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        public AddressType AddressType { get; set; }        

        public bool IsPrimary { get; set; } = false;
    }
}
