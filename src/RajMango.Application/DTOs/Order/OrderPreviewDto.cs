namespace RajMango.Application.DTOs.Order
{
    public class OrderPreviewDto
    {
        public decimal ProductTotalAmount { get; set; }
        public int TotalWeightKg { get; set; }
        public decimal? CourierCharge { get; set; }
        public decimal TotalAmount { get; set; }
        public string CourierProviderName { get; set; }
        public decimal? CourierRatePerKg { get; set; }
    }
}
