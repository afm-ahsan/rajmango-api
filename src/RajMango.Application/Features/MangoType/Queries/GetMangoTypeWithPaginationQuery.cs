using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using RajMango.Application.Extensions;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetMangoTypeWithPaginationQuery : IRequest<PaginatedResult<GetMangoTypeWithPaginationDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public string Filter { get; set; }

        public GetMangoTypeWithPaginationQuery() { }

        public GetMangoTypeWithPaginationQuery(int pageNumber, int pageSize, string sortBy, string sortOrder, string filter)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SortBy = sortBy;
            SortOrder = sortOrder;
            Filter = filter;
        }
    }

    public class GetCategoryInfoWithPaginationQueryHandler : IRequestHandler<GetMangoTypeWithPaginationQuery, PaginatedResult<GetMangoTypeWithPaginationDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetCategoryInfoWithPaginationQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<GetMangoTypeWithPaginationDto>> Handle(GetMangoTypeWithPaginationQuery queryParam, CancellationToken cancellationToken)
        {
            var query = GetSortedCategories(queryParam.Filter, queryParam.SortBy, queryParam.SortOrder == "asc");
            return await query.ProjectTo<GetMangoTypeWithPaginationDto>(_mapper.ConfigurationProvider)
                              .ToPaginatedListAsync(queryParam.PageNumber, queryParam.PageSize, cancellationToken);
        }

        public IQueryable<MangoType> GetSortedCategories(string filter, string sortBy, bool ascending)
        {
            var query = _dataContext.Get<MangoType>().AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(s => s.Name.Contains(filter));
            }

            switch (sortBy)
            {
                case "name":
                    query = ascending ? query.OrderBy(e => e.Name) : query.OrderByDescending(e => e.Name);
                    break;
                case "pricePerKg":
                    query = ascending ? query.OrderBy(e => e.PricePerKg) : query.OrderByDescending(e => e.PricePerKg);
                    break;
                case "description":
                    query = ascending ? query.OrderBy(e => e.Description) : query.OrderByDescending(e => e.Description);
                    break;
                default:
                    query = ascending ? query.OrderBy(e => e.IsAvailable) : query.OrderByDescending(e => e.IsAvailable);
                    break;
            }

            return query;
        }
    }
}
