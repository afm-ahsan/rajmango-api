using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features
{
    public record GetCourierStationDropdownQuery : IRequest<Result<List<CourierStationDropdownDto>>>;

    public class GetCourierStationDropdownQueryHandler : IRequestHandler<GetCourierStationDropdownQuery, Result<List<CourierStationDropdownDto>>>
    {
        private readonly IDataContext _dataContext;

        public GetCourierStationDropdownQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<CourierStationDropdownDto>>> Handle(GetCourierStationDropdownQuery query, CancellationToken cancellationToken)
        {
            var dropdownDtos = await _dataContext.Get<CourierStation>()
               .Where(x => !x.IsDeleted)
               .OrderBy(x => x.Name)
               .Select(x => new CourierStationDropdownDto
               {
                   Id = x.Id,
                   Name = x.Name
               })
               .ToListAsync(cancellationToken);

            return await Result<List<CourierStationDropdownDto>>.SuccessAsync(dropdownDtos);
        }
    }
}
