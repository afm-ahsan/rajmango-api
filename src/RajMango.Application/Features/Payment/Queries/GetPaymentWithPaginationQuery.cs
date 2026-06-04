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
        /// <summary>Optional: filter payments for a specific order. 0 = all orders.</summary>
        public int OrderId { get; set; }
        /// <summary>Optional: free-text search on TransactionId or OrderId.</summary>
        public string Filter { get; set; }

        public GetPaymentWithPaginationQuery() { }
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
            var q = _dataContext.Get<Payment>().AsQueryable();

            if (query.OrderId > 0)
                q = q.Where(p => p.OrderId == query.OrderId);

            if (!string.IsNullOrWhiteSpace(query.Filter))
            {
                var f = query.Filter.Trim().ToLower();
                q = q.Where(p =>
                    (p.TransactionId != null && p.TransactionId.ToLower().Contains(f)) ||
                    p.OrderId.ToString().Contains(f));
            }

            return await q
                .OrderByDescending(p => p.CreatedAt)
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
