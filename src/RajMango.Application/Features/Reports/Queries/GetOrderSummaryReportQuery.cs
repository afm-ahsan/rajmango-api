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

        // Pagination over Orders (reflects the filtered set, not just TotalOrders above which is also filtered)
        public int OrdersTotalCount { get; set; }
        public int OrdersPageNumber { get; set; }
        public int OrdersPageSize { get; set; }
    }

    public class OrderSummaryLineDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string MangoTypeNames { get; set; }
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

        public string CustomerName { get; init; }
        public OrderStatus? OrderStatus { get; init; }
        public PaymentStatus? PaymentStatus { get; init; }
        public DeliveryStatus? DeliveryStatus { get; init; }
        public string MangoType { get; init; }

        /// <summary>1-based page number for the Orders line list. Ignored when PageSize &lt;= 0.</summary>
        public int PageNumber { get; init; } = 1;
        /// <summary>Page size for the Orders line list. 0 or less returns the full filtered set (used for exports).</summary>
        public int PageSize { get; init; } = 10;
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

            var orderQuery = _dataContext.Get<Order>()
                .Include(o => o.AppUser)
                .Where(o => o.OrderDate >= from && o.OrderDate <= to);

            if (!string.IsNullOrWhiteSpace(query.CustomerName))
                orderQuery = orderQuery.Where(o => (o.AppUser.FirstName + " " + o.AppUser.LastName).Contains(query.CustomerName));

            if (query.OrderStatus.HasValue)
                orderQuery = orderQuery.Where(o => o.OrderStatus == query.OrderStatus.Value);

            if (query.PaymentStatus.HasValue)
                orderQuery = orderQuery.Where(o => o.PaymentStatus == query.PaymentStatus.Value);

            if (query.DeliveryStatus.HasValue)
                orderQuery = orderQuery.Where(o => o.DeliveryStatus == query.DeliveryStatus.Value);

            if (!string.IsNullOrWhiteSpace(query.MangoType))
                orderQuery = orderQuery.Where(o => o.OrderDetails.Any(od => od.MangoType.Name.Contains(query.MangoType)));

            // Single query for the whole filtered set (dataset is small for a seasonal business) —
            // avoids N+1 and lets summary cards reflect the full filtered set, not just the displayed page.
            var rawLines = await orderQuery
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new
                {
                    o.Id,
                    o.OrderNumber,
                    o.OrderDate,
                    CustomerName = o.AppUser.FirstName + " " + o.AppUser.LastName,
                    MangoTypeNames = o.OrderDetails.Select(od => od.MangoType.Name),
                    o.TotalQuantity,
                    o.TotalAmount,
                    o.PaidAmount,
                    o.DueAmount,
                    o.OrderStatus,
                    o.PaymentStatus,
                })
                .ToListAsync(cancellationToken);

            var allLines = rawLines.Select(o => new OrderSummaryLineDto
            {
                Id             = o.Id,
                OrderNumber    = o.OrderNumber,
                OrderDate      = o.OrderDate,
                CustomerName   = o.CustomerName,
                MangoTypeNames = string.Join(", ", o.MangoTypeNames),
                TotalQuantity  = o.TotalQuantity,
                TotalAmount    = o.TotalAmount,
                PaidAmount     = o.PaidAmount,
                DueAmount      = o.DueAmount,
                OrderStatus    = o.OrderStatus,
                PaymentStatus  = o.PaymentStatus,
            }).ToList();

            var active = allLines
                .Where(o => o.OrderStatus != OrderStatus.Cancelled && o.OrderStatus != OrderStatus.Returned)
                .ToList();

            int ordersTotalCount = allLines.Count;
            int pageNumber = query.PageNumber <= 0 ? 1 : query.PageNumber;
            List<OrderSummaryLineDto> pageLines;
            int pageSize;
            if (query.PageSize <= 0)
            {
                // Export path: return everything, ignore paging.
                pageLines = allLines;
                pageNumber = 1;
                pageSize = ordersTotalCount;
            }
            else
            {
                pageSize = query.PageSize;
                pageLines = allLines.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            }

            var dto = new OrderSummaryReportDto
            {
                From              = query.From.Date,
                To                = query.To.Date,
                TotalOrders       = allLines.Count,
                PendingOrders     = allLines.Count(o => o.OrderStatus == OrderStatus.Pending),
                ConfirmedOrders   = allLines.Count(o => o.OrderStatus == OrderStatus.Confirmed),
                ProcessingOrders  = allLines.Count(o => o.OrderStatus == OrderStatus.Processing),
                ShippedOrders     = allLines.Count(o => o.OrderStatus == OrderStatus.Shipped),
                DeliveredOrders   = allLines.Count(o => o.OrderStatus == OrderStatus.Delivered),
                CancelledOrders   = allLines.Count(o => o.OrderStatus == OrderStatus.Cancelled),
                ReturnedOrders    = allLines.Count(o => o.OrderStatus == OrderStatus.Returned),
                TotalRevenue      = active.Sum(o => o.TotalAmount),
                TotalCollected    = active.Sum(o => o.PaidAmount),
                TotalOutstanding  = active.Sum(o => o.DueAmount),
                Orders            = pageLines,
                OrdersTotalCount  = ordersTotalCount,
                OrdersPageNumber  = pageNumber,
                OrdersPageSize    = pageSize,
            };

            return await Result<OrderSummaryReportDto>.SuccessAsync(dto);
        }
    }
}
