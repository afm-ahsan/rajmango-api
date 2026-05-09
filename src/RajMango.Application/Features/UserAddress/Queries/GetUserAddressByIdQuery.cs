using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetUserAddressByIdQuery(int Id) : IRequest<Result<UserAddressDto>>;

    public class GetUserAddressByIdQueryHandler : IRequestHandler<GetUserAddressByIdQuery, Result<UserAddressDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetUserAddressByIdQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<UserAddressDto>> Handle(GetUserAddressByIdQuery query, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            var dto = await _dataContext.Get<UserAddress>()
                .Where(a => a.Id == query.Id && a.UserId == userId)
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
                .FirstOrDefaultAsync(cancellationToken);

            if (dto == null)
                return await Result<UserAddressDto>.FailureAsync($"Address not found with Id {query.Id}.");

            return await Result<UserAddressDto>.SuccessAsync(dto);
        }
    }
}
