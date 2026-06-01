using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs.Courier.RateConfig;
using RajMango.Application.Extensions;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Courier.RateConfig.Queries
{
    public record GetCourierRateConfigWithPaginationQuery : IRequest<PaginatedResult<CourierRateConfigurationDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public string? Filter { get; set; }
        public int? LocationType { get; set; }
        public int? CourierProviderId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class GetCourierRateConfigWithPaginationQueryHandler
        : IRequestHandler<GetCourierRateConfigWithPaginationQuery, PaginatedResult<CourierRateConfigurationDto>>
    {
        private readonly IDataContext _dataContext;

        public GetCourierRateConfigWithPaginationQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<PaginatedResult<CourierRateConfigurationDto>> Handle(
            GetCourierRateConfigWithPaginationQuery query, CancellationToken cancellationToken)
        {
            var q = _dataContext.Get<CourierRateConfiguration>()
                .Include(r => r.CourierProvider)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Filter))
                q = q.Where(r => r.CourierProvider.Name.Contains(query.Filter));

            if (query.LocationType.HasValue)
                q = q.Where(r => (int)r.CourierLocationType == query.LocationType.Value);

            if (query.CourierProviderId.HasValue)
                q = q.Where(r => r.CourierProviderId == query.CourierProviderId.Value);

            if (query.IsActive.HasValue)
                q = q.Where(r => r.IsActive == query.IsActive.Value);

            q = (query.SortBy?.ToLower(), query.SortOrder?.ToLower() == "asc") switch
            {
                ("courierprovidername", true)  => q.OrderBy(r => r.CourierProvider.Name),
                ("courierprovidername", false) => q.OrderByDescending(r => r.CourierProvider.Name),
                ("locationtype",        true)  => q.OrderBy(r => r.CourierLocationType),
                ("locationtype",        false) => q.OrderByDescending(r => r.CourierLocationType),
                ("rateperkg",           true)  => q.OrderBy(r => r.RatePerKg),
                ("rateperkg",           false) => q.OrderByDescending(r => r.RatePerKg),
                ("minimumcharge",       true)  => q.OrderBy(r => r.MinimumCharge),
                ("minimumcharge",       false) => q.OrderByDescending(r => r.MinimumCharge),
                ("isactive",            true)  => q.OrderBy(r => r.IsActive),
                ("isactive",            false) => q.OrderByDescending(r => r.IsActive),
                ("sequence",            true)  => q.OrderBy(r => r.Sequence),
                ("sequence",            false) => q.OrderByDescending(r => r.Sequence),
                _                             => q.OrderBy(r => r.Sequence).ThenBy(r => r.Id),
            };

            var paged = await q.ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);

            var dtos = paged.Data.Select(r => new CourierRateConfigurationDto
            {
                Id                  = r.Id,
                CourierProviderId   = r.CourierProviderId,
                CourierProviderName = r.CourierProvider?.Name,
                LocationType        = (int)r.CourierLocationType,
                RatePerKg           = r.RatePerKg,
                MinimumCharge       = r.MinimumCharge,
                IsActive            = r.IsActive,
                Sequence            = r.Sequence,
            }).ToList();

            return new PaginatedResult<CourierRateConfigurationDto>(
                succeeded:  true,
                data:       dtos,
                pageNumber: query.PageNumber,
                pageSize:   query.PageSize);
        }
    }
}
