using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs;
using RajMango.Application.Extensions;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features
{
    public record GetCourierAreaMapWithPaginationQuery : IRequest<PaginatedResult<CourierAreaMapDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortDirection { get; set; }
        public string Filter { get; set; }
        public int UserId { get; set; }
    }

    public class GetCourierAreaMapWithPaginationQueryHandler : IRequestHandler<GetCourierAreaMapWithPaginationQuery, PaginatedResult<CourierAreaMapDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetCourierAreaMapWithPaginationQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<CourierAreaMapDto>> Handle(GetCourierAreaMapWithPaginationQuery query, CancellationToken cancellationToken)
        {
            var courierAreaMapQuery = _dataContext.Get<CourierAreaMap>().Include(p => p.CourierStation).AsQueryable();

            courierAreaMapQuery = GetSortableQuery(courierAreaMapQuery, query.Filter, query.SortBy, query.SortDirection == "asc");

            var pagedCourierAreaMaps = await courierAreaMapQuery.ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);

            var courierAreaMapDtos = new List<CourierAreaMapDto>();
            foreach (var courierAreaMap in pagedCourierAreaMaps.Data)
            {
                var courierAreaMapDto = new CourierAreaMapDto
                {
                    Id = courierAreaMap.Id,
                    Area = courierAreaMap.Area,
                    CourierStationId = courierAreaMap.CourierStationId,
                    CourierStationName = courierAreaMap.CourierStation.Name
                };

                courierAreaMapDtos.Add(courierAreaMapDto);
            }
            return new PaginatedResult<CourierAreaMapDto>(succeeded: true, data: courierAreaMapDtos, pageNumber: query.PageNumber, pageSize: query.PageSize);
        }

        public IQueryable<CourierAreaMap> GetSortableQuery(IQueryable<CourierAreaMap> query, string filter, string sortBy, bool ascending)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(s => s.Area.Contains(filter));
            }

            switch (sortBy)
            {
                case "area":
                    query = ascending ? query.OrderBy(e => e.Area) : query.OrderByDescending(e => e.Area);
                    break;             
            }

            return query;
        }
    }
}
