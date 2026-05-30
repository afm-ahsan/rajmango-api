using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Courier.RateConfig.Queries
{
    public record GetCourierRateConfigCountQuery : IRequest<Result<int>>;

    internal class GetCourierRateConfigCountQueryHandler : IRequestHandler<GetCourierRateConfigCountQuery, Result<int>>
    {
        private readonly IDataContext _dataContext;

        public GetCourierRateConfigCountQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(GetCourierRateConfigCountQuery query, CancellationToken cancellationToken)
        {
            var count = await _dataContext.Get<CourierRateConfiguration>().CountAsync(cancellationToken);
            return await Result<int>.SuccessAsync(count);
        }
    }
}
