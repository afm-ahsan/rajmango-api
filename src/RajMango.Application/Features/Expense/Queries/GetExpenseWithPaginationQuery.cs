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

        public GetExpenseWithPaginationQuery() { }

        public GetExpenseWithPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
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
            return await _dataContext.Get<Expense>()
                   .OrderBy(x => x.Name)
                   .ProjectTo<GetExpenseWithPaginationDto>(_mapper.ConfigurationProvider)
                   .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
        }
    }
}
