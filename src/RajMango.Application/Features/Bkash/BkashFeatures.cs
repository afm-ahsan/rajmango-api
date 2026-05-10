using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RajMango.Application.Features.Services;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Bkash
{
    // ── Initiate ────────────────────────────────────────────────────────────

    public record InitiateBkashPaymentCommand : IRequest<Result<InitiateBkashPaymentResponse>>
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
    }

    public record InitiateBkashPaymentResponse(string PaymentId, string BkashUrl);

    public class InitiateBkashPaymentCommandValidator : AbstractValidator<InitiateBkashPaymentCommand>
    {
        public InitiateBkashPaymentCommandValidator()
        {
            RuleFor(x => x.OrderId).GreaterThan(0).WithMessage("A valid order must be specified.");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero.");
        }
    }

    public class InitiateBkashPaymentCommandHandler
        : IRequestHandler<InitiateBkashPaymentCommand, Result<InitiateBkashPaymentResponse>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IBkashService _bkashService;
        private readonly ILogger<InitiateBkashPaymentCommandHandler> _logger;

        public InitiateBkashPaymentCommandHandler(
            IDataContext dataContext,
            ICurrentUserService currentUserService,
            IBkashService bkashService,
            ILogger<InitiateBkashPaymentCommandHandler> logger)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
            _bkashService = bkashService;
            _logger = logger;
        }

        public async Task<Result<InitiateBkashPaymentResponse>> Handle(
            InitiateBkashPaymentCommand command, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            var order = await _dataContext.Get<Order>()
                .FirstOrDefaultAsync(o => o.Id == command.OrderId && o.UserId == userId, cancellationToken);

            if (order == null)
                return await Result<InitiateBkashPaymentResponse>.FailureAsync("Order not found.");

            if (order.DueAmount <= 0)
                return await Result<InitiateBkashPaymentResponse>.FailureAsync("This order is already fully paid.");

            if (command.Amount > order.DueAmount)
                return await Result<InitiateBkashPaymentResponse>.FailureAsync(
                    $"Payment of {command.Amount:F2} exceeds the outstanding due amount of {order.DueAmount:F2}.");

            try
            {
                var token = await _bkashService.GrantTokenAsync(cancellationToken);

                var createResult = await _bkashService.CreatePaymentAsync(
                    idToken: token.IdToken,
                    merchantInvoiceNumber: order.OrderNumber,
                    amount: command.Amount,
                    payerReference: userId.ToString(),
                    cancellationToken: cancellationToken);

                if (createResult.StatusCode != "0000" || string.IsNullOrEmpty(createResult.PaymentId))
                {
                    _logger.LogWarning("bKash CreatePayment failed: {Code} {Message}",
                        createResult.StatusCode, createResult.StatusMessage);
                    return await Result<InitiateBkashPaymentResponse>.FailureAsync(
                        $"bKash payment initiation failed: {createResult.StatusMessage}");
                }

                return await Result<InitiateBkashPaymentResponse>.SuccessAsync(
                    new InitiateBkashPaymentResponse(createResult.PaymentId, createResult.BkashUrl),
                    "bKash payment initiated.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "bKash initiation error for Order {OrderId}", command.OrderId);
                return await Result<InitiateBkashPaymentResponse>.FailureAsync(
                    "Unable to connect to bKash. Please try again.");
            }
        }
    }

    // ── Execute ─────────────────────────────────────────────────────────────

    public record ExecuteBkashPaymentCommand : IRequest<Result<int>>
    {
        public string PaymentId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
    }

    public class ExecuteBkashPaymentCommandValidator : AbstractValidator<ExecuteBkashPaymentCommand>
    {
        public ExecuteBkashPaymentCommandValidator()
        {
            RuleFor(x => x.PaymentId).NotEmpty().WithMessage("PaymentId is required.");
            RuleFor(x => x.OrderId).GreaterThan(0).WithMessage("A valid order must be specified.");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero.");
        }
    }

    public class ExecuteBkashPaymentCommandHandler : IRequestHandler<ExecuteBkashPaymentCommand, Result<int>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IBkashService _bkashService;
        private readonly INotificationService _notificationService;
        private readonly ILogger<ExecuteBkashPaymentCommandHandler> _logger;

        public ExecuteBkashPaymentCommandHandler(
            IDataContext dataContext,
            ICurrentUserService currentUserService,
            IBkashService bkashService,
            INotificationService notificationService,
            ILogger<ExecuteBkashPaymentCommandHandler> logger)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
            _bkashService = bkashService;
            _notificationService = notificationService;
            _logger = logger;
        }

        public async Task<Result<int>> Handle(ExecuteBkashPaymentCommand command, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            var order = await _dataContext.Get<Order>()
                .FirstOrDefaultAsync(o => o.Id == command.OrderId && o.UserId == userId, cancellationToken);

            if (order == null)
                return await Result<int>.FailureAsync("Order not found.");

            if (order.DueAmount <= 0)
                return await Result<int>.FailureAsync("This order is already fully paid.");

            if (command.Amount > order.DueAmount)
                return await Result<int>.FailureAsync(
                    $"Payment of {command.Amount:F2} exceeds the outstanding due amount of {order.DueAmount:F2}.");

            // Guard: duplicate bKash transaction for this order
            var alreadyProcessed = await _dataContext.Get<Payment>()
                .AnyAsync(p => p.TransactionId == command.PaymentId, cancellationToken);
            if (alreadyProcessed)
                return await Result<int>.FailureAsync("This bKash payment has already been processed.");

            try
            {
                var token = await _bkashService.GrantTokenAsync(cancellationToken);

                var executeResult = await _bkashService.ExecutePaymentAsync(
                    token.IdToken, command.PaymentId, cancellationToken);

                if (executeResult.TransactionStatus != "Completed")
                {
                    _logger.LogWarning("bKash Execute failed: {Code} {Message} Status={Status}",
                        executeResult.StatusCode, executeResult.StatusMessage, executeResult.TransactionStatus);
                    return await Result<int>.FailureAsync(
                        $"bKash payment not completed: {executeResult.StatusMessage}");
                }

                // Record payment in our system
                var payment = new Payment
                {
                    OrderId       = command.OrderId,
                    PaidAmount    = command.Amount,
                    GrossAmount   = command.Amount,
                    NetAmount     = command.Amount,
                    PaymentMethod = PaymentMethod.MobilePayment,
                    TransactionId = executeResult.TrxId,
                    CreatedBy     = userId,
                    CreatedAt     = Clock.Now(),
                };

                _dataContext.Get<Payment>().Add(payment);
                await _dataContext.SaveChangesAsync(cancellationToken);

                var allPayments = await _dataContext.Get<Payment>()
                    .Where(p => p.OrderId == command.OrderId)
                    .ToListAsync(cancellationToken);

                PaymentSyncHelper.SyncOrderPaymentState(order, allPayments);

                payment.DueAmount     = order.DueAmount;
                payment.PaymentStatus = order.PaymentStatus;

                _dataContext.Get<Order>().Update(order);
                _dataContext.Get<Payment>().Update(payment);
                await _dataContext.SaveChangesAsync(cancellationToken);

                await _notificationService.SendPaymentReceivedAsync(
                    order.UserId, order.OrderNumber, command.Amount, cancellationToken);

                return await Result<int>.SuccessAsync(payment.Id, "bKash payment completed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "bKash execute error: PaymentId={PaymentId}", command.PaymentId);
                return await Result<int>.FailureAsync("Unable to complete bKash payment. Please contact support.");
            }
        }
    }
}
