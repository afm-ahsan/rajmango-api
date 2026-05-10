using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Common;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Policy
{
    public class PolicyDto
    {
        public int Id { get; set; }
        public PolicyType PolicyType { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    // ── Upsert (admin) ───────────────────────────────────────────────────────

    public record UpsertPolicyCommand : IRequest<Result<int>>
    {
        public PolicyType PolicyType { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class UpsertPolicyCommandValidator : AbstractValidator<UpsertPolicyCommand>
    {
        public UpsertPolicyCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.PolicyType).IsInEnum();
        }
    }

    public class UpsertPolicyCommandHandler : IRequestHandler<UpsertPolicyCommand, Result<int>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly ICacheService _cache;

        public UpsertPolicyCommandHandler(IDataContext dataContext, ICurrentUserService currentUserService, ICacheService cache)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
            _cache = cache;
        }

        public async Task<Result<int>> Handle(UpsertPolicyCommand command, CancellationToken cancellationToken)
        {
            var existing = await _dataContext.Get<Domain.Entities.Policy>()
                .FirstOrDefaultAsync(p => p.PolicyType == command.PolicyType, cancellationToken);

            if (existing != null)
            {
                existing.Title     = command.Title;
                existing.Content   = command.Content;
                existing.IsActive  = command.IsActive;
                existing.UpdatedBy = _currentUserService.UserId;
                existing.UpdatedAt = Clock.Now();

                _dataContext.Get<Domain.Entities.Policy>().Update(existing);
                await _dataContext.SaveChangesAsync(cancellationToken);
                await _cache.RemoveAsync(CacheKeys.PolicyAll, cancellationToken);
                return await Result<int>.SuccessAsync(existing.Id, "Policy updated.");
            }

            var policy = new Domain.Entities.Policy
            {
                PolicyType = command.PolicyType,
                Title      = command.Title,
                Content    = command.Content,
                IsActive   = command.IsActive,
                CreatedBy  = _currentUserService.UserId,
                CreatedAt  = Clock.Now(),
            };

            _dataContext.Get<Domain.Entities.Policy>().Add(policy);
            await _dataContext.SaveChangesAsync(cancellationToken);
            await _cache.RemoveAsync(CacheKeys.PolicyAll, cancellationToken);
            return await Result<int>.SuccessAsync(policy.Id, "Policy created.");
        }
    }

    // ── Get by type (public) ─────────────────────────────────────────────────

    public record GetPolicyByTypeQuery(PolicyType PolicyType) : IRequest<Result<PolicyDto>>;

    public class GetPolicyByTypeQueryHandler : IRequestHandler<GetPolicyByTypeQuery, Result<PolicyDto>>
    {
        private readonly IDataContext _dataContext;

        public GetPolicyByTypeQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<PolicyDto>> Handle(GetPolicyByTypeQuery query, CancellationToken cancellationToken)
        {
            var policy = await _dataContext.Get<Domain.Entities.Policy>()
                .Where(p => p.PolicyType == query.PolicyType && p.IsActive)
                .Select(p => new PolicyDto
                {
                    Id         = p.Id,
                    PolicyType = p.PolicyType,
                    Title      = p.Title,
                    Content    = p.Content,
                    IsActive   = p.IsActive,
                    UpdatedAt  = p.UpdatedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (policy == null)
                return await Result<PolicyDto>.FailureAsync("Policy not found.");

            return await Result<PolicyDto>.SuccessAsync(policy);
        }
    }

    // ── Get all (public) ─────────────────────────────────────────────────────

    public record GetAllPoliciesQuery : IRequest<Result<List<PolicyDto>>>, ICacheableQuery
    {
        public string CacheKey => CacheKeys.PolicyAll;
        public TimeSpan? Expiry => TimeSpan.FromMinutes(60);
    }

    public class GetAllPoliciesQueryHandler : IRequestHandler<GetAllPoliciesQuery, Result<List<PolicyDto>>>
    {
        private readonly IDataContext _dataContext;

        public GetAllPoliciesQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<PolicyDto>>> Handle(GetAllPoliciesQuery query, CancellationToken cancellationToken)
        {
            var policies = await _dataContext.Get<Domain.Entities.Policy>()
                .Where(p => p.IsActive)
                .OrderBy(p => p.PolicyType)
                .Select(p => new PolicyDto
                {
                    Id         = p.Id,
                    PolicyType = p.PolicyType,
                    Title      = p.Title,
                    Content    = p.Content,
                    IsActive   = p.IsActive,
                    UpdatedAt  = p.UpdatedAt,
                })
                .ToListAsync(cancellationToken);

            return await Result<List<PolicyDto>>.SuccessAsync(policies);
        }
    }
}
