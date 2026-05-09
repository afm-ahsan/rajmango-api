using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IErrorHandler errorHandler, IDataContext dataContext, IMapper mapper)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _dataContext.Get<Order>().FindAsync(command.Id);
                if (order != null)
                {
                    var orderDetails = await _dataContext.Get<OrderDetail>().Where(p => p.OrderId == command.Id).ToListAsync();
                    foreach (var orderDetail in orderDetails)
                    {
                        _dataContext.Get<OrderDetail>().Remove(orderDetail);
                    }

                    var orderSummary = OrderCalculator.CalculateTotals(command.OrderDetails);

                    order.TotalQuantity = orderSummary.TotalQuantity;
                    order.TotalAmount = orderSummary.TotalAmount;
                    order.UpdatedBy = command.UserId;

                    if (command.CourierStationId != null)
                    {
                        order.CourierStationId = command.CourierStationId;
                        order.FallbackAddress = null;
                    }
                    else
                    {
                        order.CourierStationId = null;
                        order.FallbackAddress = command.FallbackAddress;
                    }

                    foreach (var orderDetail in command.OrderDetails)
                    {
                        var newOrderDetail = new OrderDetail
                        {
                            OrderId = order.Id,
                            MangoTypeId = orderDetail.MangoTypeId,
                            CrateType = orderDetail.CrateType,
                            Quantity = orderDetail.Quantity,
                            UnitPrice = orderDetail.UnitPrice,
                            Discount = orderDetail.Discount,
                            TotalPrice = orderDetail.TotalPrice,
                            Note = orderDetail.Note,
                        };

                        order.OrderDetails.Add(newOrderDetail);
                    }

                    _dataContext.Get<Order>().Update(order);

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(order.Id, "Order is Updated.");
                }
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Order information not found with the Id - {command.Id}");
        }
    }
}
