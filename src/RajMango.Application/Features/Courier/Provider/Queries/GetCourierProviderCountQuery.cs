using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features
{
    public record GetCourierProviderCountQuery : IRequest<Result<int>>
    {
        public GetCourierProviderCountQuery() { }
    }

    public class GetCourierProviderCountQueryHandler : IRequestHandler<GetCourierProviderCountQuery, Result<int>>
    {
        private readonly IDataContext _dataContext;

        public GetCourierProviderCountQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(GetCourierProviderCountQuery query, CancellationToken cancellationToken)
        {
            var totalCourierProviders = await _dataContext.Get<CourierProvider>().CountAsync();
            return await Result<int>.SuccessAsync(totalCourierProviders);
        }
    }
}
