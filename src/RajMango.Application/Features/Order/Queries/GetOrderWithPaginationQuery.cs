using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs.Order;
using RajMango.Application.Extensions;
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
        private readonly IMapper _mapper;

        public GetOrderWithPaginationQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<OrderDto>> Handle(GetOrderWithPaginationQuery query, CancellationToken cancellationToken)
        {
            var orderQuery = _dataContext.Get<Order>()
                                         .Include(p => p.OrderDetails)
                                         .AsQueryable();

            orderQuery = orderQuery.Where(s => s.UserId == query.UserId);
            orderQuery = GetSortableQuery(orderQuery, query.Filter, query.SortBy, query.SortOrder == "asc");

            var orders = await orderQuery.ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);

            var orderList = new List<OrderDto>();
            foreach (var order in orders.Data)
            {
                var orderDto = new OrderDto
                {
                    Id = order.Id,
                    OrderNumber = order.OrderNumber,
                    OrderDate = order.OrderDate,
                    TotalQuantity = order.TotalQuantity,
                    TotalAmount = order.TotalAmount,
                    OrderStatus = order.OrderStatus,
                    PaymentStatus = order.PaymentStatus,
                    PaidAmount = order.PaidAmount,
                    DueAmount = order.DueAmount,
                    IsValidOrder = order.IsValidOrder,
                    IsDelivered = order.IsDelivered,
                    DeliveryDate = order.DeliveryDate,
                    TrackingNumber = order.TrackingNumber,
                    CourierStationId = order.CourierStationId,
                    FallbackAddress = order.FallbackAddress,
                    UserId = order.UserId,

                    OrderDetails = order.OrderDetails.Select(p => new OrderDetailDto
                    {
                        Id = p.Id,
                        OrderId = p.OrderId,
                        MangoTypeId = p.MangoTypeId,
                        CrateType = p.CrateType,
                        Quantity = p.Quantity,
                        UnitPrice = p.UnitPrice,
                        Discount = p.Discount,
                        TotalPrice = p.TotalPrice,
                        Note = p.Note,
                    }).ToList(),
                };

                orderList.Add(orderDto);
            }
            return new PaginatedResult<OrderDto>(succeeded: true, data: orderList, pageNumber: query.PageNumber, pageSize: query.PageSize);
        }

        public IQueryable<Order> GetSortableQuery(IQueryable<Order> query, string filter, string sortBy, bool ascending)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(s => s.OrderNumber.Contains(filter));
            }

            switch (sortBy)
            {
                case "orderNumber":
                    query = ascending ? query.OrderBy(e => e.OrderNumber) : query.OrderByDescending(e => e.OrderNumber);
                    break;
                case "orderDate":
                    query = ascending ? query.OrderBy(e => e.OrderDate) : query.OrderByDescending(e => e.OrderDate);
                    break;
                case "totalQuantity":
                    query = ascending ? query.OrderBy(e => e.TotalQuantity) : query.OrderByDescending(e => e.TotalQuantity);
                    break;
                case "totalAmount":
                    query = ascending ? query.OrderBy(e => e.TotalAmount) : query.OrderByDescending(e => e.TotalAmount);
                    break;
                case "orderStatus":
                    query = ascending ? query.OrderBy(e => e.OrderStatus) : query.OrderByDescending(e => e.OrderStatus);
                    break;
                case "paymentStatus":
                    query = ascending ? query.OrderBy(e => e.PaymentStatus) : query.OrderByDescending(e => e.PaymentStatus);
                    break;
                case "isDelivered":
                    query = ascending ? query.OrderBy(e => e.IsDelivered) : query.OrderByDescending(e => e.IsDelivered);
                    break;
            }

            return query;
        }
    }
}
