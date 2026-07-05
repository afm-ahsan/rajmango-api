using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetPaymentByIdQuery : IRequest<Result<GetPaymentByIdDto>>
    {
        public int Id { get; set; }

        public GetPaymentByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetPaymentInfoByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, Result<GetPaymentByIdDto>>
    {
        private readonly IDataContext _dataContext;

        public GetPaymentInfoByIdQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<GetPaymentByIdDto>> Handle(GetPaymentByIdQuery query, CancellationToken cancellationToken)
        {
            var payment = await _dataContext.Get<Payment>()
                .Where(p => p.Id == query.Id)
                .Select(p => new GetPaymentByIdDto
                {
                    Id           = p.Id,
                    OrderId      = p.OrderId,
                    OrderNumber  = p.Order != null ? p.Order.OrderNumber : string.Empty,
                    CustomerName = p.Order != null && p.Order.AppUser != null
                                       ? (p.Order.AppUser.FirstName + " " + p.Order.AppUser.LastName).Trim()
                                       : string.Empty,
                    TransactionId = p.TransactionId,
                    GrossAmount = p.GrossAmount,
                    DiscountAmount = p.DiscountAmount,
                    VatAmount = p.VatAmount,
                    NetAmount = p.NetAmount,
                    PaidAmount = p.PaidAmount,
                    DueAmount = p.DueAmount,
                    PaymentStatus = p.PaymentStatus,
                    PaymentMethod = p.PaymentMethod,
                    CreatedBy = p.CreatedBy,
                    CreatedAt = p.CreatedAt,
                    UpdatedBy = p.UpdatedBy,
                    UpdatedAt = p.UpdatedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (payment == null)
                return await Result<GetPaymentByIdDto>.FailureAsync($"Payment not found with Id {query.Id}.");

            return await Result<GetPaymentByIdDto>.SuccessAsync(payment);
        }
    }
}
