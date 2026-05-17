namespace RajMango.Application.Common
{
    // Semaphore-based async lock. Each concrete type T gets its own static semaphore,
    // so different lock types never block each other.
    // Usage: class MyLock : AsyncLock<MyLock>, IMyLock { }
    public abstract class AsyncLock<T>
    {
        private static readonly SemaphoreSlim _semaphore = new(1, 1);

        public async Task<IDisposable> AcquireAsync()
        {
            await _semaphore.WaitAsync();
            return new Releaser(_semaphore);
        }

        private sealed class Releaser : IDisposable
        {
            private readonly SemaphoreSlim _s;
            public Releaser(SemaphoreSlim s) => _s = s;
            public void Dispose() => _s.Release();
        }
    }
}
