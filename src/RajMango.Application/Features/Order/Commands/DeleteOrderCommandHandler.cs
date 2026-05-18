using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public DeleteOrderCommandHandler(
            IErrorHandler errorHandler,
            IDataContext dataContext,
            ICurrentUserService currentUserService)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<int>> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _dataContext.Get<Order>().FindAsync(command.Id);
                if (order == null)
                    return await Result<int>.FailureAsync($"Order not found with Id {command.Id}.");

                var isPrivileged = _currentUserService.IsAdmin || _currentUserService.IsSuperAdmin;

                if (!isPrivileged)
                {
                    if (order.UserId != _currentUserService.UserId)
                        return await Result<int>.FailureAsync("You are not authorized to delete this order.");

                    if (order.OrderStatus != OrderStatus.Pending)
                        return await Result<int>.FailureAsync(
                            $"Order {order.OrderNumber} can no longer be deleted. Only pending orders can be removed.");
                }

                var orderDetails = await _dataContext.Get<OrderDetail>()
                    .Where(p => p.OrderId == command.Id)
                    .ToListAsync(cancellationToken);

                foreach (var detail in orderDetails)
                    _dataContext.Get<OrderDetail>().Remove(detail);

                _dataContext.Get<Order>().Remove(order);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(order.Id, "Order deleted.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }

            return await Result<int>.FailureAsync($"Order deletion failed for Id {command.Id}.");
        }
    }
}
