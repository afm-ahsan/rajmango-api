using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs.Order;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetAllOrderQuery : IRequest<Result<List<OrderDto>>>;

    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, Result<List<OrderDto>>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetAllOrderQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<List<OrderDto>>> Handle(GetAllOrderQuery query, CancellationToken cancellationToken)
        {
            var orderQuery = _dataContext.Get<Order>()
                                         .Include(o => o.OrderDetails)
                                         .AsQueryable();

            if (!_currentUserService.IsAdmin)
                orderQuery = orderQuery.Where(o => o.UserId == _currentUserService.UserId);

            var orders = await orderQuery
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new OrderDto
                {
                    Id               = o.Id,
                    OrderNumber      = o.OrderNumber,
                    OrderDate        = o.OrderDate,
                    TotalQuantity    = o.TotalQuantity,
                    TotalAmount      = o.TotalAmount,
                    OrderStatus      = o.OrderStatus,
                    PaymentStatus    = o.PaymentStatus,
                    PaidAmount       = o.PaidAmount,
                    DueAmount        = o.DueAmount,
                    IsValidOrder     = o.IsValidOrder,
                    IsDelivered      = o.IsDelivered,
                    DeliveryDate     = o.DeliveryDate,
                    TrackingNumber   = o.TrackingNumber,
                    CourierStationId = o.CourierStationId,
                    FallbackAddress  = o.FallbackAddress,
                    ReceiverName     = o.ReceiverName,
                    ReceiverPhone    = o.ReceiverPhone,
                    DeliveryNote     = o.DeliveryNote,
                    UserId           = o.UserId,
                    OrderDetails = o.OrderDetails.Select(d => new OrderDetailDto
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
                })
                .ToListAsync(cancellationToken);

            return await Result<List<OrderDto>>.SuccessAsync(orders);
        }
    }
}
