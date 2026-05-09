using MediatR;
using RajMango.Shared;
using System.ComponentModel.DataAnnotations;

namespace RajMango.Application.Features.Commands
{
    public record UpdateCourierProviderCommand : IRequest<Result<int>>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(15)]
        public string SupportPhone { get; set; }

        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}
