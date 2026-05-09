using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetAllCustomerQuery : IRequest<Result<List<GetAllCustomerDto>>>;

    public class GetAllCustomerInfoQueryHandler : IRequestHandler<GetAllCustomerQuery, Result<List<GetAllCustomerDto>>>
    {
        private readonly IDataContext _dataContext;

        public GetAllCustomerInfoQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<GetAllCustomerDto>>> Handle(GetAllCustomerQuery query, CancellationToken cancellationToken)
        {
            var customers = await _dataContext.Get<Customer>()
                .Select(c => new GetAllCustomerDto
                {
                    Id           = c.Id,
                    UserId       = c.UserId,
                    FirstName    = c.FirstName,
                    LastName     = c.LastName,
                    FullName     = c.FirstName + " " + c.LastName,
                    PhoneNumber1 = c.PhoneNumber1,
                    PhoneNumber2 = c.PhoneNumber2,
                    Email        = c.Email,
                    AddressLine1 = c.AddressLine1,
                    AddressLine2 = c.AddressLine2,
                    CustomerType = c.CustomerType,
                    IsActive     = c.IsActive,
                    CreatedAt    = c.CreatedAt,
                    CreatedBy    = c.CreatedBy,
                    UpdatedAt    = c.UpdatedAt,
                    UpdatedBy    = c.UpdatedBy,
                })
                .OrderBy(c => c.FirstName).ThenBy(c => c.LastName)
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllCustomerDto>>.SuccessAsync(customers);
        }
    }
}
