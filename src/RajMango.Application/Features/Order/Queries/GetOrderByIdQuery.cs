using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs.Order;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetOrderByIdQuery : IRequest<Result<OrderDto>>
    {
        public int Id { get; set; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<OrderDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<OrderDto>> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
        {
            var order = await _dataContext.Get<Order>()
                                          .Include(p => p.OrderDetails)
                                          .Include(p => p.CourierStation)
                                          .Include(p => p.CourierStation.CourierAreaMaps)
                                          .FirstOrDefaultAsync(p => p.Id == query.Id);

            if (order != null)
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

                if(order.CourierStationId != null)
                {
                    var courierArea = order.CourierStation.CourierAreaMaps.FirstOrDefault(p => p.CourierStationId == order.CourierStationId);
                    orderDto.Area = courierArea.Area;
                }
                else
                {
                    orderDto.Area = "Others";
                }

                return await Result<OrderDto>.SuccessAsync(orderDto);
            }
            return await Result<OrderDto>.SuccessAsync(new OrderDto());
        }
    }
}
