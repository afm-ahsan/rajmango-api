using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RajMango.Application.DTOs.Sms;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;
using System.Text.Json;

namespace RajMango.Infrastructure.Services
{
    /// <summary>
    /// SMS delivery via the Ghonta API.
    ///
    /// Contract (POST, no auth, no body):
    ///   POST https://api.ghonta.com/api/services/app/Event/sms?toNo={phone}&amp;msg={encodedMessage}
    ///
    /// Phone format: local BD — 01XXXXXXXXX (11 digits, leading 0).
    ///
    /// Response: Abp.io JSON envelope.
    ///   Success  → HTTP 200, body "success": true
    ///   Failure  → HTTP 200 or 4xx/5xx, body "success": false, "error": { "message": "..." }
    ///   HTTP 200 alone does NOT confirm delivery; the body must be inspected.
    /// </summary>
    public class SmsService : ISmsService
    {
        private const string TrackUrl  = "https://ajwadfarms.com/track-order";
        private const string VisitUrl  = "https://ajwadfarms.com";
        private const string Brand     = "RajMango";

        private static readonly HashSet<OrderStatus> AdminAlertStatuses = new()
        {
            OrderStatus.Confirmed,
            OrderStatus.Cancelled,
            OrderStatus.Delivered,
        };

        private readonly SmsSettings _settings;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IDataContext _dataContext;
        private readonly ILogger<SmsService> _logger;

        public SmsService(
            IOptions<AppSettings> options,
            IHttpClientFactory httpClientFactory,
            IDataContext dataContext,
            ILogger<SmsService> logger)
        {
            _settings = options.Value.Sms ?? new SmsSettings();
            _httpClientFactory = httpClientFactory;
            _dataContext = dataContext;
            _logger = logger;
        }

        // ---------------------------------------------------------------------------
        // Public interface
        // ---------------------------------------------------------------------------

        public async Task SendOrderUpdateAsync(
            int userId,
            string mobileNumber,
            SmsOrderContext context,
            CancellationToken cancellationToken = default)
        {
            if (!context.HasAnyChange)
            {
                _logger.LogDebug(
                    "SMS skipped: no tracked field changed. Order={Order}", context.OrderNumber);
                return;
            }

            if (_settings.SendToCustomer)
            {
                var (message, triggerEvent) = SelectMessage(context);
                await SendInternalAsync(userId, mobileNumber, context.OrderNumber,
                    triggerEvent, message, cancellationToken);
            }

            if (_settings.SendToAdmin
                && !string.IsNullOrWhiteSpace(_settings.AdminMobileNumber)
                && context.OrderStatusChanged
                && AdminAlertStatuses.Contains(context.OrderStatus))
            {
                var adminMsg = $"{Brand} Admin: Order #{context.OrderNumber} " + context.OrderStatus switch
                {
                    OrderStatus.Confirmed => "confirmed.",
                    OrderStatus.Cancelled => "was cancelled.",
                    OrderStatus.Delivered => "delivered.",
                    _                     => $"updated to {context.OrderStatus}.",
                };
                await SendInternalAsync(null, _settings.AdminMobileNumber, context.OrderNumber,
                    $"Admin_OrderStatus_{context.OrderStatus}", adminMsg, cancellationToken);
            }
        }

        // ---------------------------------------------------------------------------
        // Template selection
        // ---------------------------------------------------------------------------

        private (string message, string triggerEvent) SelectMessage(SmsOrderContext ctx)
        {
            var limit = _settings.MaxMessageLength;
            var (detailed, mixed, _) = ComputeSummaries(ctx.Items);

            string Resolve(Func<string, string> builder)
            {
                var msg = builder(detailed);
                if (msg.Length <= limit) return msg;

                var msgMixed = builder(mixed);
                if (msgMixed.Length <= limit) return msgMixed;

                var l1 = Level1Fallback(ctx.OrderNumber, mixed);
                if (l1.Length <= limit) return l1;

                return Level2Fallback(ctx.OrderNumber);
            }

            // Priority 1: DeliveryStatus transitions (most customer-visible)
            if (ctx.DeliveryStatusChanged)
            {
                if (ctx.DeliveryStatus == DeliveryStatus.Dispatched)
                    return (Resolve(s => Dispatched(ctx.OrderNumber, s, ctx.DeliveryDate)), "DeliveryStatus_Dispatched");

                if (ctx.DeliveryStatus == DeliveryStatus.InTransit)
                    return (Resolve(s => InTransit(ctx.OrderNumber, s, ctx.DeliveryDate)), "DeliveryStatus_InTransit");

                if (ctx.DeliveryStatus == DeliveryStatus.Delivered)
                    return (Resolve(s => Delivered(ctx.OrderNumber, s)), "DeliveryStatus_Delivered");
            }

            // Priority 2: OrderStatus transitions
            if (ctx.OrderStatusChanged)
            {
                if (ctx.OrderStatus == OrderStatus.Delivered)
                    return (Resolve(s => Delivered(ctx.OrderNumber, s)), "OrderStatus_Delivered");

                if (ctx.OrderStatus == OrderStatus.Cancelled)
                    return (Resolve(s => Cancelled(ctx.OrderNumber, s)), "OrderStatus_Cancelled");
            }

            // Priority 3: Payment became Paid
            if (ctx.PaymentStatusChanged && ctx.PaymentStatus == PaymentStatus.Paid)
                return (Resolve(s => PaymentReceived(ctx.OrderNumber, s, ctx.DeliveryStatus)), "PaymentPaid");

            // Priority 4: Delivery date changed
            if (ctx.DeliveryDateChanged && ctx.DeliveryDate.HasValue)
                return (Resolve(s => DeliveryDateChanged(ctx.OrderNumber, s, ctx.DeliveryDate.Value)), "DeliveryDateUpdated");

            // Priority 5: Generic update (any other combination)
            return (Resolve(s => GenericUpdate(ctx.OrderNumber, s, ctx.OrderStatus, ctx.PaymentStatus, ctx.DeliveryStatus)), "GenericUpdate");
        }

        // ---------------------------------------------------------------------------
        // Message templates
        // ---------------------------------------------------------------------------

        private static string Dispatched(string orderNo, string mangoSummary, DateTime? date)
        {
            var dateStr   = date?.ToString("dd MMM yyyy") ?? "TBD";
            var mangoClause = string.IsNullOrEmpty(mangoSummary) ? "" : $" containing {mangoSummary}";
            return $"{Brand}: Your order #{orderNo}{mangoClause} has been dispatched.\nExpected delivery: {dateStr}.\nTrack: {TrackUrl}";
        }

        private static string InTransit(string orderNo, string mangoSummary, DateTime? date)
        {
            var dateStr   = date?.ToString("dd MMM yyyy") ?? "TBD";
            var mangoClause = string.IsNullOrEmpty(mangoSummary) ? "" : $" containing {mangoSummary}";
            return $"{Brand}: Your order #{orderNo}{mangoClause} is in transit.\nExpected delivery: {dateStr}.\nTrack: {TrackUrl}";
        }

        private static string Delivered(string orderNo, string mangoSummary)
        {
            var mangoClause = string.IsNullOrEmpty(mangoSummary) ? "" : $" containing {mangoSummary}";
            return $"{Brand}: Your order #{orderNo}{mangoClause} has been delivered.\nThank you for choosing {Brand}.\nVisit: {VisitUrl}";
        }

        private static string Cancelled(string orderNo, string mangoSummary)
        {
            var mangoClause = string.IsNullOrEmpty(mangoSummary) ? "" : $" containing {mangoSummary}";
            return $"{Brand}: Your order #{orderNo}{mangoClause} has been cancelled.\nPlease contact us if you need help.\nVisit: {VisitUrl}";
        }

        private static string PaymentReceived(string orderNo, string mangoSummary, DeliveryStatus delivery)
        {
            var deliveryLabel = delivery switch
            {
                DeliveryStatus.Dispatched => "Dispatched",
                DeliveryStatus.InTransit  => "In Transit",
                DeliveryStatus.Delivered  => "Delivered",
                DeliveryStatus.Pending    => "Pending",
                _                         => delivery.ToString(),
            };
            var mangoLine = string.IsNullOrEmpty(mangoSummary) ? "" : $"\nMango: {mangoSummary}.";
            return $"{Brand}: Payment received for order #{orderNo}.{mangoLine}\nDelivery: {deliveryLabel}.\nTrack: {TrackUrl}";
        }

        private static string DeliveryDateChanged(string orderNo, string mangoSummary, DateTime date)
        {
            var mangoLine = string.IsNullOrEmpty(mangoSummary) ? "" : $"\nMango: {mangoSummary}.";
            return $"{Brand}: Delivery date updated for order #{orderNo}.{mangoLine}\nNew delivery date: {date:dd MMM yyyy}.\nTrack: {TrackUrl}";
        }

        private static string GenericUpdate(string orderNo, string mangoSummary,
            OrderStatus order, PaymentStatus payment, DeliveryStatus delivery)
        {
            var orderLabel = order switch
            {
                OrderStatus.Pending    => "Pending",
                OrderStatus.Confirmed  => "Confirmed",
                OrderStatus.Processing => "Processing",
                OrderStatus.Shipped    => "Shipped",
                OrderStatus.Delivered  => "Delivered",
                OrderStatus.Cancelled  => "Cancelled",
                OrderStatus.Returned   => "Returned",
                _                      => order.ToString(),
            };
            var payLabel = payment switch
            {
                PaymentStatus.Unpaid  => "Unpaid",
                PaymentStatus.Paid    => "Paid",
                PaymentStatus.Partial => "Partially Paid",
                PaymentStatus.Pending => "Pending",
                PaymentStatus.Failed  => "Failed",
                PaymentStatus.Refunded => "Refunded",
                _                     => payment.ToString(),
            };
            var delLabel = delivery switch
            {
                DeliveryStatus.Pending    => "Pending",
                DeliveryStatus.Dispatched => "Dispatched",
                DeliveryStatus.InTransit  => "In Transit",
                DeliveryStatus.Delivered  => "Delivered",
                DeliveryStatus.Failed     => "Failed",
                DeliveryStatus.Returned   => "Returned",
                DeliveryStatus.Cancelled  => "Cancelled",
                _                         => delivery.ToString(),
            };
            var mangoLine = string.IsNullOrEmpty(mangoSummary) ? "" : $"\nMango: {mangoSummary}.";
            return $"{Brand}: Order #{orderNo} updated.{mangoLine}\nOrder: {orderLabel}.\nPayment: {payLabel}.\nDelivery: {delLabel}.\nTrack: {TrackUrl}";
        }

        // ---------------------------------------------------------------------------
        // Fallback templates (no event context — safe for any situation)
        // ---------------------------------------------------------------------------

        private static string Level1Fallback(string orderNo, string mangoSummary)
        {
            var mangoLine = string.IsNullOrEmpty(mangoSummary) ? "" : $"\nMango: {mangoSummary}.";
            return $"{Brand}: Order #{orderNo} updated.{mangoLine}\nTrack: {TrackUrl}";
        }

        private static string Level2Fallback(string orderNo)
            => $"{Brand}: Order #{orderNo} updated.\nTrack: {TrackUrl}";

        // ---------------------------------------------------------------------------
        // Mango summary
        // ---------------------------------------------------------------------------

        /// <summary>
        /// Returns (detailed, mixed, totalKg).
        /// detailed = "Gopalbhog 10Kg, Himsagor 20Kg"
        /// mixed    = "Mixed Mango 30Kg"
        /// totalKg  = sum of all weights
        /// Returns empty strings when items is empty (templates handle the empty case).
        /// </summary>
        private static (string detailed, string mixed, int totalKg) ComputeSummaries(
            IReadOnlyList<SmsOrderItem> items)
        {
            if (items == null || items.Count == 0)
                return ("", "", 0);

            var byType = items
                .GroupBy(i => i.MangoTypeName, StringComparer.OrdinalIgnoreCase)
                .Select(g => new { Name = g.Key, Weight = g.Sum(i => i.WeightKg) })
                .OrderBy(x => x.Name)
                .ToList();

            int total    = byType.Sum(x => x.Weight);
            string detail = string.Join(", ", byType.Select(x => $"{x.Name} {x.Weight}Kg"));
            string mixed  = $"Mixed Mango {total}Kg";

            return (detail, mixed, total);
        }

        // ---------------------------------------------------------------------------
        // HTTP send + logging
        // ---------------------------------------------------------------------------

        private async Task SendInternalAsync(
            int? userId,
            string mobileNumber,
            string orderNumber,
            string triggerEvent,
            string message,
            CancellationToken cancellationToken)
        {
            var log = new SmsLog
            {
                UserId       = userId,
                OrderNumber  = orderNumber,
                TriggerEvent = triggerEvent,
                Message      = message,
                Status       = SmsLogStatus.Failed,
                SentAt       = Clock.Now(),
            };

            try
            {
                if (!_settings.IsEnabled)
                {
                    _logger.LogInformation(
                        "SMS skipped (disabled): Event={Event}, Order={Order}", triggerEvent, orderNumber);
                    log.Status       = SmsLogStatus.Skipped;
                    log.ErrorMessage = "SMS disabled in configuration.";
                    await PersistLogAsync(log, cancellationToken);
                    return;
                }

                var phone = NormalizeToLocalPhone(mobileNumber);
                if (string.IsNullOrWhiteSpace(phone))
                {
                    _logger.LogWarning(
                        "SMS skipped: No valid phone. Event={Event}, Order={Order}, UserId={UserId}",
                        triggerEvent, orderNumber, userId);
                    log.Status       = SmsLogStatus.Skipped;
                    log.ErrorMessage = "No phone number available.";
                    await PersistLogAsync(log, cancellationToken);
                    return;
                }

                // Dev/test redirect — admin SMS are never redirected.
                if (!string.IsNullOrWhiteSpace(_settings.TestMobileNumber)
                    && !triggerEvent.StartsWith("Admin_"))
                {
                    var testPhone = NormalizeToLocalPhone(_settings.TestMobileNumber);
                    if (!string.IsNullOrWhiteSpace(testPhone))
                    {
                        _logger.LogWarning(
                            "SMS dev redirect: real={RealMasked} → test={TestMasked}. Event={Event}, Order={Order}",
                            MaskPhone(phone), MaskPhone(testPhone), triggerEvent, orderNumber);
                        phone = testPhone;
                    }
                }

                log.MobileNumber = phone;

                // Message length guard — fallback is already applied by SelectMessage;
                // this is a defensive last-resort only.
                if (message.Length > _settings.MaxMessageLength)
                {
                    _logger.LogWarning(
                        "SMS message still exceeds limit after template fallback ({Len}/{Max}). Truncating at word boundary. Event={Event}, Order={Order}",
                        message.Length, _settings.MaxMessageLength, triggerEvent, orderNumber);
                    message = TruncateAtWordBoundary(message, _settings.MaxMessageLength);
                    log.Message = message;
                }

                var requestUrl = $"{_settings.BaseUrl}?toNo={Uri.EscapeDataString(phone)}&msg={Uri.EscapeDataString(message)}";

                _logger.LogDebug(
                    "SMS POST {Url}", requestUrl.Replace(phone, MaskPhone(phone)));

                var client   = _httpClientFactory.CreateClient("Sms");
                var response = await client.PostAsync(requestUrl, content: null, cancellationToken);

                var body = await response.Content.ReadAsStringAsync(cancellationToken);
                log.HttpStatusCode   = (int)response.StatusCode;
                log.ProviderResponse = body.Length > 1000 ? body[..1000] : body;

                var (providerSuccess, providerError) = ParseAbpResponse(body);
                if (providerSuccess == null) providerSuccess = response.IsSuccessStatusCode;

                if (providerSuccess == true)
                {
                    log.Status = SmsLogStatus.Sent;
                    _logger.LogInformation(
                        "SMS sent: Event={Event}, Order={Order}, Mobile={MaskedMobile}, HttpStatus={HttpStatus}",
                        triggerEvent, orderNumber, MaskPhone(phone), (int)response.StatusCode);
                }
                else
                {
                    log.Status       = SmsLogStatus.Failed;
                    log.ErrorMessage = providerError ?? $"Provider returned HTTP {(int)response.StatusCode}.";
                    _logger.LogWarning(
                        "SMS failed: Event={Event}, Order={Order}, Mobile={MaskedMobile}, HttpStatus={HttpStatus}, Error={Error}",
                        triggerEvent, orderNumber, MaskPhone(phone), (int)response.StatusCode, log.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                log.Status       = SmsLogStatus.Failed;
                log.ErrorMessage = ex.Message.Length > 500 ? ex.Message[..500] : ex.Message;
                _logger.LogError(ex,
                    "SMS exception: Event={Event}, Order={Order}, UserId={UserId}",
                    triggerEvent, orderNumber, userId);
            }
            finally
            {
                await PersistLogAsync(log, cancellationToken);
            }
        }

        private async Task PersistLogAsync(SmsLog log, CancellationToken cancellationToken)
        {
            try
            {
                _dataContext.Get<SmsLog>().Add(log);
                await _dataContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Failed to persist SmsLog: Order={Order}, Event={Event}",
                    log.OrderNumber, log.TriggerEvent);
            }
        }

        // ---------------------------------------------------------------------------
        // Response parsing
        // ---------------------------------------------------------------------------

        private static (bool? success, string errorMessage) ParseAbpResponse(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return (null, null);
            try
            {
                using var doc = JsonDocument.Parse(body);
                var root = doc.RootElement;
                if (!root.TryGetProperty("success", out var prop)) return (null, null);
                bool ok = prop.GetBoolean();
                string err = null;
                if (!ok
                    && root.TryGetProperty("error", out var errProp)
                    && errProp.ValueKind == JsonValueKind.Object
                    && errProp.TryGetProperty("message", out var msgProp))
                    err = msgProp.GetString();
                return (ok, err);
            }
            catch { return (null, null); }
        }

        // ---------------------------------------------------------------------------
        // Phone normalisation + masking
        // ---------------------------------------------------------------------------

        private static string NormalizeToLocalPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return string.Empty;
            phone = phone.Trim().Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            if (phone.StartsWith("+880"))  return "0" + phone[4..];
            if (phone.StartsWith("00880")) return "0" + phone[5..];
            if (phone.StartsWith("880") && phone.Length >= 13) return "0" + phone[3..];
            if (phone.StartsWith("0"))    return phone;
            return phone;
        }

        private static string MaskPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone) || phone.Length < 6) return "***";
            const int v = 3;
            return phone[..v] + new string('*', phone.Length - v * 2) + phone[^v..];
        }

        // ---------------------------------------------------------------------------
        // Helpers
        // ---------------------------------------------------------------------------

        /// <summary>Truncates at the last space before the limit so no word is split.</summary>
        private static string TruncateAtWordBoundary(string text, int limit)
        {
            if (text.Length <= limit) return text;
            int cut = text.LastIndexOf(' ', limit);
            return cut > 0 ? text[..cut] : text[..limit];
        }
    }
}
