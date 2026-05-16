using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features
{
    public record GetCourierProviderDropdownQuery : IRequest<Result<List<CourierProviderDropdownDto>>>;

    public class GetCourierProviderDropdownQueryHandler : IRequestHandler<GetCourierProviderDropdownQuery, Result<List<CourierProviderDropdownDto>>>
    {
        private readonly IDataContext _dataContext;

        public GetCourierProviderDropdownQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<CourierProviderDropdownDto>>> Handle(GetCourierProviderDropdownQuery query, CancellationToken cancellationToken)
        {
            var dropdownDtos = await _dataContext.Get<CourierProvider>()
               .OrderBy(x => x.Name)
               .Select(x => new CourierProviderDropdownDto
               {
                   Id = x.Id,
                   Name = x.Name
               })
               .ToListAsync(cancellationToken);

            return await Result<List<CourierProviderDropdownDto>>.SuccessAsync(dropdownDtos);
        }
    }
}
