using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features
{
    public record GetCourierStationByIdQuery : IRequest<Result<CourierStationDto>>
    {
        public int Id { get; set; }

        public GetCourierStationByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetCourierStationByIdQueryHandler : IRequestHandler<GetCourierStationByIdQuery, Result<CourierStationDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetCourierStationByIdQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<CourierStationDto>> Handle(GetCourierStationByIdQuery query, CancellationToken cancellationToken)
        {
            var courierStation = await _dataContext.Get<CourierStation>()
                                                    .Include(p => p.CourierProvider)
                                                    .FirstOrDefaultAsync(p => p.Id == query.Id);

            if (courierStation != null)
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

                return await Result<CourierStationDto>.SuccessAsync(courierStationDto);
            }

            return await Result<CourierStationDto>.SuccessAsync(new CourierStationDto());
        }
    }
}
