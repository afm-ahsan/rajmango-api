using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features
{
    public record GetCourierProviderByIdQuery : IRequest<Result<CourierProviderDto>>
    {
        public int Id { get; set; }

        public GetCourierProviderByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetCourierProviderByIdQueryHandler : IRequestHandler<GetCourierProviderByIdQuery, Result<CourierProviderDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetCourierProviderByIdQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<CourierProviderDto>> Handle(GetCourierProviderByIdQuery query, CancellationToken cancellationToken)
        {
            var courierProvider = await _dataContext.Get<CourierProvider>()
                                                    .FirstOrDefaultAsync(p => p.Id == query.Id);

            if (courierProvider != null)
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

                return await Result<CourierProviderDto>.SuccessAsync(courierProviderDto);
            }

            return await Result<CourierProviderDto>.SuccessAsync(new CourierProviderDto());
        }
    }
}
