using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public class DeleteMangoTypeCommandHandler : IRequestHandler<DeleteMangoTypeCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public DeleteMangoTypeCommandHandler(IErrorHandler errorHandler, IDataContext dataContext)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(DeleteMangoTypeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dataContext.Get<MangoType>().FindAsync(command.Id);
                if (user != null)
                {
                    _dataContext.Get<MangoType>().Remove(user);

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(user.Id, "Mango type is Deleted");
                }
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }

            return await Result<int>.FailureAsync($"Mango type is not found with the Id - {command.Id}");
        }
    }
}
