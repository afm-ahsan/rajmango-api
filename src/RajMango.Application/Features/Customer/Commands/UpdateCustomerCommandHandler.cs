using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    internal class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public UpdateCustomerCommandHandler(IErrorHandler errorHandler, IDataContext dataContext)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _dataContext.Get<Customer>().FindAsync(new object[] { command.Id }, cancellationToken);
                if (customer == null)
                    return await Result<int>.FailureAsync($"Customer not found with Id {command.Id}.");

                customer.UserId       = command.UserId;
                customer.FirstName    = command.FirstName;
                customer.LastName     = command.LastName;
                customer.PhoneNumber1 = command.PhoneNumber1;
                customer.PhoneNumber2 = command.PhoneNumber2;
                customer.Email        = command.Email;
                customer.AddressLine1 = command.AddressLine1;
                customer.AddressLine2 = command.AddressLine2;
                customer.CustomerType = command.CustomerType;
                customer.IsActive     = command.IsActive;

                _dataContext.Get<Customer>().Update(customer);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(customer.Id, "Customer updated.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Customer update failed for Id {command.Id}.");
        }
    }
}
