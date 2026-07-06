using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RajMango.Application.Common;
using RajMango.Application.DTOs.Bkash;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;
using System.Text.Json;

namespace RajMango.Application.Features.Commands
{
    internal class InitiateBkashPaymentCommandHandler
        : IRequestHandler<InitiateBkashPaymentCommand, Result<BkashInitiateResponseDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IBkashService _bkash;
        private readonly IPaymentLock _paymentLock;
        private readonly INotificationService _notification;
        private readonly IRealtimeService _realtime;
        private readonly BkashSettings _settings;
        private readonly ILogger<InitiateBkashPaymentCommandHandler> _logger;

        public InitiateBkashPaymentCommandHandler(
            IDataContext dataContext,
            ICurrentUserService currentUserService,
            IBkashService bkash,
            IPaymentLock paymentLock,
            INotificationService notification,
            IRealtimeService realtime,
            IOptions<BkashSettings> options,
            ILogger<InitiateBkashPaymentCommandHandler> logger)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
            _bkash = bkash;
            _paymentLock = paymentLock;
            _notification = notification;
            _realtime = realtime;
            _settings = options.Value
                ?? throw new InvalidOperationException("Bkash settings not configured.");
            _logger = logger;
        }

        public async Task<Result<BkashInitiateResponseDto>> Handle(
            InitiateBkashPaymentCommand command, CancellationToken cancellationToken)
        {
            // Pre-lock ownership check (no tracking — re-fetched inside lock)
            var order = await _dataContext.Get<Order>()
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == command.OrderId, cancellationToken);

            if (order is null)
                return await Result<BkashInitiateResponseDto>.FailureAsync(
                    $"Order {command.OrderId} not found.");

            if (!_currentUserService.IsAdmin && order.UserId != _currentUserService.UserId)
                return await Result<BkashInitiateResponseDto>.FailureAsync(
                    "You are not authorised to pay for this order.");

            if (order.PaymentStatus == PaymentStatus.Paid)
                return await Result<BkashInitiateResponseDto>.FailureAsync(
                    "This order is already paid.");

            if (order.TotalAmount <= 0)
                return await Result<BkashInitiateResponseDto>.FailureAsync(
                    "Order has no payable amount.");

            // Populated inside the lock, consumed after
            string gatewayPaymentId = string.Empty;
            string merchantInvoiceNumber = string.Empty;
            string bkashUrl = string.Empty;

            using (await _paymentLock.AcquireAsync())
            {
                // Re-fetch inside lock for race-safe checks
                order = await _dataContext.Get<Order>()
                    .FirstOrDefaultAsync(o => o.Id == command.OrderId, cancellationToken);

                if (order.PaymentStatus == PaymentStatus.Paid || order.DueAmount <= 0)
                    return await Result<BkashInitiateResponseDto>.FailureAsync(
                        "This order is already paid.");

                var existingPending = await _dataContext.Get<Domain.Entities.Payment>()
                    .FirstOrDefaultAsync(p => p.OrderId == command.OrderId
                                               && p.PaymentStatus == PaymentStatus.Pending, cancellationToken);

                if (existingPending != null)
                {
                    var expiry = TimeSpan.FromMinutes(
                        _settings.PendingPaymentExpiryMinutes > 0 ? _settings.PendingPaymentExpiryMinutes : 15);
                    var age = Clock.Now() - existingPending.CreatedAt;

                    _logger.LogInformation(
                        "bKash initiate: existing pending payment for order {OrderId}: paymentId={PaymentId} ageMinutes={AgeMinutes:F1} expiryMinutes={ExpiryMinutes}",
                        command.OrderId, existingPending.GatewayPaymentId, age.TotalMinutes, expiry.TotalMinutes);

                    if (age < expiry)
                    {
                        // Still within the window — ask bKash directly in case the callback was
                        // lost (customer paid but closed the tab before the redirect landed).
                        BkashQueryPaymentResponse queryResponse = null;
                        try
                        {
                            queryResponse = await _bkash.QueryPaymentAsync(existingPending.GatewayPaymentId, cancellationToken);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogWarning(ex,
                                "bKash initiate: QueryPayment failed while reconciling paymentId={PaymentId} for order {OrderId}; treating as still in progress.",
                                existingPending.GatewayPaymentId, command.OrderId);
                        }

                        if (queryResponse != null
                            && string.Equals(queryResponse.TransactionStatus, "Completed", StringComparison.OrdinalIgnoreCase))
                        {
                            _logger.LogInformation(
                                "bKash initiate: reconciliation found paymentId={PaymentId} already Completed at bKash for order {OrderId}; finalizing now.",
                                existingPending.GatewayPaymentId, command.OrderId);

                            existingPending.PaymentStatus = PaymentStatus.Paid;
                            existingPending.GatewayTransactionId = queryResponse.TrxId;
                            // Was previously missing here — this reconciliation path finalizes a
                            // payment exactly like the callback handler does, so TransactionId must
                            // be backfilled the same way or refund eligibility (which requires a
                            // non-empty TransactionId) silently breaks for payments confirmed via
                            // this path instead of the callback.
                            if (string.IsNullOrEmpty(existingPending.TransactionId))
                            {
                                existingPending.TransactionId = queryResponse.TrxId;
                            }
                            existingPending.PaidAmount = existingPending.GrossAmount;
                            existingPending.PaidAt = Clock.Now();

                            // Excludes this payment's row, then adds back the in-memory instance
                            // just mutated above — under NoTracking a re-query would return a
                            // stale copy (PaidAmount still 0) since these edits haven't been saved yet.
                            var allPayments = await _dataContext.Get<Domain.Entities.Payment>()
                                .Where(p => p.OrderId == order.Id && p.Id != existingPending.Id)
                                .ToListAsync(cancellationToken);
                            allPayments.Add(existingPending);
                            PaymentSyncHelper.SyncOrderPaymentState(order, allPayments);
                            existingPending.DueAmount = order.DueAmount;

                            if (order.PaymentStatus == PaymentStatus.Paid && order.OrderStatus == OrderStatus.Pending)
                                order.OrderStatus = OrderStatus.Confirmed;

                            _dataContext.Get<Domain.Entities.Payment>().Update(existingPending);
                            _dataContext.Get<Order>().Update(order);
                            await _dataContext.SaveChangesAsync(cancellationToken);

                            _ = _notification.SendPaymentReceivedAsync(
                                order.UserId, order.OrderNumber, existingPending.PaidAmount, cancellationToken);
                            var paidPayload = new { PaymentId = existingPending.Id, order.OrderNumber, Amount = existingPending.PaidAmount, order.UserId };
                            _ = _realtime.SendToUserAsync(order.UserId, RealtimeEvents.PaymentReceived, paidPayload, cancellationToken);
                            _ = _realtime.SendToAdminsAsync(RealtimeEvents.PaymentReceived, paidPayload, cancellationToken);

                            return await Result<BkashInitiateResponseDto>.FailureAsync("This order is already paid.");
                        }

                        // Still genuinely in progress (or the reconciliation query itself failed) —
                        // resume the existing checkout session instead of creating a duplicate.
                        if (!string.IsNullOrEmpty(existingPending.BkashUrl))
                        {
                            _logger.LogInformation(
                                "bKash initiate: resuming existing pending payment for order {OrderId}, paymentId={PaymentId}",
                                command.OrderId, existingPending.GatewayPaymentId);
                            return await Result<BkashInitiateResponseDto>.SuccessAsync(
                                new BkashInitiateResponseDto
                                {
                                    BkashUrl = existingPending.BkashUrl,
                                    GatewayPaymentId = existingPending.GatewayPaymentId,
                                    MerchantInvoiceNumber = existingPending.MerchantInvoiceNumber,
                                    IsExistingSession = true,
                                },
                                "An active bKash payment session already exists for this order.");
                        }

                        // No checkout URL on file (e.g. a payment row created before this field
                        // existed) — fail safe rather than silently creating a duplicate attempt.
                        _logger.LogWarning(
                            "bKash initiate: existing pending payment {PaymentId} for order {OrderId} has no stored BkashUrl to resume.",
                            existingPending.GatewayPaymentId, command.OrderId);
                        return await Result<BkashInitiateResponseDto>.FailureAsync(
                            "A bKash payment is already in progress for this order. " +
                            "Please complete or wait for it to expire before trying again.");
                    }

                    // Expired — release it so a fresh attempt can proceed below.
                    _logger.LogInformation(
                        "bKash initiate: existing pending payment for order {OrderId} expired (ageMinutes={AgeMinutes:F1} >= {ExpiryMinutes}); marking Expired and allowing retry.",
                        command.OrderId, age.TotalMinutes, expiry.TotalMinutes);
                    existingPending.PaymentStatus = PaymentStatus.Expired;
                    _dataContext.Get<Domain.Entities.Payment>().Update(existingPending);
                    await _dataContext.SaveChangesAsync(cancellationToken);
                }

                merchantInvoiceNumber = $"RMG-{command.OrderId}-{Clock.Now():yyMMddHHmmssfff}";

                // bKash's checkout PAGE (not just the Create API) validates payerReference —
                // a non-phone-like value (e.g. the raw internal UserId) is a well-documented
                // cause of "Invalid page access request" once the customer is redirected there,
                // even though Create itself succeeds and returns a bKashURL.
                var customerPhone = await _dataContext.Get<AppUser>()
                    .Where(u => u.Id == order.UserId)
                    .Select(u => u.PhoneNumber)
                    .FirstOrDefaultAsync(cancellationToken);
                var payerRef = NormalizeToLocalPhone(customerPhone);
                if (string.IsNullOrEmpty(payerRef))
                {
                    _logger.LogWarning(
                        "bKash initiate: order {OrderId} customer has no usable phone number; falling back to UserId as payerReference.",
                        command.OrderId);
                    payerRef = order.UserId.ToString();
                }

                BkashCreatePaymentResponse bkashResponse;
                try
                {
                    bkashResponse = await _bkash.CreatePaymentAsync(
                        merchantInvoiceNumber, order.DueAmount, payerRef, cancellationToken);
                }
                catch (BkashApiException ex)
                {
                    // ex.Message is a clean, bKash-reported description — safe to show the customer.
                    // ex.RawResponse (already logged inside BkashService) is never returned to the client.
                    _logger.LogError(ex, "bKash CreatePayment failed for order {OrderId}: {Message}",
                        command.OrderId, ex.Message);
                    return await Result<BkashInitiateResponseDto>.FailureAsync($"bKash error: {ex.Message}");
                }
                catch (OperationCanceledException ex) when (!cancellationToken.IsCancellationRequested)
                {
                    // HttpClient.Timeout surfaces as a (non-user-requested) OperationCanceledException.
                    _logger.LogError(ex, "bKash CreatePayment timed out for order {OrderId}", command.OrderId);
                    return await Result<BkashInitiateResponseDto>.FailureAsync(
                        "The bKash payment gateway did not respond in time. Please try again.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "bKash CreatePayment failed for order {OrderId}", command.OrderId);
                    return await Result<BkashInitiateResponseDto>.FailureAsync(
                        "Could not initiate bKash payment. Please try again later.");
                }

                // Never persist a Pending payment / hand back a checkout URL unless bKash gave us
                // BOTH a paymentID and a bKashURL — a partial/malformed response is not a usable session.
                if (string.IsNullOrEmpty(bkashResponse.PaymentId)
                    || string.IsNullOrEmpty(bkashResponse.BkashUrl)
                    || bkashResponse.StatusCode != "0000")
                {
                    _logger.LogWarning(
                        "bKash CreatePayment non-success for order {OrderId}: statusCode={StatusCode} statusMessage={StatusMessage} hasPaymentId={HasPaymentId} hasBkashUrl={HasBkashUrl}",
                        command.OrderId, bkashResponse.StatusCode, bkashResponse.StatusMessage,
                        !string.IsNullOrEmpty(bkashResponse.PaymentId), !string.IsNullOrEmpty(bkashResponse.BkashUrl));
                    return await Result<BkashInitiateResponseDto>.FailureAsync(
                        $"bKash error: {bkashResponse.StatusMessage}");
                }

                gatewayPaymentId = bkashResponse.PaymentId;
                bkashUrl = bkashResponse.BkashUrl;

                var payment = new Domain.Entities.Payment
                {
                    OrderId = command.OrderId,
                    PaymentMethod = PaymentMethod.Bkash,
                    PaymentStatus = PaymentStatus.Pending,
                    GrossAmount = order.DueAmount,
                    NetAmount = order.DueAmount,
                    PaidAmount = 0,
                    GatewayPaymentId = gatewayPaymentId,
                    BkashUrl = bkashUrl,
                    MerchantInvoiceNumber = merchantInvoiceNumber,
                    RawCreateResponse = JsonSerializer.Serialize(bkashResponse),
                };

                _dataContext.Get<Domain.Entities.Payment>().Add(payment);
                await _dataContext.SaveChangesAsync(cancellationToken);
            }

            _logger.LogInformation(
                "bKash payment initiated: orderId={OrderId} gatewayPaymentId={GatewayPaymentId}",
                command.OrderId, gatewayPaymentId);

            return await Result<BkashInitiateResponseDto>.SuccessAsync(
                new BkashInitiateResponseDto
                {
                    BkashUrl = bkashUrl,
                    GatewayPaymentId = gatewayPaymentId,
                    MerchantInvoiceNumber = merchantInvoiceNumber,
                },
                "Redirect the customer to BkashUrl to complete payment.");
        }

        /// <summary>
        /// bKash expects payerReference in local BD format (01XXXXXXXXX), not +880/0088/880-prefixed —
        /// mirrors RajMango.Infrastructure.Services.SmsService's NormalizeToLocalPhone (duplicated here
        /// since Application must not depend on Infrastructure).
        /// </summary>
        private static string NormalizeToLocalPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return string.Empty;
            phone = phone.Trim().Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            if (phone.StartsWith("+880")) return "0" + phone[4..];
            if (phone.StartsWith("00880")) return "0" + phone[5..];
            if (phone.StartsWith("880") && phone.Length >= 13) return "0" + phone[3..];
            if (phone.StartsWith("0")) return phone;
            return phone;
        }
    }
}
