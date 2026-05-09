using MediatR;
using RajMango.Shared;
using System.ComponentModel.DataAnnotations;

namespace RajMango.Application.Features.Commands
{
    public record CreateCourierAreaMapCommand : IRequest<Result<int>>
    {
        [Required]
        public int CourierStationId { get; set; }

        [Required]
        [StringLength(100)]
        public string Area { get; set; }
    }
}
