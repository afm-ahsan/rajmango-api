using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetCustomerByIdQuery(int Id) : IRequest<Result<GetCustomerByIdDto>>;

    public class GetCustomerInfoByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Result<GetCustomerByIdDto>>
    {
        private readonly IDataContext _dataContext;

        public GetCustomerInfoByIdQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<GetCustomerByIdDto>> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            var customer = await _dataContext.Get<Customer>()
                .Where(c => c.Id == query.Id)
                .Select(c => new GetCustomerByIdDto
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
                .FirstOrDefaultAsync(cancellationToken);

            if (customer == null)
                return await Result<GetCustomerByIdDto>.FailureAsync($"Customer not found with Id {query.Id}.");

            return await Result<GetCustomerByIdDto>.SuccessAsync(customer);
        }
    }
}
