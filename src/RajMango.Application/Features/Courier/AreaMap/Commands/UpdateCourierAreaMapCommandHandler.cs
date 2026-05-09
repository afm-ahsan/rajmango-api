using AutoMapper;
using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public class UpdateCourierAreaMapCommandHandler : IRequestHandler<UpdateCourierAreaMapCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public UpdateCourierAreaMapCommandHandler(IErrorHandler errorHandler, IDataContext dataContext, IMapper mapper)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateCourierAreaMapCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var courierAreaMap = await _dataContext.Get<CourierAreaMap>().FindAsync(command.Id);
                if (courierAreaMap != null)
                {
                    courierAreaMap.Area = command.Area;
                    courierAreaMap.CourierStationId = command.CourierStationId;

                    _dataContext.Get<CourierAreaMap>().Update(courierAreaMap);

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(courierAreaMap.Id, "Courier Area Map is Updated.");
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
