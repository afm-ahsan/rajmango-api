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
using System.Globalization;

namespace RajMango.Application.Features.Commands
{
    internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly INotificationService _notification;
        private readonly IRealtimeService _realtime;

        public CreateOrderCommandHandler(
            IErrorHandler errorHandler,
            IDataContext dataContext,
            ICurrentUserService currentUserService,
            INotificationService notification,
            IRealtimeService realtime)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _currentUserService = currentUserService;
            _notification = notification;
            _realtime = realtime;
        }

        public async Task<Result<int>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_currentUserService.IsAuthenticated || _currentUserService.UserId <= 0)
                    return await Result<int>.FailureAsync("An authenticated user is required to create an order.");

                var today = Clock.Now().Date;
                var requestedMangoTypeIds = command.OrderDetails.Select(d => d.MangoTypeId).Distinct().ToList();

                // Resolve active MangoAvailability for each requested mango type
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

                // Backend-authoritative prices: MangoTypeId → PricePerKg
                var priceMap = availabilities.ToDictionary(a => a.MangoTypeId, a => a.PricePerKg);

                var orderNumber  = await GenerateOrderNumber();
                var orderSummary = OrderCalculator.CalculateTotals(command.OrderDetails, priceMap);

                var newOrder = new Order
                {
                    UserId        = _currentUserService.UserId,
                    OrderNumber   = orderNumber,
                    TotalQuantity = orderSummary.TotalQuantity,
                    TotalAmount   = orderSummary.TotalAmount,
                    PaidAmount    = 0,
                    DueAmount     = orderSummary.TotalAmount,
                    ReceiverName  = command.ReceiverName,
                    ReceiverPhone = command.ReceiverPhone,
                    DeliveryNote  = command.DeliveryNote,
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

        private async Task<string> GenerateOrderNumber(DateTime? date = null)
        {
            var today = (date ?? Clock.Now()).Date;
            var countToday = await _dataContext.Get<Order>()
                .Where(x => x.OrderDate.Date == today)
                .CountAsync();
            var formattedDate = today.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
            return $"{formattedDate}{(countToday + 1):D2}";
        }
    }
}
