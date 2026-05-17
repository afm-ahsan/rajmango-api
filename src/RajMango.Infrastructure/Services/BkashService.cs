using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RajMango.Application.Interfaces;
using RajMango.Shared;
using System.Net.Http.Headers;
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

            var response = await client.PostAsJsonAsync("checkout/create", new
            {
                mode = "0011",
                payerReference = payerReference,
                callbackURL = _settings.CallbackUrl,
                amount = amount.ToString("F2"),
                currency = "BDT",
                intent = "sale",
                merchantInvoiceNumber = merchantInvoiceNumber,
            }, cancellationToken);

            var body = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogInformation("bKash CreatePayment invoice={Invoice} statusCode={Code}",
                merchantInvoiceNumber, TryGetStatusCode(body));

            var json = JsonDocument.Parse(body).RootElement;
            return new BkashCreatePaymentResponse(
                PaymentId: GetString(json, "paymentID"),
                BkashUrl: GetString(json, "bkashURL"),
                TransactionStatus: GetString(json, "transactionStatus"),
                StatusCode: GetString(json, "statusCode"),
                StatusMessage: GetString(json, "statusMessage"));
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
            _logger.LogInformation("bKash ExecutePayment paymentId={PaymentId} statusCode={Code}",
                paymentId, TryGetStatusCode(body));

            var json = JsonDocument.Parse(body).RootElement;
            return new BkashExecutePaymentResponse(
                PaymentId: GetString(json, "paymentID"),
                TrxId: GetString(json, "trxID"),
                CustomerMsisdn: GetString(json, "customerMsisdn"),
                Amount: GetString(json, "amount"),
                TransactionStatus: GetString(json, "transactionStatus"),
                StatusCode: GetString(json, "statusCode"),
                StatusMessage: GetString(json, "statusMessage"));
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
            _logger.LogInformation("bKash QueryPayment paymentId={PaymentId} statusCode={Code}",
                paymentId, TryGetStatusCode(body));

            var json = JsonDocument.Parse(body).RootElement;
            return new BkashQueryPaymentResponse(
                PaymentId: GetString(json, "paymentID"),
                TrxId: GetString(json, "trxID"),
                Amount: GetString(json, "amount"),
                TransactionStatus: GetString(json, "transactionStatus"),
                StatusCode: GetString(json, "statusCode"),
                StatusMessage: GetString(json, "statusMessage"));
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
            request.Headers.Add("username", _settings.Username);
            request.Headers.Add("password", _settings.Password);
            request.Content = JsonContent.Create(new
            {
                app_key = _settings.AppKey,
                app_secret = _settings.AppSecret,
            });

            var response = await client.SendAsync(request, ct);
            var body = await response.Content.ReadAsStringAsync(ct);

            var json = JsonDocument.Parse(body).RootElement;
            return json.GetProperty("id_token").GetString()
                ?? throw new InvalidOperationException("bKash token grant returned empty id_token.");
        }

        private void ApplyAuthHeaders(HttpClient client, string idToken)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", idToken);
            client.DefaultRequestHeaders.Remove("X-APP-Key");
            client.DefaultRequestHeaders.Add("X-APP-Key", _settings.AppKey);
        }

        private static string GetString(JsonElement element, string property)
        {
            if (element.TryGetProperty(property, out var val))
                return val.GetString() ?? string.Empty;
            return string.Empty;
        }

        private static string TryGetStatusCode(string body)
        {
            try
            {
                return GetString(JsonDocument.Parse(body).RootElement, "statusCode");
            }
            catch
            {
                return "parse-error";
            }
        }
    }
}
