using AutoMapper;
using AutoMapper.QueryableExtensions;
using RajMango.Application.Extensions;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;

namespace RajMango.Application.Features.Queries
{
    public record GetPaymentWithPaginationQuery : IRequest<PaginatedResult<GetPaymentWithPaginationDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetPaymentWithPaginationQuery() { }

        public GetPaymentWithPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetPaymentInfoWithPaginationQueryHandler : IRequestHandler<GetPaymentWithPaginationQuery, PaginatedResult<GetPaymentWithPaginationDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetPaymentInfoWithPaginationQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<GetPaymentWithPaginationDto>> Handle(GetPaymentWithPaginationQuery query, CancellationToken cancellationToken)
        {
            return await _dataContext.Get<Payment>()
                   .OrderBy(x => x.Id)
                   .ProjectTo<GetPaymentWithPaginationDto>(_mapper.ConfigurationProvider)
                   .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
        }
    }
}
