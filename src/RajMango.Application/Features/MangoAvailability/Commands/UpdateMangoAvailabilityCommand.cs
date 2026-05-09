using MediatR;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    public record UpdateMangoAvailabilityCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int SeasonYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PricePerKg { get; set; }
        public MangoAvailabilityStatus Status { get; set; }
        public string Notes { get; set; }
        public int UpdatedBy { get; set; }
    }
}
