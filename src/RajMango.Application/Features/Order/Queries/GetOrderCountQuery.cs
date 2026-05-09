using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetOrderCountQuery : IRequest<Result<int>>;

    public class GetOrderCountQueryHandler : IRequestHandler<GetOrderCountQuery, Result<int>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetOrderCountQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<int>> Handle(GetOrderCountQuery query, CancellationToken cancellationToken)
        {
            var orderQuery = _dataContext.Get<Order>().AsQueryable();

            if (!_currentUserService.IsAdmin)
                orderQuery = orderQuery.Where(o => o.UserId == _currentUserService.UserId);

            var count = await orderQuery.CountAsync(cancellationToken);
            return await Result<int>.SuccessAsync(count);
        }
    }
}
