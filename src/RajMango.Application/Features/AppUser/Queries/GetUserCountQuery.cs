using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record GetUserCountQuery : IRequest<Result<int>>
    {
        public GetUserCountQuery() { }
    }

    public class GetUserCountQueryHandler : IRequestHandler<GetUserCountQuery, Result<int>>
    {
        private readonly IDataContext _dataContext;

        public GetUserCountQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(GetUserCountQuery query, CancellationToken cancellationToken)
        {
            var totalRecord = await _dataContext.Get<AppUser>().CountAsync();
            return await Result<int>.SuccessAsync(totalRecord);
        }
    }
}
