using MediatR;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public record UpdateMyProfileCommand : IRequest<Result<int>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        // Password change is optional. If NewPassword is provided, CurrentPassword is required.
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
