namespace RajMango.Application.Interfaces
{
    public interface ICacheService
    {
        // Returns default(T) on cache miss or deserialization failure.
        Task<T> GetAsync<T>(string key, CancellationToken ct = default);
        Task SetAsync<T>(string key, T value, TimeSpan? expiry = null, CancellationToken ct = default);
        Task RemoveAsync(string key, CancellationToken ct = default);
    }
}
