using AutoMapper;
using AutoMapper.QueryableExtensions;
using RajMango.Application.Extensions;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using MediatR;

namespace RajMango.Application.Features.Queries
{
    public record GetCustomerWithPaginationQuery : IRequest<PaginatedResult<GetCustomerWithPaginationDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Filter { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        public GetCustomerWithPaginationQuery() { }
    }

    public class GetCustomerInfoWithPaginationQueryHandler : IRequestHandler<GetCustomerWithPaginationQuery, PaginatedResult<GetCustomerWithPaginationDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetCustomerInfoWithPaginationQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<GetCustomerWithPaginationDto>> Handle(GetCustomerWithPaginationQuery query, CancellationToken cancellationToken)
        {
            var q = _dataContext.Get<Customer>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Filter))
            {
                var f = query.Filter.Trim().ToLower();
                q = q.Where(c =>
                    c.FirstName.ToLower().Contains(f) ||
                    c.LastName.ToLower().Contains(f) ||
                    c.PhoneNumber1.ToLower().Contains(f) ||
                    (c.Email != null && c.Email.ToLower().Contains(f)));
            }

            bool asc = string.IsNullOrEmpty(query.SortOrder) || query.SortOrder.ToLower() != "desc";
            q = (query.SortBy?.ToLower()) switch
            {
                "lastname"    => asc ? q.OrderBy(c => c.LastName)    : q.OrderByDescending(c => c.LastName),
                "phonenumber" => asc ? q.OrderBy(c => c.PhoneNumber1) : q.OrderByDescending(c => c.PhoneNumber1),
                "email"       => asc ? q.OrderBy(c => c.Email)       : q.OrderByDescending(c => c.Email),
                _             => asc ? q.OrderBy(c => c.FirstName)   : q.OrderByDescending(c => c.FirstName),
            };

            return await q
                .ProjectTo<GetCustomerWithPaginationDto>(_mapper.ConfigurationProvider)
                .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
        }
    }
}
