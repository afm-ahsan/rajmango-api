using MediatR;
using RajMango.Shared;
using System.ComponentModel.DataAnnotations;

namespace RajMango.Application.Features.Commands
{
    public record UpdateUserCommand : IRequest<Result<int>>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        //public bool PhoneNumberConfirmed { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }
        //public bool EmailConfirmed { get; set; }

        [StringLength(15)]
        public string? Password { get; set; }

        [StringLength(512)]
        public string? ImagePath { get; set; }

        //public int AccessFailedCount { get; set; }

        //public bool IsLocked { get; set; }

        public int? RoleId { get; set; }

        public bool IsActive { get; set; }
    }
}
