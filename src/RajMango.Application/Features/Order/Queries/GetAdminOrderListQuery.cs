using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs.Order;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Queries
{
    public record GetAdminOrderListQuery : IRequest<AdminOrderPaginatedResult>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }
        public DeliveryStatus? DeliveryStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CourierProviderId { get; set; }
        public int? CourierStationId { get; set; }
        public string MangoType { get; set; }

        // --- Delivery preparation filters ---
        public bool? CourierEligibleOnly { get; set; }
        public string DeliveryArea { get; set; }
        public string ReceiverMobile { get; set; }
    }

    public class GetAdminOrderListQueryHandler : IRequestHandler<GetAdminOrderListQuery, AdminOrderPaginatedResult>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetAdminOrderListQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<AdminOrderPaginatedResult> Handle(GetAdminOrderListQuery query, CancellationToken cancellationToken)
        {
            if (!_currentUserService.IsAdmin && !_currentUserService.IsSuperAdmin)
                return AdminOrderPaginatedResult.Create(
                    new List<AdminOrderListDto>(), 0, 1, 10, 0, 0, 0, 0m, 0m, 0m);

            var orderQuery = _dataContext.Get<Order>()
                .Include(o => o.AppUser)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.MangoType)
                .Include(o => o.CourierStation)
                    .ThenInclude(cs => cs.CourierProvider)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.OrderNumber))
                orderQuery = orderQuery.Where(o => o.OrderNumber.Contains(query.OrderNumber));

            if (!string.IsNullOrWhiteSpace(query.CustomerName))
                orderQuery = orderQuery.Where(o =>
                    (o.AppUser.FirstName + " " + o.AppUser.LastName).Contains(query.CustomerName));

            if (!string.IsNullOrWhiteSpace(query.PhoneNumber))
                orderQuery = orderQuery.Where(o => o.AppUser.PhoneNumber.Contains(query.PhoneNumber));

            if (query.OrderStatus.HasValue)
                orderQuery = orderQuery.Where(o => o.OrderStatus == query.OrderStatus.Value);

            if (query.PaymentStatus.HasValue)
                orderQuery = orderQuery.Where(o => o.PaymentStatus == query.PaymentStatus.Value);

            if (query.DeliveryStatus.HasValue)
                orderQuery = orderQuery.Where(o => o.DeliveryStatus == query.DeliveryStatus.Value);

            if (query.StartDate.HasValue)
                orderQuery = orderQuery.Where(o => o.OrderDate >= query.StartDate.Value);

            if (query.EndDate.HasValue)
                orderQuery = orderQuery.Where(o => o.OrderDate <= query.EndDate.Value.Date.AddDays(1).AddTicks(-1));

            if (query.CourierProviderId.HasValue)
                orderQuery = orderQuery.Where(o => o.CourierProviderId == query.CourierProviderId.Value);

            if (query.CourierStationId.HasValue)
                orderQuery = orderQuery.Where(o => o.CourierStationId == query.CourierStationId.Value);

            if (!string.IsNullOrWhiteSpace(query.MangoType))
                orderQuery = orderQuery.Where(o => o.OrderDetails.Any(od => od.MangoType.Name.Contains(query.MangoType)));

            if (!string.IsNullOrWhiteSpace(query.DeliveryArea))
                orderQuery = orderQuery.Where(o => o.CourierStation != null && o.CourierStation.Area.Contains(query.DeliveryArea));

            if (!string.IsNullOrWhiteSpace(query.ReceiverMobile))
                orderQuery = orderQuery.Where(o =>
                    o.AppUser.PhoneNumber.Contains(query.ReceiverMobile) ||
                    (o.ReceiverMobileNumber != null && o.ReceiverMobileNumber.Contains(query.ReceiverMobile)));

            if (query.CourierEligibleOnly == true)
                orderQuery = orderQuery.Where(o =>
                    o.OrderStatus == OrderStatus.Confirmed &&
                    o.PaymentStatus == PaymentStatus.Paid &&
                    (o.DeliveryStatus == DeliveryStatus.None || o.DeliveryStatus == DeliveryStatus.Pending) &&
                    o.CourierStationId.HasValue);

            bool ascending = !string.Equals(query.SortOrder, "desc", StringComparison.OrdinalIgnoreCase);
            orderQuery = query.SortBy?.ToLower() switch
            {
                "ordernumber"    => ascending ? orderQuery.OrderBy(o => o.OrderNumber)      : orderQuery.OrderByDescending(o => o.OrderNumber),
                "orderdate"      => ascending ? orderQuery.OrderBy(o => o.OrderDate)        : orderQuery.OrderByDescending(o => o.OrderDate),
                "totalamount"    => ascending ? orderQuery.OrderBy(o => o.TotalAmount)      : orderQuery.OrderByDescending(o => o.TotalAmount),
                "orderstatus"    => ascending ? orderQuery.OrderBy(o => o.OrderStatus)      : orderQuery.OrderByDescending(o => o.OrderStatus),
                "paymentstatus"  => ascending ? orderQuery.OrderBy(o => o.PaymentStatus)    : orderQuery.OrderByDescending(o => o.PaymentStatus),
                "deliverystatus" => ascending ? orderQuery.OrderBy(o => o.DeliveryStatus)   : orderQuery.OrderByDescending(o => o.DeliveryStatus),
                _                => orderQuery.OrderByDescending(o => o.OrderDate),
            };

            int pageNumber = query.PageNumber <= 0 ? 1 : query.PageNumber;
            int pageSize   = query.PageSize   <= 0 ? 10 : query.PageSize;

            int totalCount = await orderQuery.CountAsync(cancellationToken);

            // ── Summary totals across ALL filtered records (not just the current page) ──
            int     summaryTotalQtyKg  = 0;
            int     crate10KgCount    = 0;
            int     crate20KgCount    = 0;
            decimal summaryTotalAmount = 0m;
            decimal summaryTotalPaid   = 0m;
            decimal summaryTotalDue    = 0m;

            if (totalCount > 0)
            {
                summaryTotalQtyKg  = await orderQuery.SumAsync(o => o.TotalQuantity, cancellationToken);
                summaryTotalAmount = await orderQuery.SumAsync(o => o.TotalAmount,   cancellationToken);
                summaryTotalPaid   = await orderQuery.SumAsync(o => o.PaidAmount,    cancellationToken);
                summaryTotalDue    = await orderQuery.SumAsync(o => o.DueAmount,     cancellationToken);

                var filteredOrderIds = await orderQuery.Select(o => o.Id).ToListAsync(cancellationToken);

                var crateGroups = await _dataContext.Get<OrderDetail>()
                    .Where(od => filteredOrderIds.Contains(od.OrderId) && od.CrateType != CrateType.None)
                    .GroupBy(od => od.CrateType)
                    .Select(g => new { CrateType = g.Key, Total = g.Sum(od => od.Quantity) })
                    .ToListAsync(cancellationToken);

                crate10KgCount = crateGroups.FirstOrDefault(c => c.CrateType == CrateType.Crate10Kg)?.Total ?? 0;
                crate20KgCount = crateGroups.FirstOrDefault(c => c.CrateType == CrateType.Crate20Kg)?.Total ?? 0;
            }
            // ─────────────────────────────────────────────────────────────────────────────

            var orders = await orderQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var data = orders.Select(o =>
            {
                var customerName = o.AppUser != null ? $"{o.AppUser.FirstName} {o.AppUser.LastName}".Trim() : null;
                var customerPhone = o.AppUser?.PhoneNumber;
                bool isSelf = o.ReceiverType == ReceiverType.Self;
                bool eligible = o.OrderStatus == OrderStatus.Confirmed
                    && o.PaymentStatus == PaymentStatus.Paid
                    && (o.DeliveryStatus == DeliveryStatus.None || o.DeliveryStatus == DeliveryStatus.Pending)
                    && o.CourierStationId.HasValue;

                return new AdminOrderListDto
                {
                    OrderId              = o.Id,
                    OrderNumber          = o.OrderNumber,
                    OrderDate            = o.OrderDate,

                    CustomerName         = customerName,
                    CustomerPhone        = customerPhone,

                    ReceiverType         = o.ReceiverType,
                    ReceiverName         = isSelf ? customerName : o.ReceiverName,
                    ReceiverMobile       = isSelf ? customerPhone : o.ReceiverMobileNumber,

                    CourierProviderName  = o.CourierStation?.CourierProvider?.Name,
                    CourierStationName   = o.CourierStation?.Name,
                    CourierStationAddress = o.CourierStation?.AddressLine,
                    DeliveryArea         = o.CourierStation?.Area,

                    TotalQuantity        = o.TotalQuantity,
                    ProductTotal         = o.ProductTotalAmount,
                    CourierCharge        = o.IsCourierChargeOverridden && o.CourierChargeOverrideAmount.HasValue
                                              ? o.CourierChargeOverrideAmount.Value
                                              : o.CourierCharge,
                    TotalAmount          = o.TotalAmount,
                    PaidAmount           = o.PaidAmount,
                    DueAmount            = o.DueAmount,

                    OrderStatus          = o.OrderStatus,
                    PaymentStatus        = o.PaymentStatus,
                    DeliveryStatus       = o.DeliveryStatus,
                    DeliveryDate         = o.DeliveryDate,

                    IsCourierEligible    = eligible,
                    MangoTypeName        = o.OrderDetails.FirstOrDefault()?.MangoType?.Name,
                };
            }).ToList();

            return AdminOrderPaginatedResult.Create(
                data, totalCount, pageNumber, pageSize,
                summaryTotalQtyKg, crate10KgCount, crate20KgCount,
                summaryTotalAmount, summaryTotalPaid, summaryTotalDue);
        }
    }
}
