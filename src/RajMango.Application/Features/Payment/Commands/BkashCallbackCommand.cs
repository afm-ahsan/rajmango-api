using MediatR;

namespace RajMango.Application.Features.Commands
{
    public record BkashCallbackCommand : IRequest<BkashCallbackResult>
    {
        public string PaymentId { get; set; }  // bKash paymentID from query string
        public string Status { get; set; }      // "success" | "failure" | "cancel"
    }

    public record BkashCallbackResult(bool IsSuccess, string RedirectUrl);
}
