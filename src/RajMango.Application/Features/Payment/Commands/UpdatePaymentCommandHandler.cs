using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, Result<int>>
    {
        private readonly IDataContext _dataContext;
        private readonly IPaymentLock _paymentLock;

        public UpdatePaymentCommandHandler(IDataContext dataContext, IPaymentLock paymentLock)
        {
            _dataContext = dataContext;
            _paymentLock = paymentLock;
        }

        public async Task<Result<int>> Handle(UpdatePaymentCommand command, CancellationToken cancellationToken)
        {
            // Outside lock: fast existence check (no entity tracking — keeps re-fetch inside lock fresh)
            var paymentExists = await _dataContext.Get<Payment>()
                .AnyAsync(p => p.Id == command.Id, cancellationToken);
            if (!paymentExists)
                return await Result<int>.FailureAsync($"Payment not found with Id {command.Id}.");

            // Critical section: re-check overpayment and persist atomically
            using (await _paymentLock.AcquireAsync())
            {
                var payment = await _dataContext.Get<Payment>()
                    .FirstOrDefaultAsync(p => p.Id == command.Id, cancellationToken);

                var order = await _dataContext.Get<Order>()
                    .FirstOrDefaultAsync(o => o.Id == payment.OrderId, cancellationToken);

                if (order == null)
                    return await Result<int>.FailureAsync("Associated order not found.");

                var otherPaymentsTotal = await _dataContext.Get<Payment>()
                    .Where(p => p.OrderId == payment.OrderId && p.Id != payment.Id)
                    .SumAsync(p => p.PaidAmount + p.DiscountAmount, cancellationToken);

                var thisPaymentTotal = command.PaidAmount + command.DiscountAmount;
                if (otherPaymentsTotal + thisPaymentTotal > order.TotalAmount)
                    return await Result<int>.FailureAsync(
                        $"Updated payment (including discount) would exceed the order total of {order.TotalAmount:F2}.");

                payment.PaidAmount     = command.PaidAmount;
                payment.DiscountAmount = command.DiscountAmount;
                payment.GrossAmount    = thisPaymentTotal;
                payment.NetAmount      = command.PaidAmount;
                payment.PaymentMethod  = command.PaymentMethod;
                payment.TransactionId  = command.TransactionId;

                _dataContext.Get<Payment>().Update(payment);
                await _dataContext.SaveChangesAsync(cancellationToken);

                var allPayments = await _dataContext.Get<Payment>()
                    .Where(p => p.OrderId == payment.OrderId)
                    .ToListAsync(cancellationToken);

                PaymentSyncHelper.SyncOrderPaymentState(order, allPayments);

                payment.DueAmount     = order.DueAmount;
                payment.PaymentStatus = order.PaymentStatus;

                _dataContext.Get<Order>().Update(order);
                _dataContext.Get<Payment>().Update(payment);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(payment.Id, "Payment updated.");
            }
        }
    }
}
