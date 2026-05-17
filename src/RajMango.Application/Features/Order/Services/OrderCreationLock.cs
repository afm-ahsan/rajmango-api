using RajMango.Application.Common;

namespace RajMango.Application.Features.Services
{
    public interface IOrderCreationLock
    {
        Task<IDisposable> AcquireAsync();
    }

    public class OrderCreationLock : AsyncLock<OrderCreationLock>, IOrderCreationLock { }
}
