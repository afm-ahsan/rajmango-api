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
    internal class CreateOrderForCustomerCommandHandler
        : IRequestHandler<CreateOrderForCustomerCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly INotificationService _notification;
        private readonly IRealtimeService _realtime;
        private readonly IOrderCreationLock _orderCreationLock;
        private readonly IOrderNumberService _orderNumberService;
        private readonly IOrderTrackingHistoryService _tracking;

        public CreateOrderForCustomerCommandHandler(
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

        public async Task<Result<int>> Handle(
            CreateOrderForCustomerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                // Permission: only admins may place orders on behalf of customers
                if (!_currentUserService.IsAdmin && !_currentUserService.IsSuperAdmin)
                    return await Result<int>.FailureAsync("Only admin users can place orders on behalf of customers.");

                // Validate the target customer exists and is active
                var targetUser = await _dataContext.Get<AppUser>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Id == command.TargetCustomerId && u.IsActive, cancellationToken);

                if (targetUser == null)
                    return await Result<int>.FailureAsync(
                        $"Customer with ID {command.TargetCustomerId} was not found or is inactive.");

                // ── Same mango-availability and courier-rate resolution as CreateOrderCommandHandler ──

                var today = Clock.Now().Date;
                var requestedMangoTypeIds = command.OrderDetails.Select(d => d.MangoTypeId).Distinct().ToList();

                // Admins can place orders with any mango type regardless of availability status.
                // Prefer Available price; fall back to any configured price for the type.
                var availabilities = await _dataContext.Get<MangoAvailability>()
                    .Include(a => a.MangoType)
                    .Where(a => requestedMangoTypeIds.Contains(a.MangoTypeId))
                    .ToListAsync(cancellationToken);

                var priceMap = availabilities
                    .GroupBy(a => a.MangoTypeId)
                    .ToDictionary(
                        g => g.Key,
                        g => g.OrderByDescending(a => a.Status == MangoAvailabilityStatus.Available ? 1 : 0)
                               .ThenByDescending(a => a.StartDate)
                               .First().PricePerKg);

                var unpricedIds = requestedMangoTypeIds.Where(id => !priceMap.ContainsKey(id)).ToList();
                if (unpricedIds.Any())
                {
                    var names = await _dataContext.Get<MangoType>()
                        .Where(m => unpricedIds.Contains(m.Id))
                        .Select(m => m.Name)
                        .ToListAsync(cancellationToken);
                    return await Result<int>.FailureAsync(
                        $"The following mango types have no configured price: {string.Join(", ", names)}. " +
                        "Please set up an availability record before placing this order.");
                }

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

                // ── Critical section: order number generation and persistence ──
                Order newOrder;
                using (await _orderCreationLock.AcquireAsync())
                {
                    var orderNumber = await _orderNumberService.GenerateAsync(cancellationToken);

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
                        // ── Key difference from CreateOrderCommandHandler ──
                        // The customer owns the order; the admin is recorded separately.
                        UserId               = command.TargetCustomerId,
                        PlacedByAdminUserId  = _currentUserService.UserId,
                        IsPlacedByAdmin      = true,

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
                    // AuditingHelper sets CreatedBy = _currentUserService.UserId (admin) automatically here

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

                // ── Best-effort side effects (failures must not roll back the order) ──

                try
                {
                    await _tracking.InsertIfNewAsync(newOrder.Id, "OrderPlaced", "Order Placed",
                        "Your order has been placed by an admin and is awaiting confirmation.", cancellationToken);
                }
                catch { /* tracking failure must not block order creation */ }

                // Notify the customer (not the admin) — this is their order
                await _notification.SendOrderConfirmedAsync(command.TargetCustomerId, newOrder.OrderNumber, cancellationToken);

                // Broadcast to all admin dashboards so the new order appears immediately
                await _realtime.SendToAdminsAsync(RealtimeEvents.OrderCreated,
                    new
                    {
                        OrderId       = newOrder.Id,
                        OrderNumber   = newOrder.OrderNumber,
                        UserId        = newOrder.UserId,
                        PlacedByAdmin = true,
                    },
                    cancellationToken);

                return await Result<int>.SuccessAsync(newOrder.Id,
                    $"Order {newOrder.OrderNumber} created for customer {targetUser.FirstName} {targetUser.LastName}.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync("Order creation failed.");
        }
    }
}
