using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Common;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    internal class UpdateAdminOrderStatusCommandHandler : IRequestHandler<UpdateAdminOrderStatusCommand, Result<int>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IRealtimeService _realtime;
        private readonly IErrorHandler _errorHandler;

        public UpdateAdminOrderStatusCommandHandler(
            IDataContext dataContext,
            ICurrentUserService currentUserService,
            IRealtimeService realtime,
            IErrorHandler errorHandler)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
            _realtime = realtime;
            _errorHandler = errorHandler;
        }

        public async Task<Result<int>> Handle(UpdateAdminOrderStatusCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_currentUserService.IsAdmin && !_currentUserService.IsSuperAdmin)
                    return await Result<int>.FailureAsync("Access denied.");

                var order = await _dataContext.Get<Order>()
                    .Include(o => o.OrderDetails)
                    .FirstOrDefaultAsync(o => o.Id == command.Id, cancellationToken);

                if (order == null)
                    return await Result<int>.FailureAsync($"Order not found with Id {command.Id}.");

                // Guard: cancelled order cannot become Delivered
                if (order.OrderStatus == OrderStatus.Cancelled && command.DeliveryStatus == DeliveryStatus.Delivered)
                    return await Result<int>.FailureAsync("A cancelled order cannot be marked as Delivered.");

                // Guard: delivered order cannot be cancelled (use return/refund workflow)
                if (order.DeliveryStatus == DeliveryStatus.Delivered && command.OrderStatus == OrderStatus.Cancelled)
                    return await Result<int>.FailureAsync(
                        "A delivered order cannot be cancelled directly. Use the return/refund workflow.");

                // Guard: delivered requires paid payment
                if (command.DeliveryStatus == DeliveryStatus.Delivered && command.PaymentStatus != PaymentStatus.Paid)
                    return await Result<int>.FailureAsync(
                        "Order cannot be marked as Delivered: payment status must be Paid.");

                order.OrderStatus = command.OrderStatus;
                order.PaymentStatus = command.PaymentStatus;
                order.DeliveryStatus = command.DeliveryStatus;

                if (command.DeliveryStatus == DeliveryStatus.Dispatched || 
                    command.DeliveryStatus == DeliveryStatus.InTransit || 
                    command.DeliveryStatus == DeliveryStatus.Delivered)
                {
                    var deliveredAt = command.DeliveryDate ?? Clock.Now();
                    var isDelivered = command.DeliveryStatus == DeliveryStatus.Delivered ? true : false;
                    order.IsDelivered = isDelivered;
                    order.DeliveryDate = deliveredAt;

                    foreach (var detail in order.OrderDetails)
                    {
                        detail.IsDelivered = isDelivered;
                        detail.DeliveryDate = deliveredAt;
                    }
                }
                else
                {
                    order.IsDelivered = false;
                    order.DeliveryDate = null;

                    foreach (var detail in order.OrderDetails)
                    {
                        detail.IsDelivered = false;
                        detail.DeliveryDate = null;
                    }
                }

                // All entities loaded via Include are change-tracked; SaveChanges detects all modifications.
                _dataContext.Get<Order>().Update(order);
                await _dataContext.SaveChangesAsync(cancellationToken);

                var payload = new
                {
                    OrderId = order.Id,
                    OrderNumber = order.OrderNumber,
                    Status = command.OrderStatus.ToString(),
                    UserId = order.UserId,
                };
                await _realtime.SendToUserAsync(order.UserId, RealtimeEvents.OrderStatusUpdated, payload, cancellationToken);
                await _realtime.SendToAdminsAsync(RealtimeEvents.OrderStatusUpdated, payload, cancellationToken);

                return await Result<int>.SuccessAsync(order.Id, "Order statuses updated successfully.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Failed to update order statuses for Id {command.Id}.");
        }
    }
}
