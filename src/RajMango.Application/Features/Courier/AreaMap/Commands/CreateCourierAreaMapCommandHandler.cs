using AutoMapper;
using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    internal class CreateCourierAreaMapCommandHandler : IRequestHandler<CreateCourierAreaMapCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public CreateCourierAreaMapCommandHandler(IErrorHandler errorHandler,
                                         IDataContext dataContext,
                                         IMapper mapper)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateCourierAreaMapCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var courierAreaMap = new CourierAreaMap
                {
                    Area = command.Area,
                    CourierStationId = command.CourierStationId
                };

                _dataContext.Get<CourierAreaMap>().Add(courierAreaMap);

                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(courierAreaMap.Id, "Courier Area Map is Created.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Courier Area Map Creation Failed.");
        }
    }
}
