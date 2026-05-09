using AutoMapper;
using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    internal class CreateCourierStationCommandHandler : IRequestHandler<CreateCourierStationCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public CreateCourierStationCommandHandler(IErrorHandler errorHandler,
                                         IDataContext dataContext,
                                         IMapper mapper)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateCourierStationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var courierStation = new CourierStation
                {
                    CourierProviderId = command.CourierProviderId,
                    Name = command.Name,
                    AddressLine = command.AddressLine,
                    City = command.City,
                    Area = command.Area,
                    SupportPhone1 = command.SupportPhone1,
                    SupportPhone2 = command.SupportPhone2,
                    Email = command.Email,
                    Latitude = command.Latitude,
                    Longitude = command.Longitude,
                    GoogleMapUrl = command.GoogleMapUrl,
                    IsActive = command.IsActive
                };

                _dataContext.Get<CourierStation>().Add(courierStation);

                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<int>.SuccessAsync(courierStation.Id, "Courier Station is Created.");
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
            return await Result<int>.FailureAsync($"Courier Station Creation Failed.");
        }
    }
}
