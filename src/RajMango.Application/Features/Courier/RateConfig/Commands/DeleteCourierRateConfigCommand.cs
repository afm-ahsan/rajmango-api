using MediatR;
using RajMango.Shared;

namespace RajMango.Application.Features.Courier.RateConfig.Commands
{
    public record DeleteCourierRateConfigCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }
}
