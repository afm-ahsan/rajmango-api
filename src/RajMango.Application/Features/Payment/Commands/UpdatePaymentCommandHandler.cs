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
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public UpdatePaymentCommandHandler(IErrorHandler errorHandler, IDataContext dataContext)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(UpdatePaymentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var payment = await _dataContext.Get<Payment>().FindAsync(new object[] { command.Id }, cancellationToken);
                if (payment == null)
                    return await Result<int>.FailureAsync($"Payment not found with Id {command.Id}.");

                payment.PaidAmount = command.PaidAmount;
                payment.GrossAmount = command.PaidAmount;
                payment.NetAmount = command.PaidAmount;
                payment.PaymentMethod = command.PaymentMethod;
                payment.TransactionId = command.TransactionId;
                payment.UpdatedBy = command.UpdatedBy;
                payment.UpdatedAt = Clock.Now();

                _dataContext.Get<Payment>().Update(payment);
                await _dataContext.SaveChangesAsync(cancellationToken);

                var order = await _dataContext.Get<Order>().FindAsync(new object[] { payment.OrderId }, cancellationToken);
                var allPayments = await _dataContext.Get<Payment>()
                    .Where(p => p.OrderId == payment.OrderId)
                    .ToListAsync(cancellationToken);

                PaymentSyncHelper.SyncOrderPaymentState(order, allPayments);
                _dataContext.Get<Order>().Update(order);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(payment.Id, "Payment updated.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Payment update failed for Id {command.Id}.");
        }
    }
}
