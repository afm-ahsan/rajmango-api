namespace RajMango.Application.DTOs
{
    public class CourierProviderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SupportPhone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        // Optional - only if eager loading of stations is needed
        public List<CourierStationDto> Stations { get; set; }
    }
}
