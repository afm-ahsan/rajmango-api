using RajMango.Shared.Enums;

namespace RajMango.Application.DTOs.Order
{
    public class OrderDetailInputDto
    {
        public int MangoTypeId { get; set; }
        public CrateType CrateType { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public string Note { get; set; }
    }

}
