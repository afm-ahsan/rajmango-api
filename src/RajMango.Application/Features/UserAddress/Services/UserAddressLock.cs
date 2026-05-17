using RajMango.Application.Common;

namespace RajMango.Application.Features.Services
{
    public interface IUserAddressLock
    {
        Task<IDisposable> AcquireAsync();
    }

    public class UserAddressLock : AsyncLock<UserAddressLock>, IUserAddressLock { }
}
