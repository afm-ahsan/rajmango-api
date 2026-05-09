using AutoMapper;
using AutoMapper.QueryableExtensions;
using RajMango.Application.Extensions;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;

namespace RajMango.Application.Features.Queries
{
    public record GetCustomerWithPaginationQuery : IRequest<PaginatedResult<GetCustomerWithPaginationDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetCustomerWithPaginationQuery() { }

        public GetCustomerWithPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetCustomerInfoWithPaginationQueryHandler : IRequestHandler<GetCustomerWithPaginationQuery, PaginatedResult<GetCustomerWithPaginationDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetCustomerInfoWithPaginationQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<GetCustomerWithPaginationDto>> Handle(GetCustomerWithPaginationQuery query, CancellationToken cancellationToken)
        {
            return await _dataContext.Get<Customer>()
                   .OrderBy(x => x.FirstName)
                   .ProjectTo<GetCustomerWithPaginationDto>(_mapper.ConfigurationProvider)
                   .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
        }
    }
}
