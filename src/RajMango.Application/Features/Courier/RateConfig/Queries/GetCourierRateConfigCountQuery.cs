using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Courier.RateConfig.Queries
{
    public record GetCourierRateConfigCountQuery : IRequest<Result<int>>
    {
        public string? Filter { get; set; }
        public int? LocationType { get; set; }
    }

    internal class GetCourierRateConfigCountQueryHandler : IRequestHandler<GetCourierRateConfigCountQuery, Result<int>>
    {
        private readonly IDataContext _dataContext;

        public GetCourierRateConfigCountQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(GetCourierRateConfigCountQuery query, CancellationToken cancellationToken)
        {
            var q = _dataContext.Get<CourierRateConfiguration>()
                .Include(r => r.CourierProvider)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Filter))
                q = q.Where(r => r.CourierProvider.Name.Contains(query.Filter));

            if (query.LocationType.HasValue)
                q = q.Where(r => (int)r.CourierLocationType == query.LocationType.Value);

            var count = await q.CountAsync(cancellationToken);
            return await Result<int>.SuccessAsync(count);
        }
    }
}
