using AutoMapper;
using AutoMapper.QueryableExtensions;
using RajMango.Application.Extensions;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;

namespace RajMango.Application.Features.Queries
{
    public record GetExpenseTypeWithPaginationQuery : IRequest<PaginatedResult<GetExpenseTypeWithPaginationDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Filter { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        public GetExpenseTypeWithPaginationQuery() { }
    }

    public class GetExpenseTypeInfoWithPaginationQueryHandler : IRequestHandler<GetExpenseTypeWithPaginationQuery, PaginatedResult<GetExpenseTypeWithPaginationDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetExpenseTypeInfoWithPaginationQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<GetExpenseTypeWithPaginationDto>> Handle(GetExpenseTypeWithPaginationQuery query, CancellationToken cancellationToken)
        {
            var q = _dataContext.Get<ExpenseType>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Filter))
            {
                var f = query.Filter.Trim().ToLower();
                q = q.Where(e => e.Name.ToLower().Contains(f) ||
                                 (e.Description != null && e.Description.ToLower().Contains(f)));
            }

            bool asc = string.IsNullOrEmpty(query.SortOrder) || query.SortOrder.ToLower() != "desc";
            q = (query.SortBy?.ToLower()) switch
            {
                "description" => asc ? q.OrderBy(e => e.Description) : q.OrderByDescending(e => e.Description),
                _             => asc ? q.OrderBy(e => e.Name)        : q.OrderByDescending(e => e.Name),
            };

            return await q
                .ProjectTo<GetExpenseTypeWithPaginationDto>(_mapper.ConfigurationProvider)
                .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
        }
    }
}
