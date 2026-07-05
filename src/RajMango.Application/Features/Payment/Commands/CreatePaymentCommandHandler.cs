using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Common;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    internal class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Result<int>>
    {
        private readonly IDataContext _dataContext;
        private readonly INotificationService _notificationService;
        private readonly IRealtimeService _realtime;
        private readonly IPaymentLock _paymentLock;

        public CreatePaymentCommandHandler(
            IDataContext dataContext,
            INotificationService notificationService,
            IRealtimeService realtime,
            IPaymentLock paymentLock)
        {
            _dataContext = dataContext;
            _notificationService = notificationService;
            _realtime = realtime;
            _paymentLock = paymentLock;
        }

        public async Task<Result<int>> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
        {
            // Outside lock: fast existence check (no entity tracking — keeps re-fetch inside lock fresh)
            var orderExists = await _dataContext.Get<Order>()
                .AnyAsync(o => o.Id == command.OrderId, cancellationToken);
            if (!orderExists)
                return await Result<int>.FailureAsync($"Order not found with Id {command.OrderId}.");

            Payment payment;
            Order order;

            // Critical section: re-check balance and persist atomically to prevent double-payment
            using (await _paymentLock.AcquireAsync())
            {
                order = await _dataContext.Get<Order>()
                    .FirstOrDefaultAsync(o => o.Id == command.OrderId, cancellationToken);

                if (order.DueAmount <= 0)
                    return await Result<int>.FailureAsync("This order is already fully paid.");

                var totalCoveredByThisPayment = command.PaidAmount + command.DiscountAmount;
                if (totalCoveredByThisPayment > order.DueAmount)
                    return await Result<int>.FailureAsync(
                        $"Payment amount ({command.PaidAmount:F2}) plus discount ({command.DiscountAmount:F2}) " +
                        $"exceeds the outstanding due amount of {order.DueAmount:F2}.");

                payment = new Payment
                {
                    OrderId        = command.OrderId,
                    PaidAmount     = command.PaidAmount,
                    DiscountAmount = command.DiscountAmount,
                    GrossAmount    = totalCoveredByThisPayment,
                    NetAmount      = command.PaidAmount,
                    PaymentMethod  = command.PaymentMethod,
                    TransactionId  = command.TransactionId,
                };

                _dataContext.Get<Payment>().Add(payment);
                await _dataContext.SaveChangesAsync(cancellationToken);

                var allPayments = await _dataContext.Get<Payment>()
                    .Where(p => p.OrderId == command.OrderId)
                    .ToListAsync(cancellationToken);

                PaymentSyncHelper.SyncOrderPaymentState(order, allPayments);

                payment.DueAmount     = order.DueAmount;
                payment.PaymentStatus = order.PaymentStatus;

                _dataContext.Get<Order>().Update(order);
                _dataContext.Get<Payment>().Update(payment);
                await _dataContext.SaveChangesAsync(cancellationToken);
            }

            await _notificationService.SendPaymentReceivedAsync(
                order.UserId, order.OrderNumber, command.PaidAmount, cancellationToken);

            var paymentPayload = new { PaymentId = payment.Id, order.OrderNumber, Amount = command.PaidAmount, order.UserId };
            await _realtime.SendToUserAsync(order.UserId, RealtimeEvents.PaymentReceived, paymentPayload, cancellationToken);
            await _realtime.SendToAdminsAsync(RealtimeEvents.PaymentReceived, paymentPayload, cancellationToken);

            return await Result<int>.SuccessAsync(payment.Id, "Payment recorded.");
        }
    }
}
