namespace RajMango.Application.Features.Services
{
    public interface IRegistrationLock
    {
        Task<IDisposable> AcquireAsync();
    }

    public class RegistrationLock : IRegistrationLock
    {
        private static readonly SemaphoreSlim _semaphore = new(1, 1);

        public async Task<IDisposable> AcquireAsync()
        {
            await _semaphore.WaitAsync();
            return new Releaser(_semaphore);
        }

        private sealed class Releaser : IDisposable
        {
            private readonly SemaphoreSlim _semaphore;
            public Releaser(SemaphoreSlim semaphore) => _semaphore = semaphore;
            public void Dispose() => _semaphore.Release();
        }
    }

}
