using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Queries
{
    public class AdminDashboardDto
    {
        // Order counts
        public int TotalOrders { get; set; }
        public int OrdersToday { get; set; }
        public int PendingOrders { get; set; }
        public int ConfirmedOrders { get; set; }
        public int ProcessingOrders { get; set; }
        public int ShippedOrders { get; set; }
        public int DeliveredOrders { get; set; }
        public int CancelledOrders { get; set; }

        // Revenue
        public decimal TotalRevenue { get; set; }
        public decimal TotalCollected { get; set; }
        public decimal TotalOutstanding { get; set; }

        // Entities
        public int TotalCustomers { get; set; }
        public int AvailableMangoTypes { get; set; }

        public List<DashboardMangoAvailabilityDto> AvailableMangoes { get; set; } = new();
        public List<AdminRecentOrderDto> RecentOrders { get; set; } = new();
    }

    public class AdminRecentOrderDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }

    public record GetAdminDashboardQuery : IRequest<Result<AdminDashboardDto>>;

    public class GetAdminDashboardQueryHandler : IRequestHandler<GetAdminDashboardQuery, Result<AdminDashboardDto>>
    {
        private readonly IDataContext _dataContext;

        public GetAdminDashboardQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<AdminDashboardDto>> Handle(GetAdminDashboardQuery query, CancellationToken cancellationToken)
        {
            var today = Clock.Now().Date;

            // Load all order key fields in one query; dataset is small for a seasonal business
            var orders = await _dataContext.Get<Order>()
                .Select(o => new
                {
                    o.OrderStatus,
                    o.TotalAmount,
                    o.PaidAmount,
                    o.DueAmount,
                    o.OrderDate,
                })
                .ToListAsync(cancellationToken);

            var recentOrders = await _dataContext.Get<Order>()
                .Include(o => o.AppUser)
                .OrderByDescending(o => o.OrderDate)
                .Take(10)
                .Select(o => new AdminRecentOrderDto
                {
                    Id            = o.Id,
                    OrderNumber   = o.OrderNumber,
                    OrderDate     = o.OrderDate,
                    UserId        = o.UserId,
                    CustomerName  = o.AppUser.FirstName + " " + o.AppUser.LastName,
                    TotalAmount   = o.TotalAmount,
                    PaidAmount    = o.PaidAmount,
                    DueAmount     = o.DueAmount,
                    OrderStatus    = o.OrderStatus,
                    PaymentStatus  = o.PaymentStatus,
                    DeliveryStatus = o.DeliveryStatus,
                    DeliveryDate   = o.DeliveryDate,
                })
                .ToListAsync(cancellationToken);

            var availableMangoes = await _dataContext.Get<MangoAvailability>()
                .Include(a => a.MangoType)
                .Where(a => a.Status == MangoAvailabilityStatus.Available)
                         //&& a.StartDate.Date <= today
                         //&& a.EndDate.Date >= today)
                .OrderBy(a => a.MangoType.Name)
                .Select(a => new DashboardMangoAvailabilityDto
                {
                    Id            = a.Id,
                    MangoTypeId   = a.MangoTypeId,
                    MangoTypeName = a.MangoType.Name,
                    PricePerKg    = a.PricePerKg,
                    EndDate       = a.EndDate,
                })
                .ToListAsync(cancellationToken);

            var totalCustomers = await _dataContext.Get<Customer>().CountAsync(cancellationToken);

            // Revenue excludes cancelled orders
            var activeOrders = orders.Where(o => o.OrderStatus != OrderStatus.Cancelled).ToList();

            var dto = new AdminDashboardDto
            {
                TotalOrders       = orders.Count,
                OrdersToday       = orders.Count(o => o.OrderDate.Date == today),
                PendingOrders     = orders.Count(o => o.OrderStatus == OrderStatus.Pending),
                ConfirmedOrders   = orders.Count(o => o.OrderStatus == OrderStatus.Confirmed),
                ProcessingOrders  = orders.Count(o => o.OrderStatus == OrderStatus.Processing),
                ShippedOrders     = orders.Count(o => o.OrderStatus == OrderStatus.Shipped),
                DeliveredOrders   = orders.Count(o => o.OrderStatus == OrderStatus.Delivered),
                CancelledOrders   = orders.Count(o => o.OrderStatus == OrderStatus.Cancelled),
                TotalRevenue      = activeOrders.Sum(o => o.TotalAmount),
                TotalCollected    = activeOrders.Sum(o => o.PaidAmount),
                TotalOutstanding  = activeOrders.Sum(o => o.DueAmount),
                TotalCustomers    = totalCustomers,
                AvailableMangoTypes = availableMangoes.Count,
                AvailableMangoes  = availableMangoes,
                RecentOrders      = recentOrders,
            };

            return await Result<AdminDashboardDto>.SuccessAsync(dto);
        }
    }
}
