using RajMango.Application.DTOs.Email;

namespace RajMango.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequestDto request);
    }
}
