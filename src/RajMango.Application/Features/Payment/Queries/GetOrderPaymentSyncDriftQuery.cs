using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Queries
{
    public class OrderPaymentSyncDriftDto
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public decimal CurrentPaidAmount { get; set; }
        public decimal CurrentDueAmount { get; set; }
        public PaymentStatus CurrentPaymentStatus { get; set; }
        public decimal ExpectedPaidAmount { get; set; }
        public decimal ExpectedDueAmount { get; set; }
        public PaymentStatus ExpectedPaymentStatus { get; set; }
    }

    /// <summary>
    /// Read-only dry-run for the bKash payment-sync backfill — makes no changes.
    /// Lists orders whose stored PaidAmount/DueAmount/PaymentStatus disagree with what
    /// PaymentSyncHelper.SyncOrderPaymentState would compute from their Paid payments today.
    /// </summary>
    public record GetOrderPaymentSyncDriftQuery : IRequest<Result<List<OrderPaymentSyncDriftDto>>>;

    public class GetOrderPaymentSyncDriftQueryHandler
        : IRequestHandler<GetOrderPaymentSyncDriftQuery, Result<List<OrderPaymentSyncDriftDto>>>
    {
        private readonly IDataContext _dataContext;

        public GetOrderPaymentSyncDriftQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<OrderPaymentSyncDriftDto>>> Handle(
            GetOrderPaymentSyncDriftQuery query, CancellationToken cancellationToken)
        {
            var orders = await _dataContext.Get<Order>()
                .Include(o => o.Payments)
                .Where(o => o.Payments.Any(p => p.PaymentStatus == PaymentStatus.Paid))
                .ToListAsync(cancellationToken);

            var drifted = new List<OrderPaymentSyncDriftDto>();

            foreach (var order in orders)
            {
                // Compute on a detached scratch instance so this stays a pure read-only check —
                // the loaded/tracked order is never mutated by a dry-run.
                var scratch = new Order { TotalAmount = order.TotalAmount };
                PaymentSyncHelper.SyncOrderPaymentState(scratch, order.Payments);

                if (scratch.PaidAmount != order.PaidAmount
                    || scratch.DueAmount != order.DueAmount
                    || scratch.PaymentStatus != order.PaymentStatus)
                {
                    drifted.Add(new OrderPaymentSyncDriftDto
                    {
                        OrderId = order.Id,
                        OrderNumber = order.OrderNumber,
                        CurrentPaidAmount = order.PaidAmount,
                        CurrentDueAmount = order.DueAmount,
                        CurrentPaymentStatus = order.PaymentStatus,
                        ExpectedPaidAmount = scratch.PaidAmount,
                        ExpectedDueAmount = scratch.DueAmount,
                        ExpectedPaymentStatus = scratch.PaymentStatus,
                    });
                }
            }

            return await Result<List<OrderPaymentSyncDriftDto>>.SuccessAsync(drifted);
        }
    }
}
