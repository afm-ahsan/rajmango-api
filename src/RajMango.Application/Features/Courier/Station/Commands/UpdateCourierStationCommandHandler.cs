using AutoMapper;
using MediatR;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public class UpdateCourierStationCommandHandler : IRequestHandler<UpdateCourierStationCommand, Result<int>>
    {
        private readonly IErrorHandler _errorHandler;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public UpdateCourierStationCommandHandler(IErrorHandler errorHandler, IDataContext dataContext, IMapper mapper)
        {
            _errorHandler = errorHandler;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateCourierStationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var courierStation = await _dataContext.Get<CourierStation>().FindAsync(command.Id);
                if (courierStation != null)
                {
                    courierStation.CourierProviderId = command.CourierProviderId;
                    courierStation.Name = command.Name;
                    courierStation.AddressLine = command.AddressLine;
                    courierStation.City = command.City;
                    courierStation.Area = command.Area;
                    courierStation.SupportPhone1 = command.SupportPhone1;
                    courierStation.SupportPhone2 = command.SupportPhone2;
                    courierStation.Email = command.Email;
                    courierStation.Latitude = command.Latitude;
                    courierStation.Longitude = command.Longitude;
                    courierStation.GoogleMapUrl = command.GoogleMapUrl;
                    courierStation.IsActive = command.IsActive;

                    _dataContext.Get<CourierStation>().Update(courierStation);

                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return await Result<int>.SuccessAsync(courierStation.Id, "Courier Station is Updated.");
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
