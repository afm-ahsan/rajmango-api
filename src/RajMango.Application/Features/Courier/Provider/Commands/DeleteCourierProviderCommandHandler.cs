using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public class DeleteProviderProviderCommandHandler : IRequestHandler<DeleteCourierProviderCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public DeleteProviderProviderCommandHandler(IErrorHandler errorHandler, IDataContext dataContext)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(DeleteCourierProviderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var courierProvider = await _dataContext.Get<CourierProvider>().FindAsync(command.Id);
                if (courierProvider != null)
                {
                    _dataContext.Get<CourierProvider>().Remove(courierProvider);

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(courierProvider.Id, "Courier Provider is Deleted.");
                }
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }

            return await Result<int>.FailureAsync($"Courier provider information not found with the Id - {command.Id}");
        }
    }
}
