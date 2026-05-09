using AutoMapper;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetGetValidTokenQueryHandler(IPasswordHasher<AppUser> passwordHasher, IDataContext dataContext, IMapper mapper)
        {
            _passwordHasher = passwordHasher;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<bool>> Handle(GetValidTokenQuery query, CancellationToken cancellationToken)
        {
            var jwtAuth = await _dataContext.Get<JwtAuth>().FirstOrDefaultAsync(u => u.AuthToken == query.Token);

            if (jwtAuth == null)
            {
                return await Result<bool>.FailureAsync($"Invalid Token");
            }

            if (IsTokenExpired(query.Token))
            {
                _dataContext.Get<JwtAuth>().Remove(jwtAuth);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return await Result<bool>.FailureAsync($"Token Expired");
            }

            return await Result<bool>.SuccessAsync("Valid Token");
        }

        private bool IsTokenExpired(string token)
        {
            byte[] data = Convert.FromBase64String(token);
            DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
            if (when < DateTime.Now.AddHours(-24))
            {
                return true;
            }
            return false;
        }

        private void DecodeToken(string token)
        {
            byte[] data = Convert.FromBase64String(token);
            DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
            if (when < DateTime.Now.AddHours(-24))
            {
                // too old session expired
            }
        }
    }
}
