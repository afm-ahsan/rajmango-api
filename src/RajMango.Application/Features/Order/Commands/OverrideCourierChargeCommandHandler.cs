using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    internal class OverrideCourierChargeCommandHandler : IRequestHandler<OverrideCourierChargeCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public OverrideCourierChargeCommandHandler(
            IErrorHandler errorHandler,
            IDataContext dataContext,
            ICurrentUserService currentUserService)
        {
            _errorHandler        = errorHandler;
            _dataContext         = dataContext;
            _currentUserService  = currentUserService;
        }

        public async Task<Result<int>> Handle(OverrideCourierChargeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_currentUserService.IsAdmin && !_currentUserService.IsSuperAdmin)
                    return await Result<int>.FailureAsync("Only administrators can override courier charges.");

                if (command.CourierChargeOverrideAmount < 0)
                    return await Result<int>.FailureAsync("Override amount cannot be negative.");

                var order = await _dataContext.Get<Order>()
                    .FindAsync(new object[] { command.OrderId }, cancellationToken);

                if (order == null)
                    return await Result<int>.FailureAsync($"Order not found with Id {command.OrderId}.");

                if (order.OrderStatus is OrderStatus.Delivered
                                      or OrderStatus.Cancelled
                                      or OrderStatus.Returned
                                      or OrderStatus.Failed)
                {
                    return await Result<int>.FailureAsync(
                        $"Courier charge cannot be overridden for an order in {order.OrderStatus} status.");
                }

                order.CourierChargeOverrideAmount = command.CourierChargeOverrideAmount;
                order.IsCourierChargeOverridden   = true;
                order.CourierChargeNote           = command.CourierChargeNote;

                var finalCourierCharge = command.CourierChargeOverrideAmount;
                order.TotalAmount = order.ProductTotalAmount + finalCourierCharge;
                order.DueAmount   = order.TotalAmount - order.PaidAmount;

                _dataContext.Get<Order>().Update(order);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(order.Id, "Courier charge overridden successfully.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Courier charge override failed for Order Id {command.OrderId}.");
        }
    }
}
