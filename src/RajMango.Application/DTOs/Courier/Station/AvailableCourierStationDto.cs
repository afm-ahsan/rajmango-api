using RajMango.Shared.Enums;

namespace RajMango.Application.DTOs
{
    public class AvailableCourierStationDto
    {
        public int StationId { get; set; }
        public string StationName { get; set; }
        public string ProviderName { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Phone { get; set; }
        public string MapUrl { get; set; }
        public CourierLocationType LocationType { get; set; }
    }
}
