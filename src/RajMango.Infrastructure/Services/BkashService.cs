using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RajMango.Application.Interfaces;
using RajMango.Shared;
using System.Net.Http.Json;
using System.Text.Json;

namespace RajMango.Infrastructure.Services
{
    public class BkashService : IBkashService
    {
        private const string TokenCacheKey = "bkash:token:idtoken";
        private static readonly TimeSpan TokenCacheExpiry = TimeSpan.FromMinutes(55);

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
        };

        private readonly BkashSettings _settings;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICacheService _cache;
        private readonly ILogger<BkashService> _logger;

        public BkashService(
            IOptions<AppSettings> options,
            IHttpClientFactory httpClientFactory,
            ICacheService cache,
            ILogger<BkashService> logger)
        {
            _settings = options.Value.Bkash
                ?? throw new InvalidOperationException("Bkash settings are not configured.");
            _httpClientFactory = httpClientFactory;
            _cache = cache;
            _logger = logger;
        }

        public async Task<BkashCreatePaymentResponse> CreatePaymentAsync(
            string merchantInvoiceNumber,
            decimal amount,
            string payerReference,
            CancellationToken cancellationToken = default)
        {
            var idToken = await GetTokenAsync(cancellationToken);
            var client = _httpClientFactory.CreateClient("Bkash");
            ApplyAuthHeaders(client, idToken);

            var requestBody = new
            {
                mode = "0011",
                payerReference = payerReference,
                callbackURL = _settings.CallbackUrl,
                amount = amount.ToString("F2"),
                currency = "BDT",
                intent = "sale",
                merchantInvoiceNumber = merchantInvoiceNumber,
            };

            // Safe to log in full — none of these fields are credentials (Authorization/X-App-Key
            // are headers, never part of this body).
            _logger.LogInformation(
                "bKash CreatePayment request: invoice={Invoice} mode={Mode} payerReference={PayerReference} " +
                "callbackURL={CallbackUrl} amount={Amount} currency={Currency} intent={Intent}",
                merchantInvoiceNumber, requestBody.mode, requestBody.payerReference, requestBody.callbackURL,
                requestBody.amount, requestBody.currency, requestBody.intent);

            var response = await client.PostAsJsonAsync("checkout/create", requestBody, cancellationToken);

            var body = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogInformation(
                "bKash CreatePayment response: invoice={Invoice} httpStatus={HttpStatus} body={Body}",
                merchantInvoiceNumber, (int)response.StatusCode, body);

            var json = TryParseJson(body, "CreatePayment", merchantInvoiceNumber, response.StatusCode);

            var paymentId = GetString(json, "paymentID");
            var bkashUrl = GetString(json, "bkashURL");

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(paymentId) || string.IsNullOrEmpty(bkashUrl))
            {
                var message = ExtractErrorMessage(json, "bKash did not accept the payment request.");
                _logger.LogError(
                    "bKash CreatePayment failed. invoice={Invoice} httpStatus={HttpStatus} message={Message} body={Body}",
                    merchantInvoiceNumber, (int)response.StatusCode, message, body);
                // Still return a structured response so the caller's existing statusCode-based
                // failure handling keeps working — StatusMessage carries whichever field bKash used.
                return new BkashCreatePaymentResponse(
                    PaymentId: paymentId,
                    BkashUrl: bkashUrl,
                    TransactionStatus: GetString(json, "transactionStatus"),
                    StatusCode: FirstNonEmpty(GetString(json, "statusCode"), GetString(json, "errorCode")),
                    StatusMessage: message);
            }

            _logger.LogInformation("bKash CreatePayment succeeded. invoice={Invoice} paymentId={PaymentId}",
                merchantInvoiceNumber, paymentId);

            return new BkashCreatePaymentResponse(
                PaymentId: paymentId,
                BkashUrl: bkashUrl,
                TransactionStatus: GetString(json, "transactionStatus"),
                StatusCode: FirstNonEmpty(GetString(json, "statusCode"), "0000"),
                StatusMessage: FirstNonEmpty(GetString(json, "statusMessage"), "Successful"));
        }

        public async Task<BkashExecutePaymentResponse> ExecutePaymentAsync(
            string paymentId,
            CancellationToken cancellationToken = default)
        {
            var idToken = await GetTokenAsync(cancellationToken);
            var client = _httpClientFactory.CreateClient("Bkash");
            ApplyAuthHeaders(client, idToken);

            var response = await client.PostAsJsonAsync("checkout/execute", new
            {
                paymentID = paymentId,
            }, cancellationToken);

            var body = await response.Content.ReadAsStringAsync(cancellationToken);
            var json = TryParseJson(body, "ExecutePayment", paymentId, response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                var message = ExtractErrorMessage(json, "bKash payment execution failed.");
                _logger.LogError(
                    "bKash ExecutePayment failed. paymentId={PaymentId} httpStatus={HttpStatus} message={Message} body={Body}",
                    paymentId, (int)response.StatusCode, message, body);
            }
            else
            {
                _logger.LogInformation("bKash ExecutePayment httpStatus={HttpStatus} transactionStatus={Status} paymentId={PaymentId}",
                    (int)response.StatusCode, GetString(json, "transactionStatus"), paymentId);
            }

            return new BkashExecutePaymentResponse(
                PaymentId: GetString(json, "paymentID"),
                TrxId: GetString(json, "trxID"),
                CustomerMsisdn: GetString(json, "customerMsisdn"),
                Amount: GetString(json, "amount"),
                TransactionStatus: GetString(json, "transactionStatus"),
                StatusCode: FirstNonEmpty(GetString(json, "statusCode"), GetString(json, "errorCode")),
                StatusMessage: FirstNonEmpty(GetString(json, "statusMessage"), GetString(json, "errorMessage")));
        }

        public async Task<BkashQueryPaymentResponse> QueryPaymentAsync(
            string paymentId,
            CancellationToken cancellationToken = default)
        {
            var idToken = await GetTokenAsync(cancellationToken);
            var client = _httpClientFactory.CreateClient("Bkash");
            ApplyAuthHeaders(client, idToken);

            var response = await client.GetAsync($"checkout/payment/query/{paymentId}", cancellationToken);
            var body = await response.Content.ReadAsStringAsync(cancellationToken);
            var json = TryParseJson(body, "QueryPayment", paymentId, response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                var message = ExtractErrorMessage(json, "bKash payment query failed.");
                _logger.LogError(
                    "bKash QueryPayment failed. paymentId={PaymentId} httpStatus={HttpStatus} message={Message} body={Body}",
                    paymentId, (int)response.StatusCode, message, body);
            }
            else
            {
                _logger.LogInformation("bKash QueryPayment httpStatus={HttpStatus} transactionStatus={Status} paymentId={PaymentId}",
                    (int)response.StatusCode, GetString(json, "transactionStatus"), paymentId);
            }

            return new BkashQueryPaymentResponse(
                PaymentId: GetString(json, "paymentID"),
                TrxId: GetString(json, "trxID"),
                Amount: GetString(json, "amount"),
                TransactionStatus: GetString(json, "transactionStatus"),
                StatusCode: FirstNonEmpty(GetString(json, "statusCode"), GetString(json, "errorCode")),
                StatusMessage: FirstNonEmpty(GetString(json, "statusMessage"), GetString(json, "errorMessage")));
        }

        private async Task<string> GetTokenAsync(CancellationToken ct)
        {
            var cached = await _cache.GetAsync<string>(TokenCacheKey, ct);
            if (!string.IsNullOrEmpty(cached))
                return cached;

            var token = await GrantTokenInternalAsync(ct);
            await _cache.SetAsync(TokenCacheKey, token, TokenCacheExpiry, ct);
            return token;
        }

        private async Task<string> GrantTokenInternalAsync(CancellationToken ct)
        {
            var client = _httpClientFactory.CreateClient("Bkash");

            var request = new HttpRequestMessage(HttpMethod.Post, "checkout/token/grant");
            request.Headers.Add("username", _settings.Username?.Trim());
            request.Headers.Add("password", _settings.Password?.Trim());
            request.Content = JsonContent.Create(new
            {
                app_key = _settings.AppKey?.Trim(),
                app_secret = _settings.AppSecret?.Trim(),
            });

            var response = await client.SendAsync(request, ct);
            var body = await response.Content.ReadAsStringAsync(ct);
            var json = TryParseJson(body, "GrantToken", null, response.StatusCode);

            var idToken = GetString(json, "id_token");
            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(idToken))
            {
                var message = ExtractErrorMessage(json, "bKash authentication failed. Check the configured credentials.");
                _logger.LogError(
                    "bKash GrantToken failed. httpStatus={HttpStatus} message={Message} body={Body}",
                    (int)response.StatusCode, message, body);
                throw new BkashApiException(message, body);
            }

            _logger.LogInformation("bKash GrantToken succeeded.");
            return idToken;
        }

        /// <summary>
        /// bKash's tokenized checkout API expects the raw id_token as the Authorization header value —
        /// NOT an OAuth-style "Bearer {token}" — per https://developer.bka.sh/docs/create-payment-2.
        /// The standard typed Authorization header always requires a scheme, so it's added as a raw
        /// header instead (bypassing format validation, which would otherwise reject a schemeless value).
        /// </summary>
        private void ApplyAuthHeaders(HttpClient client, string idToken)
        {
            client.DefaultRequestHeaders.Remove("Authorization");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", idToken);
            client.DefaultRequestHeaders.Remove("X-App-Key");
            client.DefaultRequestHeaders.Add("X-App-Key", _settings.AppKey?.Trim());
        }

        private JsonElement TryParseJson(string body, string operation, string correlationId, System.Net.HttpStatusCode httpStatus)
        {
            try
            {
                return JsonDocument.Parse(string.IsNullOrWhiteSpace(body) ? "{}" : body).RootElement;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex,
                    "bKash {Operation} returned a non-JSON response. correlationId={CorrelationId} httpStatus={HttpStatus} body={Body}",
                    operation, correlationId, (int)httpStatus, body);
                return JsonDocument.Parse("{}").RootElement;
            }
        }

        /// <summary>
        /// bKash's documented error shape is {"errorCode","errorMessage"} (different from the
        /// {"statusCode","statusMessage"} success shape) — check both, plus a generic "message" field,
        /// before falling back to a safe default.
        /// </summary>
        private static string ExtractErrorMessage(JsonElement json, string fallback)
        {
            var message = FirstNonEmpty(
                GetString(json, "errorMessage"),
                GetString(json, "statusMessage"),
                GetString(json, "message"));
            return string.IsNullOrEmpty(message) ? fallback : message;
        }

        private static string GetString(JsonElement element, string property)
        {
            if (element.ValueKind == JsonValueKind.Object && element.TryGetProperty(property, out var val))
                return val.GetString() ?? string.Empty;
            return string.Empty;
        }

        private static string FirstNonEmpty(params string[] values)
        {
            foreach (var v in values)
            {
                if (!string.IsNullOrEmpty(v)) return v;
            }
            return string.Empty;
        }
    }
}
