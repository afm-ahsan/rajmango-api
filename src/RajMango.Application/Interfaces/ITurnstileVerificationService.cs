namespace RajMango.Application.Interfaces
{
    public interface ITurnstileVerificationService
    {
        Task<bool> VerifyAsync(string token, CancellationToken cancellationToken = default);
    }
}
