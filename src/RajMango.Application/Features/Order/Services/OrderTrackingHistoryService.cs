using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;

namespace RajMango.Application.Features.Services
{
    public class OrderTrackingHistoryService : IOrderTrackingHistoryService
    {
        private readonly IDataContext _dataContext;

        public OrderTrackingHistoryService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task InsertIfNewAsync(int orderId, string trackingStatus, string title, string description, CancellationToken cancellationToken)
        {
            var exists = await _dataContext.Get<OrderTrackingHistory>()
                .AnyAsync(h => h.OrderId == orderId && h.TrackingStatus == trackingStatus, cancellationToken);

            if (exists) return;

            _dataContext.Get<OrderTrackingHistory>().Add(new OrderTrackingHistory
            {
                OrderId       = orderId,
                TrackingStatus = trackingStatus,
                Title         = title,
                Description   = description,
            });

            await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}
