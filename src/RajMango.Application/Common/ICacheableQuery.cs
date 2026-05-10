namespace RajMango.Application.Common
{
    /// <summary>
    /// Marker interface for MediatR queries that should be served from cache.
    /// Implement on any IRequest to opt-in to the CachingBehavior pipeline.
    /// </summary>
    public interface ICacheableQuery
    {
        string CacheKey { get; }
        TimeSpan? Expiry { get; }
    }
}
