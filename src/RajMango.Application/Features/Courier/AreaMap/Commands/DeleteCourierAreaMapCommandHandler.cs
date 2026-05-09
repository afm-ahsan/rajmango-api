using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public class DeleteAreaMapAreaMapCommandHandler : IRequestHandler<DeleteCourierAreaMapCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public DeleteAreaMapAreaMapCommandHandler(IErrorHandler errorHandler, IDataContext dataContext)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(DeleteCourierAreaMapCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var courierAreaMap = await _dataContext.Get<CourierAreaMap>().FindAsync(command.Id);
                if (courierAreaMap != null)
                {
                    _dataContext.Get<CourierAreaMap>().Remove(courierAreaMap);

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(courierAreaMap.Id, "Courier Area Map is Deleted.");
                }
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }

            return await Result<int>.FailureAsync($"Courier area map information not found with the Id - {command.Id}");
        }
    }
}
