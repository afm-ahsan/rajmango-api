using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features
{
    public record GetAllCourierProviderQuery : IRequest<Result<List<CourierProviderDto>>>;

    public class GetAllCourierProviderQueryHandler : IRequestHandler<GetAllCourierProviderQuery, Result<List<CourierProviderDto>>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetAllCourierProviderQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<List<CourierProviderDto>>> Handle(GetAllCourierProviderQuery query, CancellationToken cancellationToken)
        {
            var courierProviders = await _dataContext.Get<CourierProvider>()
                                                     .ToListAsync(cancellationToken);

            var courierProviderDtos = new List<CourierProviderDto>();
            foreach (var courierProvider in courierProviders)
            {
                var courierProviderDto = new CourierProviderDto
                {
                    Id = courierProvider.Id,
                    Name = courierProvider.Name,
                    Description = courierProvider.Description,
                    SupportPhone = courierProvider.SupportPhone,
                    Email = courierProvider.Email,
                    IsActive = courierProvider.IsActive
                };

                courierProviderDtos.Add(courierProviderDto);
            }

            return await Result<List<CourierProviderDto>>.SuccessAsync(courierProviderDtos);
        }
    }
}
