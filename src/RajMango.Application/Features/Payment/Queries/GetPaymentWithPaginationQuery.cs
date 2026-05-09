using MediatR;
using RajMango.Application.Extensions;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

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

        public GetPaymentInfoWithPaginationQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<PaginatedResult<GetPaymentWithPaginationDto>> Handle(GetPaymentWithPaginationQuery query, CancellationToken cancellationToken)
        {
            return await _dataContext.Get<Payment>()
                .OrderBy(p => p.Id)
                .Select(p => new GetPaymentWithPaginationDto
                {
                    Id = p.Id,
                    OrderId = p.OrderId,
                    PaidAmount = p.PaidAmount,
                    DueAmount = p.DueAmount,
                    PaymentStatus = p.PaymentStatus,
                    PaymentMethod = p.PaymentMethod,
                    TransactionId = p.TransactionId,
                    CreatedBy = p.CreatedBy,
                    CreatedAt = p.CreatedAt,
                    UpdatedBy = p.UpdatedBy,
                    UpdatedAt = p.UpdatedAt,
                })
                .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
        }
    }
}
