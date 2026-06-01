using MediatR;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Courier.RateConfig.Commands
{
    public record UpdateCourierRateConfigCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int CourierProviderId { get; set; }
        public CourierLocationType LocationType { get; set; }
        public decimal RatePerKg { get; set; }
        public decimal? MinimumCharge { get; set; }
        public bool IsActive { get; set; }
        public int Sequence { get; set; }
    }
}
