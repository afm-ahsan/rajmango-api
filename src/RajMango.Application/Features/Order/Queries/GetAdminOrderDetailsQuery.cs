using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs.Order;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetAdminOrderDetailsQuery(int Id) : IRequest<Result<AdminOrderDetailsDto>>;

    public class GetAdminOrderDetailsQueryHandler : IRequestHandler<GetAdminOrderDetailsQuery, Result<AdminOrderDetailsDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetAdminOrderDetailsQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<AdminOrderDetailsDto>> Handle(GetAdminOrderDetailsQuery query, CancellationToken cancellationToken)
        {
            if (!_currentUserService.IsAdmin && !_currentUserService.IsSuperAdmin)
                return await Result<AdminOrderDetailsDto>.FailureAsync("Access denied.");

            var order = await _dataContext.Get<Order>()
                .Include(o => o.AppUser)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.MangoType)
                .Include(o => o.CourierStation)
                    .ThenInclude(cs => cs.CourierProvider)
                .Include(o => o.Payments)
                .Where(o => o.Id == query.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (order == null)
                return await Result<AdminOrderDetailsDto>.FailureAsync($"Order not found with Id {query.Id}.");

            var customer = order.UserId > 0
                ? await _dataContext.Get<Customer>()
                    .Where(c => c.UserId == order.UserId)
                    .FirstOrDefaultAsync(cancellationToken)
                : null;

            var dto = new AdminOrderDetailsDto
            {
                OrderId                   = order.Id,
                OrderNumber               = order.OrderNumber,
                OrderDate                 = order.OrderDate,
                TotalQuantity             = order.TotalQuantity,

                CustomerId                = order.UserId,
                CustomerName              = order.AppUser != null ? $"{order.AppUser.FirstName} {order.AppUser.LastName}" : null,
                CustomerPhone             = order.AppUser?.PhoneNumber,
                CustomerEmail             = order.AppUser?.Email,
                CustomerAddress           = customer?.AddressLine1,

                ProductTotal              = order.ProductTotalAmount,
                TotalAmount               = order.TotalAmount,
                PaidAmount                = order.PaidAmount,
                DueAmount                 = order.DueAmount,

                OrderStatus               = order.OrderStatus,
                PaymentStatus             = order.PaymentStatus,
                DeliveryStatus            = order.DeliveryStatus,

                TrackingNumber            = order.TrackingNumber,
                DeliveryDate              = order.DeliveryDate,
                FallbackAddress           = order.FallbackAddress,
                ReceiverType              = order.ReceiverType,
                ReceiverName              = order.ReceiverName,
                ReceiverMobileNumber      = order.ReceiverMobileNumber,
                DeliveryNote              = order.DeliveryNote,

                CourierProviderId         = order.CourierProviderId,
                CourierProviderName       = order.CourierStation?.CourierProvider?.Name,
                CourierStationId          = order.CourierStationId,
                CourierStationName        = order.CourierStation != null
                    ? $"{order.CourierStation.CourierProvider?.Name} - {order.CourierStation.Name} ({order.CourierStation.City})"
                    : null,
                CourierLocationType       = order.CourierLocationType,

                CourierRatePerKg          = order.CourierRatePerKg,
                CourierChargeCalculated   = order.CourierCharge,
                CourierChargeOverrideAmount = order.CourierChargeOverrideAmount,
                IsCourierChargeOverridden = order.IsCourierChargeOverridden,
                CourierChargeNote         = order.CourierChargeNote,

                OrderItems = order.OrderDetails.Select(d => new AdminOrderItemDto
                {
                    Id           = d.Id,
                    MangoTypeId  = d.MangoTypeId,
                    MangoTypeName= d.MangoType?.Name,
                    CrateType    = d.CrateType,
                    Quantity     = d.Quantity,
                    UnitPrice    = d.UnitPrice,
                    Discount     = d.Discount,
                    TotalPrice   = d.TotalPrice,
                    Note         = d.Note,
                }).ToList(),

                Payments = order.Payments.Select(p => new AdminOrderPaymentDto
                {
                    Id            = p.Id,
                    PaidAmount    = p.PaidAmount,
                    NetAmount     = p.NetAmount,
                    PaymentStatus = p.PaymentStatus,
                    PaymentMethod = p.PaymentMethod,
                    TransactionId = p.TransactionId,
                    PaidAt        = p.PaidAt,
                    CreatedAt     = p.CreatedAt,
                }).OrderByDescending(p => p.CreatedAt).ToList(),

                CreatedAt = order.CreatedAt,
                UpdatedAt = order.UpdatedAt,
            };

            return await Result<AdminOrderDetailsDto>.SuccessAsync(dto);
        }
    }
}
