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
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public CreatePaymentCommandHandler(IErrorHandler errorHandler, IDataContext dataContext)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _dataContext.Get<Order>().FindAsync(new object[] { command.OrderId }, cancellationToken);
                if (order == null)
                    return await Result<int>.FailureAsync($"Order not found with Id {command.OrderId}.");

                var payment = new Payment
                {
                    OrderId = command.OrderId,
                    PaidAmount = command.PaidAmount,
                    GrossAmount = command.PaidAmount,
                    NetAmount = command.PaidAmount,
                    PaymentMethod = command.PaymentMethod,
                    TransactionId = command.TransactionId,
                    CreatedBy = command.CreatedBy,
                    CreatedAt = Clock.Now(),
                };

                _dataContext.Get<Payment>().Add(payment);
                await _dataContext.SaveChangesAsync(cancellationToken);

                var allPayments = await _dataContext.Get<Payment>()
                    .Where(p => p.OrderId == command.OrderId)
                    .ToListAsync(cancellationToken);

                PaymentSyncHelper.SyncOrderPaymentState(order, allPayments);
                _dataContext.Get<Order>().Update(order);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(payment.Id, "Payment recorded.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync("Payment creation failed.");
        }
    }
}
