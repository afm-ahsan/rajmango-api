using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs.Order;
using RajMango.Application.Extensions;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetOrderWithPaginationQuery : IRequest<PaginatedResult<OrderDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public string Filter { get; set; }
        /// <summary>Admin only: filter by a specific user. 0 = all users.</summary>
        public int UserId { get; set; }

        public GetOrderWithPaginationQuery() { }

        public GetOrderWithPaginationQuery(int pageNumber, int pageSize, string sortBy, string sortOrder, string filter, int userId)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SortBy = sortBy;
            SortOrder = sortOrder;
            Filter = filter;
            UserId = userId;
        }
    }

    public class GetOrderWithPaginationQueryHandler : IRequestHandler<GetOrderWithPaginationQuery, PaginatedResult<OrderDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetOrderWithPaginationQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<PaginatedResult<OrderDto>> Handle(GetOrderWithPaginationQuery query, CancellationToken cancellationToken)
        {
            var orderQuery = _dataContext.Get<Order>()
                                         .Include(o => o.OrderDetails)
                                         .AsQueryable();

            if (!_currentUserService.IsAdmin)
            {
                orderQuery = orderQuery.Where(o => o.UserId == _currentUserService.UserId);
            }
            else if (query.UserId > 0)
            {
                orderQuery = orderQuery.Where(o => o.UserId == query.UserId);
            }

            orderQuery = ApplyFilterAndSort(orderQuery, query.Filter, query.SortBy, query.SortOrder == "asc");

            var paged = await orderQuery.ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);

            var orderList = paged.Data.Select(o => new OrderDto
            {
                Id               = o.Id,
                OrderNumber      = o.OrderNumber,
                OrderDate        = o.OrderDate,
                TotalQuantity    = o.TotalQuantity,
                TotalAmount      = o.TotalAmount,
                OrderStatus      = o.OrderStatus,
                PaymentStatus    = o.PaymentStatus,
                PaidAmount       = o.PaidAmount,
                DueAmount        = o.DueAmount,
                IsValidOrder     = o.IsValidOrder,
                IsDelivered      = o.IsDelivered,
                DeliveryDate     = o.DeliveryDate,
                TrackingNumber   = o.TrackingNumber,
                CourierStationId = o.CourierStationId,
                FallbackAddress  = o.FallbackAddress,
                UserId           = o.UserId,
                OrderDetails = o.OrderDetails.Select(d => new OrderDetailDto
                {
                    Id          = d.Id,
                    OrderId     = d.OrderId,
                    MangoTypeId = d.MangoTypeId,
                    CrateType   = d.CrateType,
                    Quantity    = d.Quantity,
                    UnitPrice   = d.UnitPrice,
                    Discount    = d.Discount,
                    TotalPrice  = d.TotalPrice,
                    Note        = d.Note,
                }).ToList(),
            }).ToList();

            return new PaginatedResult<OrderDto>(
                succeeded: true,
                data: orderList,
                pageNumber: query.PageNumber,
                pageSize: query.PageSize);
        }

        private static IQueryable<Order> ApplyFilterAndSort(IQueryable<Order> query, string filter, string sortBy, bool ascending)
        {
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(o => o.OrderNumber.Contains(filter));

            query = sortBy switch
            {
                "orderNumber"   => ascending ? query.OrderBy(o => o.OrderNumber)   : query.OrderByDescending(o => o.OrderNumber),
                "orderDate"     => ascending ? query.OrderBy(o => o.OrderDate)     : query.OrderByDescending(o => o.OrderDate),
                "totalQuantity" => ascending ? query.OrderBy(o => o.TotalQuantity) : query.OrderByDescending(o => o.TotalQuantity),
                "totalAmount"   => ascending ? query.OrderBy(o => o.TotalAmount)   : query.OrderByDescending(o => o.TotalAmount),
                "orderStatus"   => ascending ? query.OrderBy(o => o.OrderStatus)   : query.OrderByDescending(o => o.OrderStatus),
                "paymentStatus" => ascending ? query.OrderBy(o => o.PaymentStatus) : query.OrderByDescending(o => o.PaymentStatus),
                "isDelivered"   => ascending ? query.OrderBy(o => o.IsDelivered)   : query.OrderByDescending(o => o.IsDelivered),
                _               => query.OrderByDescending(o => o.OrderDate),
            };

            return query;
        }
    }
}
