using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Queries
{
    public class OrderSummaryReportDto
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        // Counts
        public int TotalOrders { get; set; }
        public int PendingOrders { get; set; }
        public int ConfirmedOrders { get; set; }
        public int ProcessingOrders { get; set; }
        public int ShippedOrders { get; set; }
        public int DeliveredOrders { get; set; }
        public int CancelledOrders { get; set; }
        public int ReturnedOrders { get; set; }

        // Revenue (excludes cancelled/returned)
        public decimal TotalRevenue { get; set; }
        public decimal TotalCollected { get; set; }
        public decimal TotalOutstanding { get; set; }

        public List<OrderSummaryLineDto> Orders { get; set; } = new();
    }

    public class OrderSummaryLineDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }

    public record GetOrderSummaryReportQuery : IRequest<Result<OrderSummaryReportDto>>
    {
        public DateTime From { get; init; }
        public DateTime To { get; init; }
    }

    public class GetOrderSummaryReportQueryHandler : IRequestHandler<GetOrderSummaryReportQuery, Result<OrderSummaryReportDto>>
    {
        private readonly IDataContext _dataContext;

        public GetOrderSummaryReportQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<OrderSummaryReportDto>> Handle(GetOrderSummaryReportQuery query, CancellationToken cancellationToken)
        {
            var from = query.From.Date;
            var to   = query.To.Date.AddDays(1).AddTicks(-1); // inclusive end of day

            var orders = await _dataContext.Get<Order>()
                .Include(o => o.AppUser)
                .Where(o => o.OrderDate >= from && o.OrderDate <= to)
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new OrderSummaryLineDto
                {
                    Id            = o.Id,
                    OrderNumber   = o.OrderNumber,
                    OrderDate     = o.OrderDate,
                    CustomerName  = o.AppUser.FirstName + " " + o.AppUser.LastName,
                    TotalQuantity = o.TotalQuantity,
                    TotalAmount   = o.TotalAmount,
                    PaidAmount    = o.PaidAmount,
                    DueAmount     = o.DueAmount,
                    OrderStatus   = o.OrderStatus,
                    PaymentStatus = o.PaymentStatus,
                })
                .ToListAsync(cancellationToken);

            var active = orders
                .Where(o => o.OrderStatus != OrderStatus.Cancelled && o.OrderStatus != OrderStatus.Returned)
                .ToList();

            var dto = new OrderSummaryReportDto
            {
                From              = query.From.Date,
                To                = query.To.Date,
                TotalOrders       = orders.Count,
                PendingOrders     = orders.Count(o => o.OrderStatus == OrderStatus.Pending),
                ConfirmedOrders   = orders.Count(o => o.OrderStatus == OrderStatus.Confirmed),
                ProcessingOrders  = orders.Count(o => o.OrderStatus == OrderStatus.Processing),
                ShippedOrders     = orders.Count(o => o.OrderStatus == OrderStatus.Shipped),
                DeliveredOrders   = orders.Count(o => o.OrderStatus == OrderStatus.Delivered),
                CancelledOrders   = orders.Count(o => o.OrderStatus == OrderStatus.Cancelled),
                ReturnedOrders    = orders.Count(o => o.OrderStatus == OrderStatus.Returned),
                TotalRevenue      = active.Sum(o => o.TotalAmount),
                TotalCollected    = active.Sum(o => o.PaidAmount),
                TotalOutstanding  = active.Sum(o => o.DueAmount),
                Orders            = orders,
            };

            return await Result<OrderSummaryReportDto>.SuccessAsync(dto);
        }
    }
}
