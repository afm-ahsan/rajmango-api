using MediatR;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    public record UpdateMangoAvailabilityStatusCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public MangoAvailabilityStatus NewStatus { get; set; }
        public int UpdatedBy { get; set; }
    }
}
