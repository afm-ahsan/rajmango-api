using MediatR;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    /// <summary>
    /// Admin-only: soft-deletes an order (and its payments) from all lists and totals,
    /// and writes an immutable audit snapshot to OrderDeletionAudit.
    ///
    /// Design: soft-delete rather than hard-delete is used so that:
    ///   • Accounting data (Payment records) survives for reconciliation.
    ///   • The order row remains for audit queries via IgnoreQueryFilters().
    ///   • The global IsDeleted filter removes the order from every consumer query
    ///     (dashboard, order list, admin list, reports) with zero code changes.
    ///   • The deletion can be reviewed or reversed by a DBA if needed.
    /// </summary>
    public record AdminPermanentDeleteOrderCommand : IRequest<Result<int>>
    {
        public int OrderId { get; set; }

        /// <summary>
        /// Admin must type the exact order number to confirm.
        /// The handler rejects the request if this does not match Order.OrderNumber.
        /// </summary>
        public string ConfirmOrderNumber { get; set; }

        /// <summary>Reason for deletion — stored in the audit trail. Required.</summary>
        public string Reason { get; set; }
    }
}
