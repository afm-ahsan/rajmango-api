using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using RajMango.Application.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RajMango.Infrastructure.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger<RedisCacheService> _logger;

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonStringEnumConverter() },
        };

        public RedisCacheService(IDistributedCache distributedCache, ILogger<RedisCacheService> logger)
        {
            _distributedCache = distributedCache;
            _logger = logger;
        }

        public async Task<T> GetAsync<T>(string key, CancellationToken ct = default)
        {
            try
            {
                var json = await _distributedCache.GetStringAsync(key, ct);
                return string.IsNullOrEmpty(json)
                    ? default
                    : JsonSerializer.Deserialize<T>(json, _jsonOptions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Cache GET failed for key '{Key}' — cache miss assumed", key);
                return default;
            }
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null, CancellationToken ct = default)
        {
            try
            {
                var json = JsonSerializer.Serialize(value, _jsonOptions);
                var options = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = expiry ?? TimeSpan.FromMinutes(10),
                };
                await _distributedCache.SetStringAsync(key, json, options, ct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Cache SET failed for key '{Key}'", key);
            }
        }

        public async Task RemoveAsync(string key, CancellationToken ct = default)
        {
            try
            {
                await _distributedCache.RemoveAsync(key, ct);
                _logger.LogDebug("Cache REMOVE: {Key}", key);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Cache REMOVE failed for key '{Key}'", key);
            }
        }
    }
}
