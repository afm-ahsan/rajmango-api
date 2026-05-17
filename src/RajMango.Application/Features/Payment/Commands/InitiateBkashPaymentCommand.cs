using MediatR;
using RajMango.Application.DTOs.Bkash;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public record InitiateBkashPaymentCommand : IRequest<Result<BkashInitiateResponseDto>>
    {
        public int OrderId { get; set; }
    }
}
