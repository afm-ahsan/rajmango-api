using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features
{
    public record GetCourierStationCountQuery : IRequest<Result<int>>
    {
        public GetCourierStationCountQuery() { }
    }

    public class GetCourierStationCountQueryHandler : IRequestHandler<GetCourierStationCountQuery, Result<int>>
    {
        private readonly IDataContext _dataContext;

        public GetCourierStationCountQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(GetCourierStationCountQuery query, CancellationToken cancellationToken)
        {
            var totalCourierStations = await _dataContext.Get<CourierStation>().CountAsync();
            return await Result<int>.SuccessAsync(totalCourierStations);
        }
    }
}
