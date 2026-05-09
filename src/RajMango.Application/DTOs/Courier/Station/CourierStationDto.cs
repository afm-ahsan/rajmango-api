using RajMango.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RajMango.Application.DTOs
{
    public class CourierStationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string SupportPhone1 { get; set; }
        public string SupportPhone2 { get; set; }
        public string Email { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string GoogleMapUrl { get; set; }
        public bool IsActive { get; set; }
        public int CourierProviderId { get; set; }
        public string CourierProviderName { get; set; } // Optional for display
        public ICollection<CourierAreaMap> CourierAreaMaps { get; set; }
    }

}
