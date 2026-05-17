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
        private readonly BkashSettings _settings;
        private readonly ILogger<BkashCallbackCommandHandler> _logger;

        public BkashCallbackCommandHandler(
            IDataContext dataContext,
            IBkashService bkash,
            IRealtimeService realtime,
            INotificationService notification,
            IOptions<AppSettings> options,
            ILogger<BkashCallbackCommandHandler> logger)
        {
            _dataContext = dataContext;
            _bkash = bkash;
            _realtime = realtime;
            _notification = notification;
            _settings = options.Value.Bkash
                ?? throw new InvalidOperationException("Bkash settings not configured.");
            _logger = logger;
        }

        public async Task<BkashCallbackResult> Handle(
            BkashCallbackCommand command, CancellationToken cancellationToken)
        {
            var failureUrl = BuildUrl(_settings.FrontendFailureUrl, command.PaymentId);

            if (string.IsNullOrWhiteSpace(command.PaymentId))
            {
                _logger.LogWarning("bKash callback received with empty paymentID");
                return new BkashCallbackResult(false, failureUrl);
            }

            var payment = await _dataContext.Get<Domain.Entities.Payment>()
                .Include(p => p.Order)
                .FirstOrDefaultAsync(p => p.GatewayPaymentId == command.PaymentId, cancellationToken);

            if (payment is null)
            {
                _logger.LogWarning("bKash callback: no payment record found for paymentID={PaymentId}", command.PaymentId);
                return new BkashCallbackResult(false, failureUrl);
            }

            // Idempotency guard — already processed
            if (payment.PaymentStatus != PaymentStatus.Pending)
            {
                _logger.LogInformation(
                    "bKash callback: paymentID={PaymentId} already in status={Status}, skipping",
                    command.PaymentId, payment.PaymentStatus);
                var alreadyUrl = payment.PaymentStatus == PaymentStatus.Paid
                    ? BuildUrl(_settings.FrontendSuccessUrl, command.PaymentId)
                    : failureUrl;
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
                return new BkashCallbackResult(false, failureUrl);
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

            // Payment confirmed as Completed — update payment + order atomically
            payment.PaymentStatus = PaymentStatus.Paid;
            payment.GatewayTransactionId = executeResponse.TrxId;
            payment.PaidAmount = payment.GrossAmount;
            payment.PaidAt = Clock.Now();

            _dataContext.Get<Domain.Entities.Payment>().Update(payment);

            var order = payment.Order;
            var allPayments = await _dataContext.Get<Domain.Entities.Payment>()
                .Where(p => p.OrderId == order.Id)
                .ToListAsync(cancellationToken);

            PaymentSyncHelper.SyncOrderPaymentState(order, allPayments);

            // Promote order status on full payment
            if (order.PaymentStatus == PaymentStatus.Paid
                && order.OrderStatus == OrderStatus.Pending)
            {
                order.OrderStatus = OrderStatus.Confirmed;
            }

            _dataContext.Get<Order>().Update(order);
            await _dataContext.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(
                "bKash payment completed: orderId={OrderId} trxId={TrxId} amount={Amount}",
                order.Id, executeResponse.TrxId, payment.PaidAmount);

            // Notifications (fire-and-forget pattern matches existing handlers)
            _ = _notification.SendPaymentReceivedAsync(
                order.UserId, order.OrderNumber, payment.PaidAmount, cancellationToken);

            var payload = new { PaymentId = payment.Id, order.OrderNumber, Amount = payment.PaidAmount, order.UserId };
            _ = _realtime.SendToUserAsync(order.UserId, RealtimeEvents.PaymentReceived, payload, cancellationToken);
            _ = _realtime.SendToAdminsAsync(RealtimeEvents.PaymentReceived, payload, cancellationToken);

            return new BkashCallbackResult(true, BuildUrl(_settings.FrontendSuccessUrl, command.PaymentId));
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
