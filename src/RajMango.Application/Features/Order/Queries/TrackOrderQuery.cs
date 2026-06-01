using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs.Order;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Utils;

namespace RajMango.Application.Features.Queries
{
    public record TrackOrderQuery : IRequest<Result<OrderTrackingDto>>
    {
        public string OrderNumber { get; init; }
        public string PhoneNumber { get; init; }
    }

    public class TrackOrderQueryHandler : IRequestHandler<TrackOrderQuery, Result<OrderTrackingDto>>
    {
        private readonly IDataContext _dataContext;

        public TrackOrderQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<OrderTrackingDto>> Handle(TrackOrderQuery query, CancellationToken cancellationToken)
        {
            var order = await _dataContext.Get<Domain.Entities.Order>()
                .Include(o => o.AppUser)
                .Include(o => o.CourierStation)
                    .ThenInclude(cs => cs.CourierProvider)
                .Where(o => o.OrderNumber == query.OrderNumber)
                .FirstOrDefaultAsync(cancellationToken);

            if (order == null)
                return await Result<OrderTrackingDto>.FailureAsync("Order not found or phone number does not match.");

            var normalizedInput    = DomainUtils.NormalizeBangladeshPhone(query.PhoneNumber);
            var normalizedCustomer = DomainUtils.NormalizeBangladeshPhone(order.AppUser?.PhoneNumber);
            var normalizedReceiver = DomainUtils.NormalizeBangladeshPhone(order.ReceiverMobileNumber);

            bool phoneMatches = (!string.IsNullOrEmpty(normalizedInput) && normalizedInput == normalizedCustomer)
                             || (!string.IsNullOrEmpty(normalizedInput) && normalizedInput == normalizedReceiver);

            if (!phoneMatches)
                return await Result<OrderTrackingDto>.FailureAsync("Order not found or phone number does not match.");

            var timeline = await _dataContext.Get<OrderTrackingHistory>()
                .Where(h => h.OrderId == order.Id)
                .OrderBy(h => h.CreatedAt)
                .ToListAsync(cancellationToken);

            var dto = new OrderTrackingDto
            {
                OrderNumber         = order.OrderNumber,
                OrderDate           = order.OrderDate,
                CustomerName        = order.AppUser != null
                    ? $"{order.AppUser.FirstName} {order.AppUser.LastName}"
                    : null,
                ReceiverName        = order.ReceiverName,
                DeliveryArea        = order.CourierStation?.Area,
                CourierProviderName = order.CourierStation?.CourierProvider?.Name,
                CourierStationName  = order.CourierStation != null
                    ? $"{order.CourierStation.CourierProvider?.Name} - {order.CourierStation.Name} ({order.CourierStation.City})"
                    : null,
                TotalQuantity       = order.TotalQuantity,
                TotalAmount         = order.TotalAmount,
                OrderStatus         = order.OrderStatus,
                PaymentStatus       = order.PaymentStatus,
                DeliveryStatus      = order.DeliveryStatus,
                DeliveryDate        = order.DeliveryDate,
                Timeline            = timeline.Select(h => new OrderTrackingTimelineItemDto
                {
                    TrackingStatus = h.TrackingStatus,
                    Title          = h.Title,
                    Description    = h.Description,
                    CreatedAt      = h.CreatedAt,
                }).ToList(),
            };

            return await Result<OrderTrackingDto>.SuccessAsync(dto);
        }
    }
}
