using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Queries
{
    public class UserAddressDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string PostalCode { get; set; }
        public AddressType AddressType { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public record GetUserAddressesQuery : IRequest<Result<List<UserAddressDto>>>;

    public class GetUserAddressesQueryHandler : IRequestHandler<GetUserAddressesQuery, Result<List<UserAddressDto>>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetUserAddressesQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<List<UserAddressDto>>> Handle(GetUserAddressesQuery query, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            var list = await _dataContext.Get<UserAddress>()
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.IsPrimary)
                .ThenBy(a => a.CreatedAt)
                .Select(a => new UserAddressDto
                {
                    Id          = a.Id,
                    UserId      = a.UserId,
                    AddressLine = a.AddressLine,
                    City        = a.City,
                    Area        = a.Area,
                    PostalCode  = a.PostalCode,
                    AddressType = a.AddressType,
                    IsPrimary   = a.IsPrimary,
                    CreatedAt   = a.CreatedAt,
                    UpdatedAt   = a.UpdatedAt,
                })
                .ToListAsync(cancellationToken);

            return await Result<List<UserAddressDto>>.SuccessAsync(list);
        }
    }
}
