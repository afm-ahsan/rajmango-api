using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features
{
    public record GetCourierAreaDropdownQuery : IRequest<Result<List<CourierAreaDropdownDto>>>;

    public class GetCourierAreaDropdownQueryHandler : IRequestHandler<GetCourierAreaDropdownQuery, Result<List<CourierAreaDropdownDto>>>
    {
        private readonly IDataContext _dataContext;

        public GetCourierAreaDropdownQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<CourierAreaDropdownDto>>> Handle(GetCourierAreaDropdownQuery query, CancellationToken cancellationToken)
        {
            var id = 0;
            var courierAreas = await _dataContext.Get<CourierAreaMap>()
               .OrderBy(x => x.Area)
               .Select(x => x.Area)
               .Distinct()
               .ToListAsync(cancellationToken);
            
            var dropdownDtos = new List<CourierAreaDropdownDto>();
            foreach (var area in courierAreas)
            {
                dropdownDtos.Add(new CourierAreaDropdownDto
                {
                    Id = id++,
                    Name = area
                });
            }

            dropdownDtos.Add(new CourierAreaDropdownDto
            {
                Id = id++,
                Name = "Others"
            });

            return await Result<List<CourierAreaDropdownDto>>.SuccessAsync(dropdownDtos);
        }
    }
}
