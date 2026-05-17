using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetOrderPaymentsQuery(int OrderId) : IRequest<Result<List<GetOrderPaymentDto>>>;

    internal class GetOrderPaymentsQueryHandler
        : IRequestHandler<GetOrderPaymentsQuery, Result<List<GetOrderPaymentDto>>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetOrderPaymentsQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<List<GetOrderPaymentDto>>> Handle(
            GetOrderPaymentsQuery request, CancellationToken cancellationToken)
        {
            var order = await _dataContext.Get<Order>()
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);

            if (order is null)
                return await Result<List<GetOrderPaymentDto>>.FailureAsync($"Order {request.OrderId} not found.");

            if (!_currentUserService.IsAdmin && order.UserId != _currentUserService.UserId)
                return await Result<List<GetOrderPaymentDto>>.FailureAsync("Access denied.");

            var payments = await _dataContext.Get<Domain.Entities.Payment>()
                .AsNoTracking()
                .Where(p => p.OrderId == request.OrderId)
                .OrderByDescending(p => p.CreatedAt)
                .Select(p => new GetOrderPaymentDto
                {
                    Id = p.Id,
                    OrderId = p.OrderId,
                    GrossAmount = p.GrossAmount,
                    PaidAmount = p.PaidAmount,
                    DueAmount = p.DueAmount,
                    PaymentStatus = p.PaymentStatus,
                    PaymentMethod = p.PaymentMethod,
                    TransactionId = p.TransactionId,
                    GatewayPaymentId = p.GatewayPaymentId,
                    GatewayTransactionId = p.GatewayTransactionId,
                    MerchantInvoiceNumber = p.MerchantInvoiceNumber,
                    PaidAt = p.PaidAt,
                    CreatedAt = p.CreatedAt,
                })
                .ToListAsync(cancellationToken);

            return await Result<List<GetOrderPaymentDto>>.SuccessAsync(payments);
        }
    }
}
