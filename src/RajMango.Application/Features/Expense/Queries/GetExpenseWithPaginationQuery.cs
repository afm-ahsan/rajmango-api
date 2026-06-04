using AutoMapper;
using AutoMapper.QueryableExtensions;
using RajMango.Application.Extensions;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;

namespace RajMango.Application.Features.Queries
{
    public record GetExpenseWithPaginationQuery : IRequest<PaginatedResult<GetExpenseWithPaginationDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Filter { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        public GetExpenseWithPaginationQuery() { }
    }

    public class GetExpenseInfoWithPaginationQueryHandler : IRequestHandler<GetExpenseWithPaginationQuery, PaginatedResult<GetExpenseWithPaginationDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetExpenseInfoWithPaginationQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<GetExpenseWithPaginationDto>> Handle(GetExpenseWithPaginationQuery query, CancellationToken cancellationToken)
        {
            var q = _dataContext.Get<Expense>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Filter))
            {
                var f = query.Filter.Trim().ToLower();
                q = q.Where(e => e.Name.ToLower().Contains(f) ||
                                 (e.Description != null && e.Description.ToLower().Contains(f)));// ||
                                 //(e.Notes != null && e.Notes.ToLower().Contains(f)));
            }

            bool asc = string.IsNullOrEmpty(query.SortOrder) || query.SortOrder.ToLower() != "desc";
            q = (query.SortBy?.ToLower()) switch
            {
                "description" => asc ? q.OrderBy(e => e.Description) : q.OrderByDescending(e => e.Description),
                "amount"      => asc ? q.OrderBy(e => e.Amount)      : q.OrderByDescending(e => e.Amount),
                _             => asc ? q.OrderBy(e => e.Name)        : q.OrderByDescending(e => e.Name),
            };

            return await q
                .ProjectTo<GetExpenseWithPaginationDto>(_mapper.ConfigurationProvider)
                .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
        }
    }
}
