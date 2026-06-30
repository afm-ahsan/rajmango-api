using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Queries
{
    public class CustomerDashboardDto
    {
        public int TotalOrders { get; set; }
        public int ActiveOrders { get; set; }
        public int DeliveredOrders { get; set; }
        public int CancelledOrders { get; set; }
        public decimal TotalOrderValue { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalDue { get; set; }
        public List<CustomerRecentOrderDto> RecentOrders { get; set; } = new();
        public List<DashboardMangoAvailabilityDto> AvailableMangoes { get; set; } = new();
        public List<DashboardUpcomingMangoDto> UpcomingMangoes { get; set; } = new();
    }

    public class CustomerRecentOrderDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string MangoTypeNames { get; set; }
    }

    public class DashboardMangoAvailabilityDto
    {
        public int Id { get; set; }
        public int MangoTypeId { get; set; }
        public string MangoTypeName { get; set; }
        public decimal PricePerKg { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class DashboardUpcomingMangoDto
    {
        public int Id { get; set; }
        public int MangoTypeId { get; set; }
        public string MangoTypeName { get; set; }
        public decimal PricePerKg { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public record GetCustomerDashboardQuery : IRequest<Result<CustomerDashboardDto>>;

    public class GetCustomerDashboardQueryHandler : IRequestHandler<GetCustomerDashboardQuery, Result<CustomerDashboardDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetCustomerDashboardQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<CustomerDashboardDto>> Handle(GetCustomerDashboardQuery query, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            var orders = await _dataContext.Get<Order>()
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new
                {
                    o.Id,
                    o.OrderNumber,
                    o.OrderDate,
                    o.TotalQuantity,
                    o.TotalAmount,
                    o.PaidAmount,
                    o.DueAmount,
                    o.OrderStatus,
                    o.PaymentStatus,
                    o.DeliveryStatus,
                    o.DeliveryDate,
                    MangoTypeNames = o.OrderDetails.Select(od => od.MangoType.Name),
                })
                .ToListAsync(cancellationToken);

            var today = Clock.Now().Date;
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
                    StartDate     = a.StartDate,
                    EndDate       = a.EndDate,
                })
                .ToListAsync(cancellationToken);

            var upcomingMangoes = await _dataContext.Get<MangoAvailability>()
                .Include(a => a.MangoType)
                .Where(a => a.Status == MangoAvailabilityStatus.Upcoming)
                .OrderBy(a => a.StartDate)
                .ThenBy(a => a.MangoType.Name)
                .Select(a => new DashboardUpcomingMangoDto
                {
                    Id            = a.Id,
                    MangoTypeId   = a.MangoTypeId,
                    MangoTypeName = a.MangoType.Name,
                    PricePerKg    = a.PricePerKg,
                    StartDate     = a.StartDate,
                    EndDate       = a.EndDate,
                })
                .ToListAsync(cancellationToken);

            var dto = new CustomerDashboardDto
            {
                TotalOrders     = orders.Count,
                ActiveOrders    = orders.Count(o => o.OrderStatus is OrderStatus.Pending
                                                                   or OrderStatus.Confirmed
                                                                   or OrderStatus.Processing
                                                                   or OrderStatus.Shipped),
                DeliveredOrders = orders.Count(o => o.OrderStatus == OrderStatus.Delivered),
                CancelledOrders = orders.Count(o => o.OrderStatus == OrderStatus.Cancelled),
                TotalOrderValue = orders.Sum(o => o.TotalAmount),
                TotalPaid       = orders.Sum(o => o.PaidAmount),
                TotalDue        = orders.Sum(o => o.DueAmount),
                RecentOrders    = orders.Take(5).Select(o => new CustomerRecentOrderDto
                {
                    Id            = o.Id,
                    OrderNumber   = o.OrderNumber,
                    OrderDate     = o.OrderDate,
                    TotalQuantity = o.TotalQuantity,
                    TotalAmount   = o.TotalAmount,
                    PaidAmount    = o.PaidAmount,
                    DueAmount     = o.DueAmount,
                    OrderStatus    = o.OrderStatus,
                    PaymentStatus  = o.PaymentStatus,
                    DeliveryStatus = o.DeliveryStatus,
                    DeliveryDate   = o.DeliveryDate,
                    MangoTypeNames = string.Join(", ", o.MangoTypeNames),
                }).ToList(),
                AvailableMangoes = availableMangoes,
                UpcomingMangoes  = upcomingMangoes,
            };

            return await Result<CustomerDashboardDto>.SuccessAsync(dto);
        }
    }
}
