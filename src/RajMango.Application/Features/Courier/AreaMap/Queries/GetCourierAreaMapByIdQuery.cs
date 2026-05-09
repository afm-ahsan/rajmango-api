using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features
{
    public record GetCourierAreaMapByIdQuery : IRequest<Result<CourierAreaMapDto>>
    {
        public int Id { get; set; }

        public GetCourierAreaMapByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetCourierAreaMapByIdQueryHandler : IRequestHandler<GetCourierAreaMapByIdQuery, Result<CourierAreaMapDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetCourierAreaMapByIdQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<CourierAreaMapDto>> Handle(GetCourierAreaMapByIdQuery query, CancellationToken cancellationToken)
        {
            var courierAreaMap = await _dataContext.Get<CourierAreaMap>()
                                                    .Include(p => p.CourierStation)
                                                    .FirstOrDefaultAsync(p => p.Id == query.Id);

            if (courierAreaMap != null)
            {
                var courierAreaMapDto = new CourierAreaMapDto
                {
                    Id = courierAreaMap.Id,
                    Area = courierAreaMap.Area,
                    CourierStationId = courierAreaMap.CourierStationId,
                    CourierStationName = courierAreaMap.CourierStation.Name
                };

                return await Result<CourierAreaMapDto>.SuccessAsync(courierAreaMapDto);
            }

            return await Result<CourierAreaMapDto>.SuccessAsync(new CourierAreaMapDto());
        }
    }
}
