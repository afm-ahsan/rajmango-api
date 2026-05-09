using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features
{
    public record GetAllCourierStationQuery : IRequest<Result<List<CourierStationDto>>>;

    public class GetAllCourierStationQueryHandler : IRequestHandler<GetAllCourierStationQuery, Result<List<CourierStationDto>>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetAllCourierStationQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<List<CourierStationDto>>> Handle(GetAllCourierStationQuery query, CancellationToken cancellationToken)
        {
            var courierStations = await _dataContext.Get<CourierStation>()
                                                    .Include(p => p.CourierProvider)
                                                    .ToListAsync(cancellationToken);

            var courierStationDtos = new List<CourierStationDto>();
            foreach (var courierStation in courierStations)
            {
                var courierStationDto = new CourierStationDto
                {
                    Id = courierStation.Id,
                    Name = courierStation.Name,
                    AddressLine = courierStation.AddressLine,
                    City = courierStation.City,
                    Area = courierStation.Area,
                    SupportPhone1 = courierStation.SupportPhone1,
                    SupportPhone2 = courierStation.SupportPhone2,
                    Email = courierStation.Email,
                    Latitude = courierStation.Latitude,
                    Longitude = courierStation.Longitude,
                    GoogleMapUrl = courierStation.GoogleMapUrl,
                    IsActive = courierStation.IsActive,
                    CourierProviderId = courierStation.CourierProviderId,
                    CourierProviderName = courierStation.CourierProvider.Name,
                };

                courierStationDtos.Add(courierStationDto);
            }

            return await Result<List<CourierStationDto>>.SuccessAsync(courierStationDtos);
        }
    }
}
