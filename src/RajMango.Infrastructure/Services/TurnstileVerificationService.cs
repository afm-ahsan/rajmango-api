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
            _settings = options.Value?.CloudflareTurnstile ?? new CloudflareTurnstileSettings();
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<bool> VerifyAsync(string token, CancellationToken cancellationToken = default)
        {
            if (!_settings.Enabled)
            {
                _logger.LogDebug("Cloudflare Turnstile is disabled. Skipping verification.");
                return true;
            }

            if (string.IsNullOrWhiteSpace(_settings.SecretKey))
            {
                _logger.LogError("Cloudflare Turnstile is enabled but SecretKey is not configured. " +
                                 "Set CLOUDFLARETURNSTILE__SECRETKEY environment variable.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(token))
            {
                _logger.LogWarning("Turnstile token is missing from request.");
                return false;
            }

            try
            {
                var verifyUrl = string.IsNullOrWhiteSpace(_settings.VerifyUrl)
                    ? "https://challenges.cloudflare.com/turnstile/v0/siteverify"
                    : _settings.VerifyUrl;

                var client = _httpClientFactory.CreateClient("Turnstile");
                var formData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("secret",   _settings.SecretKey),
                    new KeyValuePair<string, string>("response", token),
                });

                var response = await client.PostAsync(verifyUrl, formData, cancellationToken);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Turnstile siteverify returned HTTP {StatusCode}.", response.StatusCode);
                    return false;
                }

                var body = await response.Content.ReadAsStringAsync(cancellationToken);
                using var doc = JsonDocument.Parse(body);
                var success = doc.RootElement.TryGetProperty("success", out var successProp) && successProp.GetBoolean();

                if (!success)
                    _logger.LogWarning("Turnstile verification rejected token. Response: {Body}", body);

                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Turnstile verification request failed.");
                return false;
            }
        }
    }
}
