using MediatR;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Courier.RateConfig.Commands
{
    public record CreateCourierRateConfigCommand : IRequest<Result<int>>
    {
        public int CourierProviderId { get; set; }
        public CourierLocationType CourierLocationType { get; set; }
        public decimal RatePerKg { get; set; }
        public decimal? MinimumCharge { get; set; }
        public bool IsActive { get; set; } = true;
        public int Sequence { get; set; }
    }
}
