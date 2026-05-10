using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RajMango.Application.Interfaces;
using RajMango.Shared;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RajMango.Infrastructure.Services
{
    public class BkashService : IBkashService
    {
        private readonly BkashSettings _settings;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BkashService> _logger;

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
        };

        public BkashService(
            IOptions<AppSettings> options,
            IHttpClientFactory httpClientFactory,
            ILogger<BkashService> logger)
        {
            _settings = options.Value.Bkash
                ?? throw new InvalidOperationException("Bkash settings are not configured.");
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<BkashTokenResponse> GrantTokenAsync(CancellationToken cancellationToken = default)
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

            var response = await client.SendAsync(request, cancellationToken);
            var body = await response.Content.ReadAsStringAsync(cancellationToken);

            _logger.LogDebug("bKash GrantToken response: {Body}", body);

            var json = JsonDocument.Parse(body).RootElement;
            return new BkashTokenResponse(
                IdToken: json.GetProperty("id_token").GetString(),
                RefreshToken: json.GetProperty("refresh_token").GetString());
        }

        public async Task<BkashCreatePaymentResponse> CreatePaymentAsync(
            string idToken,
            string merchantInvoiceNumber,
            decimal amount,
            string payerReference,
            CancellationToken cancellationToken = default)
        {
            var client = _httpClientFactory.CreateClient("Bkash");
            AddAuthHeaders(client, idToken);

            var response = await client.PostAsJsonAsync("checkout/create", new
            {
                mode = "0011",
                payerReference = payerReference,
                callbackURL = "N/A",
                amount = amount.ToString("F2"),
                currency = "BDT",
                intent = "sale",
                merchantInvoiceNumber = merchantInvoiceNumber,
            }, cancellationToken);

            var body = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogDebug("bKash CreatePayment response: {Body}", body);

            var json = JsonDocument.Parse(body).RootElement;

            return new BkashCreatePaymentResponse(
                PaymentId: GetString(json, "paymentID"),
                BkashUrl: GetString(json, "bkashURL"),
                TransactionStatus: GetString(json, "transactionStatus"),
                StatusCode: GetString(json, "statusCode"),
                StatusMessage: GetString(json, "statusMessage"));
        }

        public async Task<BkashExecutePaymentResponse> ExecutePaymentAsync(
            string idToken,
            string paymentId,
            CancellationToken cancellationToken = default)
        {
            var client = _httpClientFactory.CreateClient("Bkash");
            AddAuthHeaders(client, idToken);

            var response = await client.PostAsJsonAsync("checkout/execute", new
            {
                paymentID = paymentId,
            }, cancellationToken);

            var body = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogDebug("bKash ExecutePayment response: {Body}", body);

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

        private void AddAuthHeaders(HttpClient client, string idToken)
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
    }
}
