using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public DeletePaymentCommandHandler(IErrorHandler errorHandler, IDataContext dataContext)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(DeletePaymentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var payment = await _dataContext.Get<Payment>().FindAsync(new object[] { command.Id }, cancellationToken);
                if (payment == null)
                    return await Result<int>.FailureAsync($"Payment not found with Id {command.Id}.");

                var orderId = payment.OrderId;
                _dataContext.Get<Payment>().Remove(payment);
                await _dataContext.SaveChangesAsync(cancellationToken);

                var order = await _dataContext.Get<Order>().FindAsync(new object[] { orderId }, cancellationToken);
                var remainingPayments = await _dataContext.Get<Payment>()
                    .Where(p => p.OrderId == orderId)
                    .ToListAsync(cancellationToken);

                PaymentSyncHelper.SyncOrderPaymentState(order, remainingPayments);
                _dataContext.Get<Order>().Update(order);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(payment.Id, "Payment deleted.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Payment deletion failed for Id {command.Id}.");
        }
    }
}
