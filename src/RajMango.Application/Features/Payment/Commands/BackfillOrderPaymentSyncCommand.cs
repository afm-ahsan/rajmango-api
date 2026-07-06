using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    /// <summary>
    /// One-time backfill for orders affected by the pre-fix bKash stale-read bug.
    /// Recalculates PaidAmount/DueAmount/PaymentStatus using the same PaymentSyncHelper logic
    /// used going forward by the callback/refund handlers. Order/Delivery status are untouched.
    /// If OrderIds is empty, applies to every order currently drifted (same detection as
    /// GetOrderPaymentSyncDriftQuery) — intended to be called with the exact IDs from that
    /// query's dry-run output.
    /// </summary>
    public record BackfillOrderPaymentSyncCommand(List<int> OrderIds) : IRequest<Result<List<int>>>;

    public class BackfillOrderPaymentSyncCommandHandler
        : IRequestHandler<BackfillOrderPaymentSyncCommand, Result<List<int>>>
    {
        private readonly IDataContext _dataContext;
        private readonly ILogger<BackfillOrderPaymentSyncCommandHandler> _logger;

        public BackfillOrderPaymentSyncCommandHandler(
            IDataContext dataContext,
            ILogger<BackfillOrderPaymentSyncCommandHandler> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public async Task<Result<List<int>>> Handle(
            BackfillOrderPaymentSyncCommand command, CancellationToken cancellationToken)
        {
            var query = _dataContext.Get<Order>().Include(o => o.Payments).AsQueryable();

            query = command.OrderIds is { Count: > 0 }
                ? query.Where(o => command.OrderIds.Contains(o.Id))
                : query.Where(o => o.Payments.Any(p => p.PaymentStatus == PaymentStatus.Paid));

            var orders = await query.ToListAsync(cancellationToken);
            var fixedIds = new List<int>();

            foreach (var order in orders)
            {
                var before = (order.PaidAmount, order.DueAmount, order.PaymentStatus);
                PaymentSyncHelper.SyncOrderPaymentState(order, order.Payments);

                if (before != (order.PaidAmount, order.DueAmount, order.PaymentStatus))
                {
                    _dataContext.Get<Order>().Update(order);
                    fixedIds.Add(order.Id);
                }
            }

            if (fixedIds.Count > 0)
            {
                await _dataContext.SaveChangesAsync(cancellationToken);
                _logger.LogInformation(
                    "Payment-sync backfill applied to {Count} order(s): {OrderIds}",
                    fixedIds.Count, string.Join(",", fixedIds));
            }

            return await Result<List<int>>.SuccessAsync(fixedIds);
        }
    }
}
