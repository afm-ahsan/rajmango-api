namespace RajMango.Application.Interfaces
{
    public interface IOrderNumberService
    {
        Task<string> GenerateAsync(CancellationToken cancellationToken = default);
    }
}
