using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using System.Globalization;

namespace RajMango.Application.Features.Commands
{
    internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IErrorHandler errorHandler,
                                         IDataContext dataContext,
                                         IMapper mapper)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var orderNumber = await GenerateOrderNumber();
                var orderSummary = OrderCalculator.CalculateTotals(command.OrderDetails);
                
                var newOrder = new Order
                {
                    UserId = command.UserId,
                    OrderNumber = orderNumber,
                    TotalQuantity = orderSummary.TotalQuantity,
                    TotalAmount = orderSummary.TotalAmount,
                    CreatedBy = command.UserId,
                };

                if (command.CourierStationId != null)
                {
                    newOrder.CourierStationId = command.CourierStationId;
                }
                else
                {
                    newOrder.FallbackAddress = command.FallbackAddress;
                }

                _dataContext.Get<Order>().Add(newOrder);

                await _dataContext.SaveChangesAsync(cancellationToken);

                foreach (var orderDetail in command.OrderDetails)
                {
                    var newOrderDetail = new OrderDetail
                    {
                        OrderId = newOrder.Id,
                        MangoTypeId = orderDetail.MangoTypeId,
                        CrateType = orderDetail.CrateType,
                        Quantity = orderDetail.Quantity,
                        UnitPrice = orderDetail.UnitPrice,
                        Discount = orderDetail.Discount,
                        TotalPrice = orderDetail.TotalPrice,
                        Note = orderDetail.Note,
                    };

                    newOrder.OrderDetails.Add(newOrderDetail);
                }

                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(newOrder.Id, "Order is Created.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Order Creation Failed");
        }

        public async Task<string> GenerateOrderNumber(DateTime? date = null)
        {
            var today = (date ?? Clock.Now()).Date;

            var countToday = await _dataContext.Get<Order>()
                                            .Where(x => x.OrderDate.Date == today)
                                            .CountAsync();

            var sequence = countToday + 1;
            var formattedDate = today.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
            var orderNumber = $"{formattedDate}{sequence:D2}";

            return orderNumber;
        }
    }
}
