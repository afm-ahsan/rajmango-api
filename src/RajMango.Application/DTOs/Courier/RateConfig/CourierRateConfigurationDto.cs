namespace RajMango.Application.DTOs.Courier.RateConfig
{
    public class CourierRateConfigurationDto
    {
        public int Id { get; set; }
        public int CourierProviderId { get; set; }
        public string CourierProviderName { get; set; }
        public int LocationType { get; set; }
        public decimal RatePerKg { get; set; }
        public decimal? MinimumCharge { get; set; }
        public bool IsActive { get; set; }
        public int Sequence { get; set; }
    }
}
