using MediatR;
using RajMango.Shared;
using System.ComponentModel.DataAnnotations;

namespace RajMango.Application.Features.Commands
{
    public record DeleteCourierAreaMapCommand : IRequest<Result<int>>
    {
        [Required]
        public int Id { get; set; }
    }
}
