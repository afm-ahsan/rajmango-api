using MediatR;
using Microsoft.Extensions.Logging;
using RajMango.Application.Interfaces;

namespace RajMango.Application.Common
{
    /// <summary>
    /// MediatR pipeline behavior that transparently caches query results.
    /// Only queries implementing ICacheableQuery are intercepted.
    /// Only successful results (Succeeded == true) are written to cache.
    /// </summary>
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ICacheService _cache;
        private readonly ILogger<CachingBehavior<TRequest, TResponse>> _logger;

        public CachingBehavior(ICacheService cache, ILogger<CachingBehavior<TRequest, TResponse>> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (request is not ICacheableQuery cacheable)
                return await next();

            var cached = await _cache.GetAsync<TResponse>(cacheable.CacheKey, cancellationToken);
            if (cached is not null)
            {
                _logger.LogDebug("Cache HIT: {Key}", cacheable.CacheKey);
                return cached;
            }

            var response = await next();

            // Only cache successful results — avoid caching error/failure responses
            var succeededProp = response?.GetType().GetProperty("Succeeded");
            var succeeded = succeededProp?.GetValue(response) as bool?;
            if (succeeded == true)
            {
                await _cache.SetAsync(cacheable.CacheKey, response, cacheable.Expiry, cancellationToken);
                _logger.LogDebug("Cache SET: {Key} (TTL={TTL})", cacheable.CacheKey, cacheable.Expiry);
            }

            return response;
        }
    }
}
