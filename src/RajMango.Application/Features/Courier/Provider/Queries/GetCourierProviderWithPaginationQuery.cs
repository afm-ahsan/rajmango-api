using MediatR;
using RajMango.Application.DTOs;
using RajMango.Application.Extensions;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features
{
    public record GetCourierProviderWithPaginationQuery : IRequest<PaginatedResult<CourierProviderDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public string Filter { get; set; }
        public int UserId { get; set; }
    }

    public class GetCourierProviderWithPaginationQueryHandler : IRequestHandler<GetCourierProviderWithPaginationQuery, PaginatedResult<CourierProviderDto>>
    {
        private readonly IDataContext _dataContext;

        public GetCourierProviderWithPaginationQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<PaginatedResult<CourierProviderDto>> Handle(GetCourierProviderWithPaginationQuery query, CancellationToken cancellationToken)
        {
            var courierProviderQuery = _dataContext.Get<CourierProvider>().AsQueryable();

            courierProviderQuery = GetSortableQuery(courierProviderQuery, query.Filter, query.SortBy, query.SortOrder == "asc");

            var pagedCourierProviders = await courierProviderQuery.ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);

            var courierProviderDtos = new List<CourierProviderDto>();
            foreach (var courierProvider in pagedCourierProviders.Data)
            {
                var courierProviderDto = new CourierProviderDto
                {
                    Id = courierProvider.Id,
                    Name = courierProvider.Name,
                    Description = courierProvider.Description,
                    SupportPhone = courierProvider.SupportPhone,
                    Email = courierProvider.Email,
                    IsActive = courierProvider.IsActive
                };

                courierProviderDtos.Add(courierProviderDto);
            }
            return new PaginatedResult<CourierProviderDto>(succeeded: true, data: courierProviderDtos, pageNumber: query.PageNumber, pageSize: query.PageSize);
        }

        public IQueryable<CourierProvider> GetSortableQuery(IQueryable<CourierProvider> query, string filter, string sortBy, bool ascending)
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
                case "description":
                    query = ascending ? query.OrderBy(e => e.Description) : query.OrderByDescending(e => e.Description);
                    break;
                default:
                    query = query.OrderBy(e => e.Id);
                    break;
            }

            return query;
        }
    }
}
