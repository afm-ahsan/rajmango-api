using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RajMango.Application.Common;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;
using System.Text.Json;

namespace RajMango.Application.Features.Commands
{
    internal class BkashCallbackCommandHandler : IRequestHandler<BkashCallbackCommand, BkashCallbackResult>
    {
        private readonly IDataContext _dataContext;
        private readonly IBkashService _bkash;
        private readonly IRealtimeService _realtime;
        private readonly INotificationService _notification;
        private readonly ISmsService _sms;
        private readonly IPaymentLock _paymentLock;
        private readonly BkashSettings _settings;
        private readonly ILogger<BkashCallbackCommandHandler> _logger;

        public BkashCallbackCommandHandler(
            IDataContext dataContext,
            IBkashService bkash,
            IRealtimeService realtime,
            INotificationService notification,
            ISmsService sms,
            IPaymentLock paymentLock,
            IOptions<BkashSettings> options,
            ILogger<BkashCallbackCommandHandler> logger)
        {
            _dataContext = dataContext;
            _bkash = bkash;
            _realtime = realtime;
            _notification = notification;
            _sms = sms;
            _paymentLock = paymentLock;
            _settings = options.Value
                ?? throw new InvalidOperationException("Bkash settings not configured.");
            _logger = logger;
        }

        public async Task<BkashCallbackResult> Handle(
            BkashCallbackCommand command, CancellationToken cancellationToken)
        {
            var failureUrl = BuildUrl(_settings.FrontendFailureUrl, command.PaymentId);
            var cancelUrl = BuildUrl(_settings.FrontendCancelUrl, command.PaymentId);

            if (string.IsNullOrWhiteSpace(command.PaymentId))
            {
                _logger.LogWarning("bKash callback received with empty paymentID");
                return new BkashCallbackResult(false, failureUrl);
            }

            // Pre-lock existence check (no tracking — re-fetched inside the lock)
            var exists = await _dataContext.Get<Domain.Entities.Payment>()
                .AsNoTracking()
                .AnyAsync(p => p.GatewayPaymentId == command.PaymentId, cancellationToken);

            if (!exists)
            {
                _logger.LogWarning("bKash callback: no payment record found for paymentID={PaymentId}", command.PaymentId);
                return new BkashCallbackResult(false, failureUrl);
            }

            // Everything below — idempotency check through finalization — runs under the global
            // payment lock so two near-simultaneous deliveries of the same callback (bKash is
            // known to redeliver) can't both pass the Pending check and double-credit the order.
            using (await _paymentLock.AcquireAsync())
            {
                var payment = await _dataContext.Get<Domain.Entities.Payment>()
                    .Include(p => p.Order)
                    .FirstOrDefaultAsync(p => p.GatewayPaymentId == command.PaymentId, cancellationToken);

                if (payment is null)
                {
                    _logger.LogWarning("bKash callback: payment record disappeared for paymentID={PaymentId}", command.PaymentId);
                    return new BkashCallbackResult(false, failureUrl);
                }

                // Idempotency guard — already processed
                if (payment.PaymentStatus != PaymentStatus.Pending)
                {
                    _logger.LogInformation(
                        "bKash callback: paymentID={PaymentId} already in status={Status}, skipping",
                        command.PaymentId, payment.PaymentStatus);
                    var alreadyUrl = payment.PaymentStatus switch
                    {
                        PaymentStatus.Paid => BuildUrl(_settings.FrontendSuccessUrl, command.PaymentId),
                        PaymentStatus.Cancelled => cancelUrl,
                        _ => failureUrl,
                    };
                    return new BkashCallbackResult(payment.PaymentStatus == PaymentStatus.Paid, alreadyUrl);
                }

                var status = (command.Status ?? string.Empty).ToLowerInvariant();
                payment.BkashCallbackStatus = command.Status;

                if (status == "cancel")
                {
                    payment.PaymentStatus = PaymentStatus.Cancelled;
                    _dataContext.Get<Domain.Entities.Payment>().Update(payment);
                    await _dataContext.SaveChangesAsync(cancellationToken);
                    _logger.LogInformation("bKash payment cancelled by customer: paymentID={PaymentId}", command.PaymentId);
                    return new BkashCallbackResult(false, cancelUrl);
                }

                if (status != "success")
                {
                    payment.PaymentStatus = PaymentStatus.Failed;
                    _dataContext.Get<Domain.Entities.Payment>().Update(payment);
                    await _dataContext.SaveChangesAsync(cancellationToken);
                    _logger.LogWarning("bKash payment failed at gateway: paymentID={PaymentId} status={Status}",
                        command.PaymentId, command.Status);
                    return new BkashCallbackResult(false, failureUrl);
                }

                // Callback says success — must execute/verify before trusting it
                BkashExecutePaymentResponse executeResponse;
                try
                {
                    executeResponse = await _bkash.ExecutePaymentAsync(command.PaymentId, cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "bKash ExecutePayment threw for paymentID={PaymentId}", command.PaymentId);
                    payment.PaymentStatus = PaymentStatus.Failed;
                    _dataContext.Get<Domain.Entities.Payment>().Update(payment);
                    await _dataContext.SaveChangesAsync(cancellationToken);
                    return new BkashCallbackResult(false, failureUrl);
                }

                payment.RawExecuteResponse = JsonSerializer.Serialize(executeResponse);

                var transactionStatus = executeResponse.TransactionStatus;

                // If execute says anything other than "Completed", query to get ground truth
                if (!string.Equals(transactionStatus, "Completed", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        var queryResponse = await _bkash.QueryPaymentAsync(command.PaymentId, cancellationToken);
                        transactionStatus = queryResponse.TransactionStatus;
                        _logger.LogInformation(
                            "bKash QueryPayment fallback for paymentID={PaymentId} transactionStatus={Status}",
                            command.PaymentId, transactionStatus);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "bKash QueryPayment threw for paymentID={PaymentId}", command.PaymentId);
                    }
                }

                if (!string.Equals(transactionStatus, "Completed", StringComparison.OrdinalIgnoreCase))
                {
                    payment.PaymentStatus = PaymentStatus.Failed;
                    _dataContext.Get<Domain.Entities.Payment>().Update(payment);
                    await _dataContext.SaveChangesAsync(cancellationToken);
                    _logger.LogWarning(
                        "bKash payment not confirmed as Completed: paymentID={PaymentId} transactionStatus={Status}",
                        command.PaymentId, transactionStatus);
                    return new BkashCallbackResult(false, failureUrl);
                }

                // Payment confirmed as Completed — update payment + order atomically.
                // bKash has ALREADY told us this money was taken, so from here on a failure to
                // persist is a financial reconciliation gap, not a normal "payment failed" case —
                // it must never be reported back to the customer as a failure.
                payment.PaymentStatus = PaymentStatus.Paid;
                payment.GatewayTransactionId = executeResponse.TrxId;
                payment.PaidAmount = payment.GrossAmount;
                payment.PaidAt = Clock.Now();

                var order = payment.Order;
                try
                {
                    var allPayments = await _dataContext.Get<Domain.Entities.Payment>()
                        .Where(p => p.OrderId == order.Id)
                        .ToListAsync(cancellationToken);

                    PaymentSyncHelper.SyncOrderPaymentState(order, allPayments);
                    payment.DueAmount = order.DueAmount;

                    _dataContext.Get<Domain.Entities.Payment>().Update(payment);

                    // Promote order status on full payment
                    if (order.PaymentStatus == PaymentStatus.Paid
                        && order.OrderStatus == OrderStatus.Pending)
                    {
                        order.OrderStatus = OrderStatus.Confirmed;
                    }

                    _dataContext.Get<Order>().Update(order);
                    await _dataContext.SaveChangesAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    // CRITICAL: bKash confirmed and charged the customer (trxId below), but our
                    // database failed to record it. Requires manual reconciliation — search this
                    // trxId/paymentId in bKash's merchant portal and re-apply the payment by hand.
                    _logger.LogCritical(ex,
                        "RECONCILIATION REQUIRED: bKash confirmed payment but DB persist failed. " +
                        "paymentId={PaymentId} orderId={OrderId} trxId={TrxId} amount={Amount}",
                        command.PaymentId, order.Id, executeResponse.TrxId, payment.GrossAmount);

                    // Still send the customer to the success page — bKash genuinely took the money;
                    // showing "failed" here would be actively misleading.
                    return new BkashCallbackResult(true, BuildUrl(_settings.FrontendSuccessUrl, command.PaymentId));
                }

                _logger.LogInformation(
                    "bKash payment completed: orderId={OrderId} orderNumber={OrderNumber} trxId={TrxId} amount={Amount}",
                    order.Id, order.OrderNumber, executeResponse.TrxId, payment.PaidAmount);

                // In-app notification + real-time push (fire-and-forget — matches existing handlers)
                var payload = new { PaymentId = payment.Id, order.OrderNumber, Amount = payment.PaidAmount, order.UserId };
                _ = _notification.SendPaymentReceivedAsync(order.UserId, order.OrderNumber, payment.PaidAmount, cancellationToken);
                _ = _realtime.SendToUserAsync(order.UserId, RealtimeEvents.PaymentReceived, payload, cancellationToken);
                _ = _realtime.SendToAdminsAsync(RealtimeEvents.PaymentReceived, payload, cancellationToken);

                // SMS — sent only to the customer (order placer / sender), never to the delivery
                // receiver or admin. Customer phone is loaded here because it is not on the Order entity.
                var customerPhone = await _dataContext.Get<AppUser>()
                    .Where(u => u.Id == order.UserId)
                    .Select(u => u.PhoneNumber)
                    .FirstOrDefaultAsync(cancellationToken);

                if (!string.IsNullOrWhiteSpace(customerPhone))
                    _ = _sms.SendPaymentConfirmedSmsAsync(customerPhone, order.OrderNumber, order.UserId, cancellationToken);
                else
                    _logger.LogWarning(
                        "bKash payment SMS skipped: customer has no phone. orderId={OrderId} userId={UserId}",
                        order.Id, order.UserId);

                return new BkashCallbackResult(true, BuildUrl(_settings.FrontendSuccessUrl, command.PaymentId));
            }
        }

        private static string BuildUrl(string baseUrl, string paymentId)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                return "/";
            var separator = baseUrl.Contains('?') ? "&" : "?";
            return $"{baseUrl}{separator}paymentId={Uri.EscapeDataString(paymentId ?? string.Empty)}";
        }
    }
}
