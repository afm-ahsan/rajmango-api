using RajMango.Application.Common;

namespace RajMango.Application.Features.Services
{
    public interface IPaymentLock
    {
        Task<IDisposable> AcquireAsync();
    }

    public class PaymentLock : AsyncLock<PaymentLock>, IPaymentLock { }
}
