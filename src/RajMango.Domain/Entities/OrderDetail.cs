using RajMango.Domain.Common;
using RajMango.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("OrderDetails")]
    public class OrderDetail : IHasId<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [Required]
        public int MangoTypeId { get; set; }

        [ForeignKey(nameof(MangoTypeId))]
        public MangoType MangoType { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }
        
        public decimal TotalPrice { get; set; }

        [StringLength(512)]
        public string Note { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [Required]
        public CrateType CrateType { get; set; }

        public bool IsGift { get; set; }

        public bool IsDelivered { get; set; }
    }
}
