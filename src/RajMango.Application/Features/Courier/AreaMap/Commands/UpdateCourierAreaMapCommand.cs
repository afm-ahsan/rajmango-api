using MediatR;
using RajMango.Shared;
using System.ComponentModel.DataAnnotations;

namespace RajMango.Application.Features.Commands
{
    public record UpdateCourierAreaMapCommand : IRequest<Result<int>>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CourierStationId { get; set; }

        [Required]
        [StringLength(100)]
        public string Area { get; set; }
    }
}
