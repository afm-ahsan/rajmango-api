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
        private readonly ICurrentUserService _currentUserService;

        public UpdateOrderCommandHandler(
            IErrorHandler errorHandler,
            IDataContext dataContext,
            ICurrentUserService currentUserService)
        {
            _errorHandler       = errorHandler;
            _dataContext        = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<int>> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _dataContext.Get<Order>().FindAsync(new object[] { command.Id }, cancellationToken);
                if (order == null)
                    return await Result<int>.FailureAsync($"Order not found with Id {command.Id}.");

                var isPrivileged = _currentUserService.IsAdmin || _currentUserService.IsSuperAdmin;

                if (!isPrivileged)
                {
                    if (order.UserId != _currentUserService.UserId)
                        return await Result<int>.FailureAsync("You are not authorized to edit this order.");

                    if (order.OrderStatus != OrderStatus.Pending)
                        return await Result<int>.FailureAsync(
                            $"Order {order.OrderNumber} can no longer be edited. Only pending orders can be modified.");
                }

                // Admins may edit any order regardless of status (e.g. correcting a delivered order).
                // Customers are blocked on terminal statuses — they may only edit Pending orders.
                if (!isPrivileged
                    && order.OrderStatus is OrderStatus.Shipped
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
                             && a.Status == MangoAvailabilityStatus.Available)
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

                var priceMap = availabilities.ToDictionary(a => a.MangoTypeId, a => a.PricePerKg);

                // Resolve courier rate from station (if provided)
                CourierRateConfiguration courierRate = null;
                CourierLocationType? resolvedLocationType = null;
                int? resolvedCourierProviderId = null;

                if (command.CourierStationId.HasValue)
                {
                    var station = await _dataContext.Get<CourierStation>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(s => s.Id == command.CourierStationId.Value, cancellationToken);

                    if (station != null)
                    {
                        resolvedCourierProviderId = station.CourierProviderId;
                        resolvedLocationType = string.Equals(station.City, "Dhaka", StringComparison.OrdinalIgnoreCase)
                            ? CourierLocationType.InsideDhaka
                            : CourierLocationType.OutsideDhaka;

                        courierRate = await _dataContext.Get<CourierRateConfiguration>()
                            .AsNoTracking()
                            .FirstOrDefaultAsync(
                                r => r.CourierProviderId   == station.CourierProviderId
                                  && r.CourierLocationType == resolvedLocationType
                                  && r.IsActive,
                                cancellationToken);
                    }
                }

                // Pre-calculate weight so courier charge can be computed
                var totalWeightKg = command.OrderDetails.Sum(d => d.Quantity * DomainUtils.GetCrateWeight(d.CrateType));

                decimal courierCharge = 0m;
                decimal ratePerKg = 0m;
                if (courierRate != null)
                {
                    ratePerKg     = courierRate.RatePerKg;
                    courierCharge = OrderCalculator.CalculateCourierCharge(totalWeightKg, ratePerKg, courierRate.MinimumCharge);
                }

                // If admin has already set an override, keep the override; recalculate product total only.
                // The override amount is not touched on a regular update.
                decimal finalCourierCharge = order.IsCourierChargeOverridden && order.CourierChargeOverrideAmount.HasValue
                    ? order.CourierChargeOverrideAmount.Value
                    : courierCharge;

                var orderSummary = OrderCalculator.CalculateTotals(command.OrderDetails, priceMap, finalCourierCharge);

                // Replace all existing order details
                var existingDetails = await _dataContext.Get<OrderDetail>()
                    .Where(d => d.OrderId == command.Id)
                    .ToListAsync(cancellationToken);
                foreach (var d in existingDetails)
                    _dataContext.Get<OrderDetail>().Remove(d);

                order.TotalQuantity        = orderSummary.TotalQuantity;
                order.ProductTotalAmount   = orderSummary.ProductTotalAmount;
                order.CourierLocationType  = resolvedLocationType;
                order.CourierProviderId    = resolvedCourierProviderId;
                order.CourierRatePerKg     = ratePerKg;
                order.CourierCharge        = courierCharge;
                order.TotalAmount          = orderSummary.TotalAmount;
                order.DueAmount            = orderSummary.TotalAmount - order.PaidAmount;
                order.ReceiverType         = command.ReceiverType;
                order.ReceiverName         = command.ReceiverName;
                order.ReceiverMobileNumber = command.ReceiverMobileNumber;
                order.DeliveryNote         = command.DeliveryNote;

                if (command.CourierStationId != null)
                {
                    order.CourierStationId = command.CourierStationId;
                    order.FallbackAddress  = null;
                }
                else
                {
                    order.CourierStationId    = null;
                    order.CourierProviderId   = null;
                    order.CourierLocationType = null;
                    order.FallbackAddress     = command.FallbackAddress;
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
