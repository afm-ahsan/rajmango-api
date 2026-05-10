using FluentAssertions;
using RajMango.Application.Features;
using RajMango.Domain.Entities;
using RajMango.Tests.Helpers;
using Xunit;

namespace RajMango.Tests.Handlers.Order
{
    public class GetNearbyStationsQueryHandlerTests
    {
        [Fact]
        public async Task Handle_NoStationsWithCoordinates_ReturnsEmptyList()
        {
            using var db = TestDbContextFactory.Create();
            db.Get<CourierProvider>().Add(new CourierProvider { Name = "DHL", IsActive = true, CreatedBy = 1, CreatedAt = DateTime.UtcNow });
            db.SaveChanges();
            var provider = db.Get<CourierProvider>().First();
            db.Get<CourierStation>().Add(new CourierStation
            {
                CourierProviderId = provider.Id, Name = "Station A", AddressLine = "123 St", City = "Dhaka",
                Area = "Gulshan", SupportPhone1 = "01700000000", IsActive = true, Latitude = null, Longitude = null,
                CreatedBy = 1, CreatedAt = DateTime.UtcNow,
            });
            db.SaveChanges();

            var handler = new GetNearbyStationsQueryHandler(db);
            var result = await handler.Handle(new GetNearbyStationsQuery(23.8103, 90.4125, 10), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_StationWithinRadius_ReturnsSortedByDistance()
        {
            using var db = TestDbContextFactory.Create();
            db.Get<CourierProvider>().Add(new CourierProvider { Name = "SA Paribahan", IsActive = true, CreatedBy = 1, CreatedAt = DateTime.UtcNow });
            db.SaveChanges();
            var provider = db.Get<CourierProvider>().First();

            // Near Dhaka center (23.8103, 90.4125)
            db.Get<CourierStation>().AddRange(
                new CourierStation
                {
                    CourierProviderId = provider.Id, Name = "Close Station", AddressLine = "1 Close Rd",
                    City = "Dhaka", Area = "Motijheel", SupportPhone1 = "01700000001", IsActive = true,
                    Latitude = 23.7337, Longitude = 90.3963, // ~9 km from query point
                    CreatedBy = 1, CreatedAt = DateTime.UtcNow,
                },
                new CourierStation
                {
                    CourierProviderId = provider.Id, Name = "Far Station", AddressLine = "2 Far Rd",
                    City = "Dhaka", Area = "Uttara", SupportPhone1 = "01700000002", IsActive = true,
                    Latitude = 23.8710, Longitude = 90.3985, // ~6 km from query point
                    CreatedBy = 1, CreatedAt = DateTime.UtcNow,
                }
            );
            db.SaveChanges();

            var handler = new GetNearbyStationsQueryHandler(db);
            var result = await handler.Handle(new GetNearbyStationsQuery(23.8103, 90.4125, RadiusKm: 15), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.Should().HaveCount(2);
            result.Data[0].DistanceKm.Should().BeLessThan(result.Data[1].DistanceKm);
        }

        [Fact]
        public async Task Handle_StationOutsideRadius_IsExcluded()
        {
            using var db = TestDbContextFactory.Create();
            db.Get<CourierProvider>().Add(new CourierProvider { Name = "Sundarban Courier", IsActive = true, CreatedBy = 1, CreatedAt = DateTime.UtcNow });
            db.SaveChanges();
            var provider = db.Get<CourierProvider>().First();
            db.Get<CourierStation>().Add(new CourierStation
            {
                CourierProviderId = provider.Id, Name = "Sylhet Station", AddressLine = "1 Sylhet Rd",
                City = "Sylhet", Area = "Sadar", SupportPhone1 = "01700000003", IsActive = true,
                Latitude = 24.8949, Longitude = 91.8687, // ~200 km away
                CreatedBy = 1, CreatedAt = DateTime.UtcNow,
            });
            db.SaveChanges();

            var handler = new GetNearbyStationsQueryHandler(db);
            var result = await handler.Handle(new GetNearbyStationsQuery(23.8103, 90.4125, RadiusKm: 10), CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            result.Data.Should().BeEmpty();
        }
    }
}
