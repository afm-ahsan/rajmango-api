using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features
{
    public record AvailableCourierStationQuery : IRequest<Result<List<AvailableCourierStationDto>>>
    {
        public string Area { get; set; }
    }

    public class AvailableCourierStationQueryHandler : IRequestHandler<AvailableCourierStationQuery, Result<List<AvailableCourierStationDto>>>
    {
        private readonly IDataContext _dataContext;

        public AvailableCourierStationQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<AvailableCourierStationDto>>> Handle(AvailableCourierStationQuery query, CancellationToken cancellationToken)
        {
            var stations = await _dataContext.Get<CourierStation>()
                .Include(cs => cs.CourierProvider)
                .Include(cs => cs.CourierAreaMaps)
                .Where(cs => cs.IsActive && cs.CourierAreaMaps.Any(m => m.Area == query.Area))
                .ToListAsync(cancellationToken);

            var result = stations.Select(cs => new AvailableCourierStationDto
            {
                StationId    = cs.Id,
                StationName  = cs.Name,
                ProviderName = cs.CourierProvider?.Name,
                City         = cs.City,
                Area         = cs.Area,
                Phone        = cs.SupportPhone1,
                MapUrl       = cs.GoogleMapUrl,
                LocationType = string.Equals(cs.City, "Dhaka", StringComparison.OrdinalIgnoreCase)
                    ? CourierLocationType.InsideDhaka
                    : CourierLocationType.OutsideDhaka,
            }).ToList();

            return await Result<List<AvailableCourierStationDto>>.SuccessAsync(result);
        }
    }
}
