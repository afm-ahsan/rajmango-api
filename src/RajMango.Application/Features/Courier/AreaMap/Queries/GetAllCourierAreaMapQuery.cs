using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features
{
    public record GetAllCourierAreaMapQuery : IRequest<Result<List<CourierAreaMapDto>>>;

    public class GetAllCourierAreaMapQueryHandler : IRequestHandler<GetAllCourierAreaMapQuery, Result<List<CourierAreaMapDto>>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetAllCourierAreaMapQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<List<CourierAreaMapDto>>> Handle(GetAllCourierAreaMapQuery query, CancellationToken cancellationToken)
        {
            var courierAreaMaps = await _dataContext.Get<CourierAreaMap>()
                                                    .Include(p => p.CourierStation)
                                                    .ToListAsync(cancellationToken);

            var courierAreaMapDtos = new List<CourierAreaMapDto>();
            foreach (var courierAreaMap in courierAreaMaps)
            {
                var courierAreaMapDto = new CourierAreaMapDto
                {
                    Id = courierAreaMap.Id,
                    Area = courierAreaMap.Area,
                    CourierStationId = courierAreaMap.CourierStationId,
                    CourierStationName = courierAreaMap.CourierStation.Name
                };

                courierAreaMapDtos.Add(courierAreaMapDto);
            }

            return await Result<List<CourierAreaMapDto>>.SuccessAsync(courierAreaMapDtos);
        }
    }
}
