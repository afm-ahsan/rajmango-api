using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetAllPaymentQuery : IRequest<Result<List<GetAllPaymentDto>>>;

    public class GetAllPaymentInfoQueryHandler : IRequestHandler<GetAllPaymentQuery, Result<List<GetAllPaymentDto>>>
    {
        private readonly IDataContext _dataContext;

        public GetAllPaymentInfoQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<GetAllPaymentDto>>> Handle(GetAllPaymentQuery query, CancellationToken cancellationToken)
        {
            var payments = await _dataContext.Get<Payment>()
                .Select(p => new GetAllPaymentDto
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
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllPaymentDto>>.SuccessAsync(payments);
        }
    }
}
