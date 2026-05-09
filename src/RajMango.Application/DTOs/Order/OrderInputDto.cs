namespace RajMango.Application.DTOs.Order
{
    public class OrderInputDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? CourierStationId { get; set; }
        public string FallbackAddress { get; set; }
        public IEnumerable<OrderDetailInputDto> OrderDetails { get; set; }
    }
}
