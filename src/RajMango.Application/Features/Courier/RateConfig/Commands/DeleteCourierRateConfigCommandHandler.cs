using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Courier.RateConfig.Commands
{
    internal class DeleteCourierRateConfigCommandHandler : IRequestHandler<DeleteCourierRateConfigCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public DeleteCourierRateConfigCommandHandler(IErrorHandler errorHandler, IDataContext dataContext)
        {
            _errorHandler = errorHandler;
            _dataContext  = dataContext;
        }

        public async Task<Result<int>> Handle(DeleteCourierRateConfigCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _dataContext.Get<CourierRateConfiguration>()
                    .FindAsync(new object[] { command.Id }, cancellationToken);

                if (entity == null)
                    return await Result<int>.FailureAsync($"Courier rate configuration not found with Id {command.Id}.");

                entity.IsDeleted = true;
                _dataContext.Get<CourierRateConfiguration>().Update(entity);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(entity.Id, "Courier rate configuration deleted.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Courier rate configuration deletion failed for Id {command.Id}.");
        }
    }
}
