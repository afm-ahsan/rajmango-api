using MediatR;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    public record UpdateUserAddressCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string PostalCode { get; set; }
        public AddressType AddressType { get; set; }
        public bool IsPrimary { get; set; }
    }
}
