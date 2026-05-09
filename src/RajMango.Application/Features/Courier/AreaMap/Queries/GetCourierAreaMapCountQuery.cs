using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features
{
    public record GetCourierAreaMapCountQuery : IRequest<Result<int>>
    {
        public GetCourierAreaMapCountQuery() { }
    }

    public class GetCourierAreaMapCountQueryHandler : IRequestHandler<GetCourierAreaMapCountQuery, Result<int>>
    {
        private readonly IDataContext _dataContext;

        public GetCourierAreaMapCountQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(GetCourierAreaMapCountQuery query, CancellationToken cancellationToken)
        {
            var totalCourierAreaMaps = await _dataContext.Get<CourierAreaMap>().CountAsync();
            return await Result<int>.SuccessAsync(totalCourierAreaMaps);
        }
    }
}
