using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    internal class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public CreateCustomerCommandHandler(IErrorHandler errorHandler, IDataContext dataContext)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var customer = new Customer
                {
                    UserId       = command.UserId,
                    FirstName    = command.FirstName,
                    LastName     = command.LastName,
                    PhoneNumber1 = command.PhoneNumber1,
                    PhoneNumber2 = command.PhoneNumber2,
                    Email        = command.Email,
                    AddressLine1 = command.AddressLine1,
                    AddressLine2 = command.AddressLine2,
                    CustomerType = command.CustomerType,
                    IsActive     = command.IsActive,
                };

                _dataContext.Get<Customer>().Add(customer);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(customer.Id, "Customer created.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync("Customer creation failed.");
        }
    }
}
