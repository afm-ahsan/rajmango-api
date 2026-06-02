using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Search.Queries
{
    public record GlobalSearchQuery : IRequest<Result<GlobalSearchResultDto>>
    {
        public string Term { get; set; }
        public int MaxPerSection { get; set; } = 5;
    }

    // ── Result DTOs ──────────────────────────────────────────────────────────

    public class GlobalSearchResultDto
    {
        public List<OrderSearchItemDto>   Orders          { get; set; } = new();
        public List<CustomerSearchItemDto> Customers      { get; set; } = new();
        public List<StationSearchItemDto> CourierStations { get; set; } = new();
        public List<MangoSearchItemDto>   Mangoes         { get; set; } = new();
    }

    public class OrderSearchItemDto
    {
        public int    Id           { get; set; }
        public string OrderNumber  { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public int    OrderStatus  { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate  { get; set; }
        public string MangoTypeName { get; set; }
    }

    public class CustomerSearchItemDto
    {
        public int    Id    { get; set; }
        public string Name  { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class StationSearchItemDto
    {
        public int    Id           { get; set; }
        public string Name         { get; set; }
        public string Area         { get; set; }
        public string City         { get; set; }
        public string ProviderName { get; set; }
    }

    public class MangoSearchItemDto
    {
        public int    Id     { get; set; }
        public string Name   { get; set; }
        public string Region { get; set; }
    }

    // ── Handler ──────────────────────────────────────────────────────────────

    internal class GlobalSearchQueryHandler : IRequestHandler<GlobalSearchQuery, Result<GlobalSearchResultDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IErrorHandler _errorHandler;

        public GlobalSearchQueryHandler(
            IDataContext dataContext,
            ICurrentUserService currentUserService,
            IErrorHandler errorHandler)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
            _errorHandler = errorHandler;
        }

        public async Task<Result<GlobalSearchResultDto>> Handle(
            GlobalSearchQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var term  = query.Term.Trim();
                var take  = Math.Clamp(query.MaxPerSection, 1, 10);
                bool isAdmin = _currentUserService.IsAdmin || _currentUserService.IsSuperAdmin;

                var result = new GlobalSearchResultDto();

                // ── Orders ────────────────────────────────────────────────────
                // No Include() — EF Core generates efficient subqueries/joins
                // from the navigation properties used in Where and Select.
                var orderQuery = _dataContext.Get<Order>().AsQueryable();

                if (!isAdmin)
                    orderQuery = orderQuery.Where(o => o.UserId == _currentUserService.UserId);

                result.Orders = await orderQuery
                    .Where(o =>
                        o.OrderNumber.Contains(term) ||
                        (o.AppUser.FirstName + " " + o.AppUser.LastName).Contains(term) ||
                        o.AppUser.PhoneNumber.Contains(term) ||
                        (o.ReceiverMobileNumber != null && o.ReceiverMobileNumber.Contains(term)) ||
                        o.OrderDetails.Any(d => d.MangoType.Name.Contains(term)) ||
                        (o.CourierStation != null && o.CourierStation.Area.Contains(term)))
                    .OrderByDescending(o => o.OrderDate)
                    .Take(take)
                    .Select(o => new OrderSearchItemDto
                    {
                        Id            = o.Id,
                        OrderNumber   = o.OrderNumber,
                        CustomerName  = o.AppUser.FirstName + " " + o.AppUser.LastName,
                        CustomerPhone = o.AppUser.PhoneNumber,
                        OrderStatus   = (int)o.OrderStatus,
                        TotalAmount   = o.TotalAmount,
                        OrderDate     = o.OrderDate,
                        MangoTypeName = o.OrderDetails
                            .Select(d => d.MangoType.Name)
                            .FirstOrDefault(),
                    })
                    .ToListAsync(cancellationToken);

                if (isAdmin)
                {
                    // ── Customers ──────────────────────────────────────────────
                    result.Customers = await _dataContext.Get<Customer>()
                        .Where(c =>
                            (c.FirstName + " " + c.LastName).Contains(term) ||
                            c.PhoneNumber1.Contains(term) ||
                            (c.Email != null && c.Email.Contains(term)))
                        .OrderBy(c => c.FirstName)
                        .Take(take)
                        .Select(c => new CustomerSearchItemDto
                        {
                            Id    = c.Id,
                            Name  = c.FirstName + " " + c.LastName,
                            Phone = c.PhoneNumber1,
                            Email = c.Email,
                        })
                        .ToListAsync(cancellationToken);

                    // ── Courier Stations ───────────────────────────────────────
                    result.CourierStations = await _dataContext.Get<CourierStation>()
                        .Include(s => s.CourierProvider)
                        .Where(s =>
                            s.Name.Contains(term) ||
                            s.Area.Contains(term) ||
                            s.City.Contains(term))
                        .OrderBy(s => s.Name)
                        .Take(take)
                        .Select(s => new StationSearchItemDto
                        {
                            Id           = s.Id,
                            Name         = s.Name,
                            Area         = s.Area,
                            City         = s.City,
                            ProviderName = s.CourierProvider.Name,
                        })
                        .ToListAsync(cancellationToken);
                }

                // ── Mango Types (all authenticated users) ──────────────────────
                result.Mangoes = await _dataContext.Get<MangoType>()
                    .Where(m =>
                        m.Name.Contains(term) ||
                        (m.Region != null && m.Region.Contains(term)))
                    .OrderBy(m => m.Name)
                    .Take(take)
                    .Select(m => new MangoSearchItemDto
                    {
                        Id     = m.Id,
                        Name   = m.Name,
                        Region = m.Region,
                    })
                    .ToListAsync(cancellationToken);

                return await Result<GlobalSearchResultDto>.SuccessAsync(result);
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<GlobalSearchResultDto>.FailureAsync("Search failed.");
        }
    }
}
