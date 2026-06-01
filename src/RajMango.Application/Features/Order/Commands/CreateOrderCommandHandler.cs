using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Common;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;
using RajMango.Shared.Utils;

namespace RajMango.Application.Features.Commands
{
    internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly INotificationService _notification;
        private readonly IRealtimeService _realtime;
        private readonly IOrderCreationLock _orderCreationLock;
        private readonly IOrderNumberService _orderNumberService;
        private readonly IOrderTrackingHistoryService _tracking;

        public CreateOrderCommandHandler(
            IErrorHandler errorHandler,
            IDataContext dataContext,
            ICurrentUserService currentUserService,
            INotificationService notification,
            IRealtimeService realtime,
            IOrderCreationLock orderCreationLock,
            IOrderNumberService orderNumberService,
            IOrderTrackingHistoryService tracking)
        {
            _errorHandler       = errorHandler;
            _dataContext        = dataContext;
            _currentUserService = currentUserService;
            _notification       = notification;
            _realtime           = realtime;
            _orderCreationLock  = orderCreationLock;
            _orderNumberService = orderNumberService;
            _tracking           = tracking;
        }

        public async Task<Result<int>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_currentUserService.IsAuthenticated || _currentUserService.UserId <= 0)
                    return await Result<int>.FailureAsync("An authenticated user is required to create an order.");

                var today = Clock.Now().Date;
                var requestedMangoTypeIds = command.OrderDetails.Select(d => d.MangoTypeId).Distinct().ToList();

                // Resolve active MangoAvailability for each requested mango type (read-only, outside lock)
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

                // Critical section: order number generation and persistence are serialized
                Order newOrder;
                using (await _orderCreationLock.AcquireAsync())
                {
                    var orderNumber = await _orderNumberService.GenerateAsync(cancellationToken);

                    // Pre-calculate weight so courier charge can be computed
                    var totalWeightKg = command.OrderDetails.Sum(d => d.Quantity * DomainUtils.GetCrateWeight(d.CrateType));

                    decimal courierCharge = 0m;
                    decimal ratePerKg = 0m;
                    if (courierRate != null)
                    {
                        ratePerKg     = courierRate.RatePerKg;
                        courierCharge = OrderCalculator.CalculateCourierCharge(totalWeightKg, ratePerKg, courierRate.MinimumCharge);
                    }

                    var orderSummary = OrderCalculator.CalculateTotals(command.OrderDetails, priceMap, courierCharge);

                    newOrder = new Order
                    {
                        UserId               = _currentUserService.UserId,
                        OrderNumber          = orderNumber,
                        TotalQuantity        = orderSummary.TotalQuantity,
                        ProductTotalAmount   = orderSummary.ProductTotalAmount,
                        CourierLocationType  = resolvedLocationType,
                        CourierProviderId    = resolvedCourierProviderId,
                        CourierRatePerKg     = ratePerKg,
                        CourierCharge        = courierCharge,
                        TotalAmount          = orderSummary.TotalAmount,
                        PaidAmount           = 0,
                        DueAmount            = orderSummary.TotalAmount,
                        ReceiverType         = command.ReceiverType,
                        ReceiverName         = command.ReceiverName,
                        ReceiverMobileNumber = command.ReceiverMobileNumber,
                        DeliveryNote         = command.DeliveryNote,
                    };

                    if (command.CourierStationId != null)
                        newOrder.CourierStationId = command.CourierStationId;
                    else
                        newOrder.FallbackAddress = command.FallbackAddress;

                    _dataContext.Get<Order>().Add(newOrder);
                    await _dataContext.SaveChangesAsync(cancellationToken);

                    foreach (var detail in command.OrderDetails)
                    {
                        var crateWeight = DomainUtils.GetCrateWeight(detail.CrateType);
                        var pricePerKg  = priceMap[detail.MangoTypeId];
                        var lineKg      = detail.Quantity * crateWeight;

                        newOrder.OrderDetails.Add(new OrderDetail
                        {
                            OrderId     = newOrder.Id,
                            MangoTypeId = detail.MangoTypeId,
                            CrateType   = detail.CrateType,
                            Quantity    = detail.Quantity,
                            UnitPrice   = pricePerKg,
                            Discount    = detail.Discount,
                            TotalPrice  = lineKg * pricePerKg - detail.Discount,
                            Note        = detail.Note,
                        });
                    }

                    await _dataContext.SaveChangesAsync(cancellationToken);
                }

                try
                {
                    await _tracking.InsertIfNewAsync(newOrder.Id, "OrderPlaced", "Order Placed",
                        "Your order has been placed and is awaiting confirmation.", cancellationToken);
                }
                catch { /* tracking failure must not block order creation */ }

                await _notification.SendOrderConfirmedAsync(newOrder.UserId, newOrder.OrderNumber, cancellationToken);
                await _realtime.SendToAdminsAsync(RealtimeEvents.OrderCreated,
                    new { OrderId = newOrder.Id, OrderNumber = newOrder.OrderNumber, UserId = newOrder.UserId },
                    cancellationToken);

                return await Result<int>.SuccessAsync(newOrder.Id, "Order created.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync("Order creation failed.");
        }
    }
}
