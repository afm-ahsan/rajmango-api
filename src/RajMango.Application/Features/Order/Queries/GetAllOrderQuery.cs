using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs.Order;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetAllOrderQuery : IRequest<Result<List<OrderDto>>>;

    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, Result<List<OrderDto>>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetAllOrderQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<List<OrderDto>>> Handle(GetAllOrderQuery query, CancellationToken cancellationToken)
        {
            var orders = await _dataContext.Get<Order>()
                                             .Include(p => p.OrderDetails)
                                             .ToListAsync(cancellationToken);

            var orderList = new List<OrderDto>();
            foreach (var order in orders)
            {
                var orderDto = new OrderDto
                {
                    Id = order.Id,
                    OrderNumber = order.OrderNumber,
                    OrderDate = order.OrderDate,
                    TotalQuantity = order.TotalQuantity,
                    TotalAmount = order.TotalAmount,
                    OrderStatus = order.OrderStatus,
                    PaymentStatus = order.PaymentStatus,
                    PaidAmount = order.PaidAmount,
                    DueAmount = order.DueAmount,
                    IsValidOrder = order.IsValidOrder,
                    IsDelivered = order.IsDelivered,
                    DeliveryDate = order.DeliveryDate,
                    TrackingNumber = order.TrackingNumber,
                    CourierStationId = order.CourierStationId,
                    FallbackAddress = order.FallbackAddress,
                    UserId = order.UserId,

                    OrderDetails = order.OrderDetails.Select(p => new OrderDetailDto
                    {
                        Id = p.Id,
                        OrderId = p.OrderId,
                        MangoTypeId = p.MangoTypeId,
                        CrateType = p.CrateType,
                        Quantity = p.Quantity,
                        UnitPrice = p.UnitPrice,
                        Discount = p.Discount,
                        TotalPrice = p.TotalPrice,
                        Note = p.Note,
                    }).ToList(),
                };

                orderList.Add(orderDto);
            }

            return await Result<List<OrderDto>>.SuccessAsync(orderList);
        }
    }
}
