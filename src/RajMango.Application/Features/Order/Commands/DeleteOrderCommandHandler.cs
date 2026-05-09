using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public DeleteOrderCommandHandler(IErrorHandler errorHandler, IDataContext dataContext)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
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

                    _dataContext.Get<Order>().Remove(order);

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(order.Id, "Order is Deleted.");
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
