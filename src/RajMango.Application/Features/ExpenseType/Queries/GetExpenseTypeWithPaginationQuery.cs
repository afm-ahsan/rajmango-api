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

        public GetExpenseTypeWithPaginationQuery() { }

        public GetExpenseTypeWithPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
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
            return await _dataContext.Get<ExpenseType>()
                   .OrderBy(x => x.Name)
                   .ProjectTo<GetExpenseTypeWithPaginationDto>(_mapper.ConfigurationProvider)
                   .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
        }
    }
}
