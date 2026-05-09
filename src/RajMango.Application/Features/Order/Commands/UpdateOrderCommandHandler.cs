using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;
using RajMango.Shared.Utils;

namespace RajMango.Application.Features.Commands
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public UpdateOrderCommandHandler(IErrorHandler errorHandler, IDataContext dataContext)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _dataContext.Get<Order>().FindAsync(new object[] { command.Id }, cancellationToken);
                if (order == null)
                    return await Result<int>.FailureAsync($"Order not found with Id {command.Id}.");

                if (order.OrderStatus is OrderStatus.Shipped
                                      or OrderStatus.Delivered
                                      or OrderStatus.Cancelled
                                      or OrderStatus.Returned
                                      or OrderStatus.Failed)
                {
                    return await Result<int>.FailureAsync(
                        $"Order {order.OrderNumber} cannot be modified in {order.OrderStatus} status.");
                }

                var today = Clock.Now().Date;
                var requestedMangoTypeIds = command.OrderDetails.Select(d => d.MangoTypeId).Distinct().ToList();

                var availabilities = await _dataContext.Get<MangoAvailability>()
                    .Include(a => a.MangoType)
                    .Where(a => requestedMangoTypeIds.Contains(a.MangoTypeId)
                             && a.Status == MangoAvailabilityStatus.Available
                             && a.StartDate.Date <= today
                             && a.EndDate.Date >= today)
                    .ToListAsync(cancellationToken);

                var availableMangoTypeIds = availabilities.Select(a => a.MangoTypeId).ToHashSet();
                var unavailableIds = requestedMangoTypeIds.Where(id => !availableMangoTypeIds.Contains(id)).ToList();

                if (unavailableIds.Any())
                {
                    var names = await _dataContext.Get<MangoType>()
                        .Where(m => unavailableIds.Contains(m.Id))
                        .Select(m => m.Name)
                        .ToListAsync(cancellationToken);
                    return await Result<int>.FailureAsync(
                        $"The following mango types are not currently available: {string.Join(", ", names)}.");
                }

                var priceMap     = availabilities.ToDictionary(a => a.MangoTypeId, a => a.PricePerKg);
                var orderSummary = OrderCalculator.CalculateTotals(command.OrderDetails, priceMap);

                // Replace all existing order details
                var existingDetails = await _dataContext.Get<OrderDetail>()
                    .Where(d => d.OrderId == command.Id)
                    .ToListAsync(cancellationToken);
                foreach (var d in existingDetails)
                    _dataContext.Get<OrderDetail>().Remove(d);

                order.TotalQuantity = orderSummary.TotalQuantity;
                order.TotalAmount   = orderSummary.TotalAmount;
                order.DueAmount     = orderSummary.TotalAmount - order.PaidAmount;
                order.UpdatedBy     = command.UserId;
                order.UpdatedAt     = Clock.Now();

                if (command.CourierStationId != null)
                {
                    order.CourierStationId = command.CourierStationId;
                    order.FallbackAddress  = null;
                }
                else
                {
                    order.CourierStationId = null;
                    order.FallbackAddress  = command.FallbackAddress;
                }

                foreach (var detail in command.OrderDetails)
                {
                    var crateWeight = DomainUtils.GetCrateWeight(detail.CrateType);
                    var pricePerKg  = priceMap[detail.MangoTypeId];
                    var lineKg      = detail.Quantity * crateWeight;

                    order.OrderDetails.Add(new OrderDetail
                    {
                        OrderId     = order.Id,
                        MangoTypeId = detail.MangoTypeId,
                        CrateType   = detail.CrateType,
                        Quantity    = detail.Quantity,
                        UnitPrice   = pricePerKg,
                        Discount    = detail.Discount,
                        TotalPrice  = lineKg * pricePerKg - detail.Discount,
                        Note        = detail.Note,
                    });
                }

                _dataContext.Get<Order>().Update(order);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(order.Id, "Order updated.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Order update failed for Id {command.Id}.");
        }
    }
}
