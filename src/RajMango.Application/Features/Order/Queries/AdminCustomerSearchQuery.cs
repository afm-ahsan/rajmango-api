using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Queries
{
    public record AdminCustomerSearchQuery : IRequest<Result<List<AdminCustomerSearchResultDto>>>
    {
        /// <summary>
        /// Free-text term matched against full name, phone number, and email.
        /// Minimum 2 characters; returns up to 20 results ordered by name.
        /// </summary>
        public string Q { get; init; } = string.Empty;
    }

    public class AdminCustomerSearchResultDto
    {
        /// <summary>AppUser.Id — this is the value to set as Order.UserId when placing an order for this customer.</summary>
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    internal class AdminCustomerSearchQueryHandler
        : IRequestHandler<AdminCustomerSearchQuery, Result<List<AdminCustomerSearchResultDto>>>
    {
        private const string CustomerRoleCode = "self_register";
        private const int MaxResults = 20;
        private const int MinTermLength = 2;

        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public AdminCustomerSearchQueryHandler(
            IDataContext dataContext,
            ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<List<AdminCustomerSearchResultDto>>> Handle(
            AdminCustomerSearchQuery request, CancellationToken cancellationToken)
        {
            if (!_currentUserService.IsAdmin && !_currentUserService.IsSuperAdmin)
                return await Result<List<AdminCustomerSearchResultDto>>.FailureAsync("Unauthorized.");

            var term = (request.Q ?? string.Empty).Trim();

            if (term.Length < MinTermLength)
                return await Result<List<AdminCustomerSearchResultDto>>.SuccessAsync(
                    new List<AdminCustomerSearchResultDto>(),
                    "Enter at least 2 characters to search.");

            // Subquery: AppUser IDs that hold the customer (self_register) role.
            // Filtered via role Code, not hardcoded RoleId, so it works even if seeds change.
            var customerUserIds = _dataContext.Get<UserRole>()
                .Where(ur => ur.Role.Code == CustomerRoleCode)
                .Select(ur => ur.UserId);

            var results = await _dataContext.Get<AppUser>()
                .Where(u => u.IsActive && customerUserIds.Contains(u.Id))
                .Where(u =>
                    (u.FirstName + " " + u.LastName).Contains(term) ||
                    u.PhoneNumber.Contains(term) ||
                    u.Email.Contains(term))
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .Take(MaxResults)
                .Select(u => new AdminCustomerSearchResultDto
                {
                    UserId      = u.Id,
                    FullName    = u.FirstName + " " + u.LastName,
                    PhoneNumber = u.PhoneNumber,
                    Email       = u.Email,
                })
                .ToListAsync(cancellationToken);

            return await Result<List<AdminCustomerSearchResultDto>>.SuccessAsync(results);
        }
    }
}
