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
        private readonly IPaymentLock _paymentLock;

        public DeletePaymentCommandHandler(IErrorHandler errorHandler, IDataContext dataContext, IPaymentLock paymentLock)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _paymentLock = paymentLock;
        }

        public async Task<Result<int>> Handle(DeletePaymentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var exists = await _dataContext.Get<Payment>().AnyAsync(p => p.Id == command.Id, cancellationToken);
                if (!exists)
                    return await Result<int>.FailureAsync($"Payment not found with Id {command.Id}.");

                int paymentId;
                using (await _paymentLock.AcquireAsync())
                {
                    var payment = await _dataContext.Get<Payment>()
                        .FirstOrDefaultAsync(p => p.Id == command.Id, cancellationToken);
                    if (payment == null)
                        return await Result<int>.FailureAsync($"Payment not found with Id {command.Id}.");

                    paymentId = payment.Id;
                    var orderId = payment.OrderId;

                    _dataContext.Get<Payment>().Remove(payment);
                    await _dataContext.SaveChangesAsync(cancellationToken);

                    var order = await _dataContext.Get<Order>()
                        .FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken);
                    var remainingPayments = await _dataContext.Get<Payment>()
                        .Where(p => p.OrderId == orderId)
                        .ToListAsync(cancellationToken);

                    PaymentSyncHelper.SyncOrderPaymentState(order, remainingPayments);
                    _dataContext.Get<Order>().Update(order);
                    await _dataContext.SaveChangesAsync(cancellationToken);
                }

                return await Result<int>.SuccessAsync(paymentId, "Payment deleted.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Payment deletion failed for Id {command.Id}.");
        }
    }
}
