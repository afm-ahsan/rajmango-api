using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Features.Queries
{
    public record GetValidTokenQuery : IRequest<Result<bool>>
    {
        public string Token { get; set; }

        public GetValidTokenQuery(string token)
        {
            Token = token;
        }
    }

    public class GetGetValidTokenQueryHandler : IRequestHandler<GetValidTokenQuery, Result<bool>>
    {
        private readonly IDataContext _dataContext;

        public GetGetValidTokenQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<bool>> Handle(GetValidTokenQuery query, CancellationToken cancellationToken)
        {
            var jwtAuth = await _dataContext.Get<JwtAuth>()
                .FirstOrDefaultAsync(u => u.AuthToken == query.Token, cancellationToken);

            if (jwtAuth == null)
                return await Result<bool>.FailureAsync("Invalid Token");

            if (jwtAuth.ExpiresIn < Clock.Now())
            {
                _dataContext.Get<JwtAuth>().Remove(jwtAuth);
                await _dataContext.SaveChangesAsync(cancellationToken);
                return await Result<bool>.FailureAsync("Token Expired");
            }

            return await Result<bool>.SuccessAsync("Valid Token");
        }
    }
}
