using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using System.Text.Json;

namespace RajMango.Application.Features.Commands
{
    internal class AdminPermanentDeleteOrderCommandHandler
        : IRequestHandler<AdminPermanentDeleteOrderCommand, Result<int>>
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public AdminPermanentDeleteOrderCommandHandler(
            IDataContext dataContext,
            ICurrentUserService currentUserService)
        {
            _dataContext        = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<int>> Handle(
            AdminPermanentDeleteOrderCommand command, CancellationToken cancellationToken)
        {
            // ── 1. Permission ────────────────────────────────────────────────────────────
            if (!_currentUserService.IsAdmin && !_currentUserService.IsSuperAdmin)
                return await Result<int>.FailureAsync("Only admin users can permanently delete orders.");

            // ── 2. Validate inputs ───────────────────────────────────────────────────────
            if (string.IsNullOrWhiteSpace(command.Reason))
                return await Result<int>.FailureAsync("A reason is required to delete an order.");

            if (string.IsNullOrWhiteSpace(command.ConfirmOrderNumber))
                return await Result<int>.FailureAsync("Order number confirmation is required.");

            // ── 3. Load the order ────────────────────────────────────────────────────────
            var order = await _dataContext.Get<Order>()
                .Include(o => o.OrderDetails)
                .Include(o => o.Payments)
                .FirstOrDefaultAsync(o => o.Id == command.OrderId, cancellationToken);

            if (order == null)
                return await Result<int>.FailureAsync($"Order with ID {command.OrderId} was not found.");

            // ── 4. Confirm order number matches (guards against accidental deletion) ─────
            if (!string.Equals(
                    command.ConfirmOrderNumber.Trim(),
                    order.OrderNumber,
                    StringComparison.OrdinalIgnoreCase))
            {
                return await Result<int>.FailureAsync(
                    $"Order number confirmation does not match. " +
                    $"Expected '{order.OrderNumber}', received '{command.ConfirmOrderNumber.Trim()}'.");
            }

            // ── 5. Build JSON snapshot before soft-deleting anything ─────────────────────
            var snapshot = BuildSnapshot(order);

            // ── 6. Create the audit record ───────────────────────────────────────────────
            var audit = new OrderDeletionAudit
            {
                OrderId           = order.Id,
                OrderNumber       = order.OrderNumber,
                CustomerUserId    = order.UserId,
                DeletedByUserId   = _currentUserService.UserId,
                DeletedAt         = Clock.Now(),
                Reason            = command.Reason.Trim(),
                OrderSnapshotJson = JsonSerializer.Serialize(snapshot, _jsonOptions),
                CreatedAt         = Clock.Now(),
            };
            _dataContext.Get<OrderDeletionAudit>().Add(audit);

            // ── 7. Soft-delete linked Payments ────────────────────────────────────────────
            // AuditingHelper.ApplyAuditing() in SaveChangesAsync automatically sets
            // DeletedAt and DeletedBy when it sees a Modified entity with IsDeleted = true.
            foreach (var payment in order.Payments.Where(p => !p.IsDeleted))
            {
                payment.IsDeleted = true;
                _dataContext.Get<Payment>().Update(payment);
            }

            // ── 8. Soft-delete the Order ─────────────────────────────────────────────────
            // The global EF query filter (IsDeleted == false) will immediately hide this
            // order from every consumer: dashboard totals, order list, admin list, reports.
            // No code changes are required in any reader.
            order.IsDeleted = true;
            _dataContext.Get<Order>().Update(order);

            // ── 9. Persist audit + soft-deletes in one transaction ───────────────────────
            await _dataContext.SaveChangesAsync(cancellationToken);

            return await Result<int>.SuccessAsync(
                audit.Id,
                $"Order {order.OrderNumber} has been permanently deleted. Audit ID: {audit.Id}.");
        }

        /// <summary>
        /// Builds a lightweight, serializable snapshot of the order's key business data.
        /// Omits large fields (bKash response payloads) to keep the snapshot readable.
        /// </summary>
        private static object BuildSnapshot(Order order) => new
        {
            orderId              = order.Id,
            orderNumber          = order.OrderNumber,
            ownerUserId          = order.UserId,
            isPlacedByAdmin      = order.IsPlacedByAdmin,
            placedByAdminUserId  = order.PlacedByAdminUserId,
            orderDate            = order.OrderDate,
            orderStatus          = order.OrderStatus.ToString(),
            paymentStatus        = order.PaymentStatus.ToString(),
            deliveryStatus       = order.DeliveryStatus.ToString(),
            totalQuantity        = order.TotalQuantity,
            productTotalAmount   = order.ProductTotalAmount,
            courierCharge        = order.CourierCharge,
            totalAmount          = order.TotalAmount,
            paidAmount           = order.PaidAmount,
            dueAmount            = order.DueAmount,
            receiverType         = order.ReceiverType.ToString(),
            receiverName         = order.ReceiverName,
            receiverMobileNumber = order.ReceiverMobileNumber,
            fallbackAddress      = order.FallbackAddress,
            createdAt            = order.CreatedAt,
            createdBy            = order.CreatedBy,
            updatedAt            = order.UpdatedAt,
            orderDetails = order.OrderDetails.Select(d => new
            {
                mangoTypeId = d.MangoTypeId,
                crateType   = d.CrateType.ToString(),
                quantity    = d.Quantity,
                unitPrice   = d.UnitPrice,
                totalPrice  = d.TotalPrice,
            }),
            payments = order.Payments.Select(p => new
            {
                paymentId     = p.Id,
                paymentMethod = p.PaymentMethod.ToString(),
                paymentStatus = p.PaymentStatus.ToString(),
                paidAmount    = p.PaidAmount,
                transactionId = p.TransactionId,
                paidAt        = p.PaidAt,
            }),
        };
    }
}
