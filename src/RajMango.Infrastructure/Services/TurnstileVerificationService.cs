using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RajMango.Application.Interfaces;
using RajMango.Shared;
using System.Net.Http.Json;
using System.Text.Json;

namespace RajMango.Infrastructure.Services
{
    public class TurnstileVerificationService : ITurnstileVerificationService
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
        };

        private readonly CloudflareTurnstileSettings _settings;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<TurnstileVerificationService> _logger;

        public TurnstileVerificationService(
            IOptions<AppSettings> options,
            IHttpClientFactory httpClientFactory,
            ILogger<TurnstileVerificationService> logger)
        {
            _settings = options.Value.CloudflareTurnstile
                ?? throw new InvalidOperationException("CloudflareTurnstile settings are not configured.");
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<bool> VerifyAsync(string token, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(token))
                return false;

            if (string.IsNullOrWhiteSpace(_settings.SecretKey))
            {
                _logger.LogWarning("Cloudflare Turnstile SecretKey is not configured. Skipping verification.");
                return false;
            }

            try
            {
                var client = _httpClientFactory.CreateClient("Turnstile");
                var formData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("secret",   _settings.SecretKey),
                    new KeyValuePair<string, string>("response", token),
                });

                var response = await client.PostAsync("siteverify", formData, cancellationToken);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Turnstile siteverify returned HTTP {StatusCode}.", response.StatusCode);
                    return false;
                }

                var body = await response.Content.ReadAsStringAsync(cancellationToken);
                using var doc = JsonDocument.Parse(body);
                return doc.RootElement.TryGetProperty("success", out var successProp) && successProp.GetBoolean();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Turnstile verification request failed.");
                return false;
            }
        }
    }
}
