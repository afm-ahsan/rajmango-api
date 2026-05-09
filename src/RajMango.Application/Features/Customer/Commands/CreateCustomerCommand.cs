using MediatR;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    public record CreateCustomerCommand : IRequest<Result<int>>
    {
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public CustomerType CustomerType { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
    }
}
