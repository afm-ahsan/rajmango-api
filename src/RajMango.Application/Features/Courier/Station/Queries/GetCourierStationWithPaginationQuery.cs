using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs;
using RajMango.Application.Extensions;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features
{
    public record GetCourierStationWithPaginationQuery : IRequest<PaginatedResult<CourierStationDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public string Filter { get; set; }
    }

    public class GetCourierStationWithPaginationQueryHandler : IRequestHandler<GetCourierStationWithPaginationQuery, PaginatedResult<CourierStationDto>>
    {
        private readonly IDataContext _dataContext;

        public GetCourierStationWithPaginationQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<PaginatedResult<CourierStationDto>> Handle(GetCourierStationWithPaginationQuery query, CancellationToken cancellationToken)
        {
            var courierStationQuery = _dataContext.Get<CourierStation>()
                                                  .Include(p => p.CourierProvider)
                                                  .AsQueryable();

            courierStationQuery = GetSortableQuery(courierStationQuery, query.Filter, query.SortBy, query.SortOrder == "asc");

            var pagedCourierStations = await courierStationQuery.ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);

            var courierStationDtos = new List<CourierStationDto>();
            foreach (var courierStation in pagedCourierStations.Data)
            {
                var courierStationDto = new CourierStationDto
                {
                    Id = courierStation.Id,
                    Name = courierStation.Name,
                    AddressLine = courierStation.AddressLine,
                    City = courierStation.City,
                    Area = courierStation.Area,
                    SupportPhone1 = courierStation.SupportPhone1,
                    SupportPhone2 = courierStation.SupportPhone2,
                    Email = courierStation.Email,
                    Latitude = courierStation.Latitude,
                    Longitude = courierStation.Longitude,
                    GoogleMapUrl = courierStation.GoogleMapUrl,
                    IsActive = courierStation.IsActive,
                    CourierProviderId = courierStation.CourierProviderId,
                    CourierProviderName = courierStation.CourierProvider.Name,
                };

                courierStationDtos.Add(courierStationDto);
            }
            return new PaginatedResult<CourierStationDto>(succeeded: true, data: courierStationDtos, pageNumber: query.PageNumber, pageSize: query.PageSize);
        }

        public IQueryable<CourierStation> GetSortableQuery(IQueryable<CourierStation> query, string filter, string sortBy, bool ascending)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(s => s.Name.Contains(filter));
            }

            switch (sortBy)
            {
                case "name":
                    query = ascending ? query.OrderBy(e => e.Name) : query.OrderByDescending(e => e.Name);
                    break;
                case "addressLine":
                    query = ascending ? query.OrderBy(e => e.AddressLine) : query.OrderByDescending(e => e.AddressLine);
                    break;
                case "city":
                    query = ascending ? query.OrderBy(e => e.City) : query.OrderByDescending(e => e.City);
                    break;
                case "area":
                    query = ascending ? query.OrderBy(e => e.Area) : query.OrderByDescending(e => e.Area);
                    break;
                default:
                    query = query.OrderBy(e => e.Id);
                    break;
            }

            return query;
        }
    }
}
