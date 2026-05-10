using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs.Order;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetOrderByIdQuery(int Id) : IRequest<Result<OrderDto>>;

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<OrderDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetOrderByIdQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<OrderDto>> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
        {
            var orderQuery = _dataContext.Get<Order>()
                                          .Include(o => o.OrderDetails)
                                          .Include(o => o.CourierStation)
                                              .ThenInclude(cs => cs.CourierAreaMaps)
                                          .Where(o => o.Id == query.Id);

            if (!_currentUserService.IsAdmin)
                orderQuery = orderQuery.Where(o => o.UserId == _currentUserService.UserId);

            var order = await orderQuery.FirstOrDefaultAsync(cancellationToken);

            if (order == null)
                return await Result<OrderDto>.FailureAsync("Order not found.");

            var orderDto = new OrderDto
            {
                Id               = order.Id,
                OrderNumber      = order.OrderNumber,
                OrderDate        = order.OrderDate,
                TotalQuantity    = order.TotalQuantity,
                TotalAmount      = order.TotalAmount,
                OrderStatus      = order.OrderStatus,
                PaymentStatus    = order.PaymentStatus,
                PaidAmount       = order.PaidAmount,
                DueAmount        = order.DueAmount,
                IsValidOrder     = order.IsValidOrder,
                IsDelivered      = order.IsDelivered,
                DeliveryDate     = order.DeliveryDate,
                TrackingNumber   = order.TrackingNumber,
                CourierStationId = order.CourierStationId,
                FallbackAddress  = order.FallbackAddress,
                ReceiverName     = order.ReceiverName,
                ReceiverPhone    = order.ReceiverPhone,
                DeliveryNote     = order.DeliveryNote,
                UserId           = order.UserId,
                OrderDetails = order.OrderDetails.Select(d => new OrderDetailDto
                {
                    Id          = d.Id,
                    OrderId     = d.OrderId,
                    MangoTypeId = d.MangoTypeId,
                    CrateType   = d.CrateType,
                    Quantity    = d.Quantity,
                    UnitPrice   = d.UnitPrice,
                    Discount    = d.Discount,
                    TotalPrice  = d.TotalPrice,
                    Note        = d.Note,
                }).ToList(),
            };

            if (order.CourierStationId != null)
            {
                var courierArea = order.CourierStation?.CourierAreaMaps
                    .FirstOrDefault(c => c.CourierStationId == order.CourierStationId);
                orderDto.Area = courierArea?.Area;
            }
            else
            {
                orderDto.Area = "Others";
            }

            return await Result<OrderDto>.SuccessAsync(orderDto);
        }
    }
}
