using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<InitiateBkashPaymentCommandHandler> _logger;

        public InitiateBkashPaymentCommandHandler(
            IDataContext dataContext,
            ICurrentUserService currentUserService,
            IBkashService bkash,
            IPaymentLock paymentLock,
            ILogger<InitiateBkashPaymentCommandHandler> logger)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
            _bkash = bkash;
            _paymentLock = paymentLock;
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
                    "This order is already fully paid.");

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
                        "This order is already fully paid.");

                // Prevent duplicate concurrent initiation for the same order
                var hasPending = await _dataContext.Get<Domain.Entities.Payment>()
                    .AnyAsync(p => p.OrderId == command.OrderId
                                   && p.PaymentStatus == PaymentStatus.Pending, cancellationToken);
                if (hasPending)
                    return await Result<BkashInitiateResponseDto>.FailureAsync(
                        "A bKash payment is already in progress for this order. " +
                        "Please complete or wait for it to expire before trying again.");

                merchantInvoiceNumber = $"RMG-{command.OrderId}-{Clock.Now():yyMMddHHmmssfff}";
                var payerRef = order.UserId.ToString();

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

                if (string.IsNullOrEmpty(bkashResponse.BkashUrl)
                    || bkashResponse.StatusCode != "0000")
                {
                    _logger.LogWarning(
                        "bKash CreatePayment non-success for order {OrderId}: {StatusCode} {StatusMessage}",
                        command.OrderId, bkashResponse.StatusCode, bkashResponse.StatusMessage);
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
    }
}
