using MediatR;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    public record CreateMangoAvailabilityCommand : IRequest<Result<int>>
    {
        public int MangoTypeId { get; set; }
        public int SeasonYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PricePerKg { get; set; }
        public MangoAvailabilityStatus Status { get; set; } = MangoAvailabilityStatus.Upcoming;
        public string Notes { get; set; }
        public int CreatedBy { get; set; }
    }
}
