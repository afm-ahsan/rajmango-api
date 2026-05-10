using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features
{
    public record NearbyStationDto(
        int Id,
        string Name,
        string AddressLine,
        string City,
        string Area,
        string SupportPhone1,
        string SupportPhone2,
        string Email,
        double? Latitude,
        double? Longitude,
        string GoogleMapUrl,
        int CourierProviderId,
        string CourierProviderName,
        double DistanceKm);

    public record GetNearbyStationsQuery(double Latitude, double Longitude, int RadiusKm = 10, int MaxResults = 10)
        : IRequest<Result<List<NearbyStationDto>>>;

    public class GetNearbyStationsQueryHandler
        : IRequestHandler<GetNearbyStationsQuery, Result<List<NearbyStationDto>>>
    {
        private readonly IDataContext _dataContext;

        public GetNearbyStationsQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<NearbyStationDto>>> Handle(
            GetNearbyStationsQuery query, CancellationToken cancellationToken)
        {
            var stations = await _dataContext.Get<CourierStation>()
                .Include(s => s.CourierProvider)
                .Where(s => s.IsActive && s.Latitude != null && s.Longitude != null)
                .ToListAsync(cancellationToken);

            var nearby = stations
                .Select(s => new
                {
                    Station = s,
                    DistanceKm = Haversine(query.Latitude, query.Longitude, s.Latitude!.Value, s.Longitude!.Value),
                })
                .Where(x => x.DistanceKm <= query.RadiusKm)
                .OrderBy(x => x.DistanceKm)
                .Take(query.MaxResults)
                .Select(x => new NearbyStationDto(
                    Id: x.Station.Id,
                    Name: x.Station.Name,
                    AddressLine: x.Station.AddressLine,
                    City: x.Station.City,
                    Area: x.Station.Area,
                    SupportPhone1: x.Station.SupportPhone1,
                    SupportPhone2: x.Station.SupportPhone2,
                    Email: x.Station.Email,
                    Latitude: x.Station.Latitude,
                    Longitude: x.Station.Longitude,
                    GoogleMapUrl: x.Station.GoogleMapUrl,
                    CourierProviderId: x.Station.CourierProviderId,
                    CourierProviderName: x.Station.CourierProvider.Name,
                    DistanceKm: Math.Round(x.DistanceKm, 2)))
                .ToList();

            return await Result<List<NearbyStationDto>>.SuccessAsync(nearby);
        }

        // Haversine formula — returns distance in kilometres.
        private static double Haversine(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371.0;
            var dLat = ToRad(lat2 - lat1);
            var dLon = ToRad(lon2 - lon1);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2)
                  + Math.Cos(ToRad(lat1)) * Math.Cos(ToRad(lat2))
                  * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            return R * 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        }

        private static double ToRad(double deg) => deg * Math.PI / 180.0;
    }
}
