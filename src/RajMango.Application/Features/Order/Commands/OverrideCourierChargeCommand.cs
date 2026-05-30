using MediatR;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public record OverrideCourierChargeCommand : IRequest<Result<int>>
    {
        public int OrderId { get; set; }
        public decimal CourierChargeOverrideAmount { get; set; }
        public string CourierChargeNote { get; set; }
    }
}
