using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Faq
{
    // ── DTOs ──────────────────────────────────────────────────────────────

    public record FaqItemDto(
        int Id,
        string Question,
        string Answer,
        string Category,
        int SortOrder,
        bool IsActive);

    // ── Upsert (admin) ────────────────────────────────────────────────────

    public record UpsertFaqItemCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Category { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class UpsertFaqItemCommandValidator : AbstractValidator<UpsertFaqItemCommand>
    {
        public UpsertFaqItemCommandValidator()
        {
            RuleFor(x => x.Question)
                .NotEmpty().WithMessage("Question is required.")
                .MaximumLength(500);

            RuleFor(x => x.Answer)
                .NotEmpty().WithMessage("Answer is required.");
        }
    }

    public class UpsertFaqItemCommandHandler : IRequestHandler<UpsertFaqItemCommand, Result<int>>
    {
        private readonly IDataContext _dataContext;

        public UpsertFaqItemCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(UpsertFaqItemCommand command, CancellationToken cancellationToken)
        {
            if (command.Id > 0)
            {
                var existing = await _dataContext.Get<FaqItem>()
                    .FirstOrDefaultAsync(f => f.Id == command.Id, cancellationToken);

                if (existing == null)
                    return await Result<int>.FailureAsync($"FAQ item not found with Id {command.Id}.");

                existing.Question  = command.Question;
                existing.Answer    = command.Answer;
                existing.Category  = command.Category;
                existing.SortOrder = command.SortOrder;
                existing.IsActive  = command.IsActive;

                _dataContext.Get<FaqItem>().Update(existing);
                await _dataContext.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(existing.Id, "FAQ item updated.");
            }
            else
            {
                var item = new FaqItem
                {
                    Question  = command.Question,
                    Answer    = command.Answer,
                    Category  = command.Category,
                    SortOrder = command.SortOrder,
                    IsActive  = command.IsActive,
                    CreatedAt = Clock.Now(),
                };

                _dataContext.Get<FaqItem>().Add(item);
                await _dataContext.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(item.Id, "FAQ item created.");
            }
        }
    }

    // ── Delete (admin) ─────────────────────────────────────────────────────

    public record DeleteFaqItemCommand(int Id) : IRequest<Result<int>>;

    public class DeleteFaqItemCommandHandler : IRequestHandler<DeleteFaqItemCommand, Result<int>>
    {
        private readonly IDataContext _dataContext;

        public DeleteFaqItemCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<int>> Handle(DeleteFaqItemCommand command, CancellationToken cancellationToken)
        {
            var item = await _dataContext.Get<FaqItem>()
                .FirstOrDefaultAsync(f => f.Id == command.Id, cancellationToken);

            if (item == null)
                return await Result<int>.FailureAsync($"FAQ item not found with Id {command.Id}.");

            _dataContext.Get<FaqItem>().Remove(item);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(command.Id, "FAQ item deleted.");
        }
    }

    // ── Get All (admin, ordered by SortOrder) ─────────────────────────────

    public record GetAllFaqItemsQuery : IRequest<Result<List<FaqItemDto>>>;

    public class GetAllFaqItemsQueryHandler : IRequestHandler<GetAllFaqItemsQuery, Result<List<FaqItemDto>>>
    {
        private readonly IDataContext _dataContext;

        public GetAllFaqItemsQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<FaqItemDto>>> Handle(GetAllFaqItemsQuery query, CancellationToken cancellationToken)
        {
            var items = await _dataContext.Get<FaqItem>()
                .OrderBy(f => f.SortOrder)
                .ThenBy(f => f.Id)
                .Select(f => new FaqItemDto(f.Id, f.Question, f.Answer, f.Category, f.SortOrder, f.IsActive))
                .ToListAsync(cancellationToken);

            return await Result<List<FaqItemDto>>.SuccessAsync(items);
        }
    }

    // ── Public search (keyword match on question + answer) ────────────────

    public record SearchFaqQuery(string Keyword) : IRequest<Result<List<FaqItemDto>>>;

    public class SearchFaqQueryHandler : IRequestHandler<SearchFaqQuery, Result<List<FaqItemDto>>>
    {
        private readonly IDataContext _dataContext;

        public SearchFaqQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<FaqItemDto>>> Handle(SearchFaqQuery query, CancellationToken cancellationToken)
        {
            var keyword = (query.Keyword ?? string.Empty).Trim();

            var q = _dataContext.Get<FaqItem>().Where(f => f.IsActive);

            if (!string.IsNullOrEmpty(keyword))
                q = q.Where(f => f.Question.Contains(keyword) || f.Answer.Contains(keyword));

            var items = await q
                .OrderBy(f => f.SortOrder)
                .ThenBy(f => f.Id)
                .Select(f => new FaqItemDto(f.Id, f.Question, f.Answer, f.Category, f.SortOrder, f.IsActive))
                .ToListAsync(cancellationToken);

            return await Result<List<FaqItemDto>>.SuccessAsync(items);
        }
    }
}
