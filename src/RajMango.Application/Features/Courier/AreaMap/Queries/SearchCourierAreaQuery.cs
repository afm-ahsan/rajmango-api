using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.DTOs;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features
{
    public record SearchCourierAreaQuery : IRequest<Result<List<CourierAreaDropdownDto>>>
    {
        public string Q { get; set; }
        public int Limit { get; set; } = 20;
    }

    public class SearchCourierAreaQueryHandler : IRequestHandler<SearchCourierAreaQuery, Result<List<CourierAreaDropdownDto>>>
    {
        private readonly IDataContext _dataContext;

        public SearchCourierAreaQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<CourierAreaDropdownDto>>> Handle(SearchCourierAreaQuery query, CancellationToken cancellationToken)
        {
            var term = (query.Q ?? "").Trim();

            if (term.Length < 2)
                return await Result<List<CourierAreaDropdownDto>>.SuccessAsync(new List<CourierAreaDropdownDto>());

            var areas = await _dataContext.Get<CourierAreaMap>()
                .Where(x => x.Area.Contains(term))
                .OrderBy(x => x.Area)
                .Select(x => x.Area)
                .Distinct()
                .Take(query.Limit)
                .ToListAsync(cancellationToken);

            var id = 0;
            var result = areas
                .Select(area => new CourierAreaDropdownDto { Id = id++, Name = area })
                .ToList();

            return await Result<List<CourierAreaDropdownDto>>.SuccessAsync(result);
        }
    }
}
