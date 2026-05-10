using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly ICurrentUserService _currentUserService;
        private readonly INotificationService _notificationService;

        public CreatePaymentCommandHandler(IDataContext dataContext, ICurrentUserService currentUserService, INotificationService notificationService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
            _notificationService = notificationService;
        }

        public async Task<Result<int>> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
        {
            var order = await _dataContext.Get<Order>()
                .FirstOrDefaultAsync(o => o.Id == command.OrderId, cancellationToken);

            if (order == null)
                return await Result<int>.FailureAsync($"Order not found with Id {command.OrderId}.");

            if (order.DueAmount <= 0)
                return await Result<int>.FailureAsync("This order is already fully paid.");

            if (command.PaidAmount > order.DueAmount)
                return await Result<int>.FailureAsync(
                    $"Payment of {command.PaidAmount:F2} exceeds the outstanding due amount of {order.DueAmount:F2}.");

            var payment = new Payment
            {
                OrderId       = command.OrderId,
                PaidAmount    = command.PaidAmount,
                GrossAmount   = command.PaidAmount,
                NetAmount     = command.PaidAmount,
                PaymentMethod = command.PaymentMethod,
                TransactionId = command.TransactionId,
                CreatedBy     = _currentUserService.UserId,
                CreatedAt     = Clock.Now(),
            };

            _dataContext.Get<Payment>().Add(payment);
            await _dataContext.SaveChangesAsync(cancellationToken);

            var allPayments = await _dataContext.Get<Payment>()
                .Where(p => p.OrderId == command.OrderId)
                .ToListAsync(cancellationToken);

            PaymentSyncHelper.SyncOrderPaymentState(order, allPayments);

            payment.DueAmount      = order.DueAmount;
            payment.PaymentStatus  = order.PaymentStatus;

            _dataContext.Get<Order>().Update(order);
            _dataContext.Get<Payment>().Update(payment);
            await _dataContext.SaveChangesAsync(cancellationToken);

            await _notificationService.SendPaymentReceivedAsync(
                order.UserId, order.OrderNumber, command.PaidAmount, cancellationToken);

            return await Result<int>.SuccessAsync(payment.Id, "Payment recorded.");
        }
    }
}
