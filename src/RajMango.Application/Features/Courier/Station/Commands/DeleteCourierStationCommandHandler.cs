using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public class DeleteCourierStationCommandHandler : IRequestHandler<DeleteCourierStationCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;

        public DeleteCourierStationCommandHandler(IErrorHandler errorHandler, IDataContext dataContext)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(DeleteCourierStationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var courierStation = await _dataContext.Get<CourierStation>().FindAsync(command.Id);
                if (courierStation != null)
                {
                    _dataContext.Get<CourierStation>().Remove(courierStation);

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(courierStation.Id, "Courier Station is Deleted.");
                }
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }

            return await Result<int>.FailureAsync($"Courier station information not found with the Id - {command.Id}");
        }
    }
}
