using MediatR;
using RajMango.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RajMango.Application.Features.Commands
{
    public record CreateUserCommand : IRequest<Result<int>>
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string Password { get; set; }

        [StringLength(512)]
        public string ImagePath { get; set; }

        public int? RoleId { get; set; }

        public bool IsActive { get; set; }
    }
}
