using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Shared;

namespace RajMango.Application.Features.Feedback.Queries
{
    public class FeedbackDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int UserId { get; set; }
        public string CustomerName { get; set; }
        public int Rating { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    // --- GET /api/feedback/my-order/{orderId} ---
    public record GetFeedbackByOrderIdQuery(int OrderId) : IRequest<Result<FeedbackDto>>;

    public class GetFeedbackByOrderIdQueryHandler : IRequestHandler<GetFeedbackByOrderIdQuery, Result<FeedbackDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetFeedbackByOrderIdQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<FeedbackDto>> Handle(GetFeedbackByOrderIdQuery query, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            var feedback = await _dataContext.Get<Domain.Entities.Feedback>()
                .Where(f => f.OrderId == query.OrderId &&
                            (_currentUserService.IsAdmin || f.UserId == userId))
                .Select(f => new FeedbackDto
                {
                    Id           = f.Id,
                    OrderId      = f.OrderId,
                    OrderNumber  = f.Order.OrderNumber,
                    UserId       = f.UserId,
                    CustomerName = f.AppUser.FirstName + " " + f.AppUser.LastName,
                    Rating       = f.Rating,
                    Note         = f.Note,
                    CreatedAt    = f.CreatedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (feedback == null)
                return await Result<FeedbackDto>.FailureAsync("No feedback found for this order.");

            return await Result<FeedbackDto>.SuccessAsync(feedback);
        }
    }

    // --- GET /api/feedback (admin) ---
    public record GetAllFeedbackQuery : IRequest<Result<List<FeedbackDto>>>;

    public class GetAllFeedbackQueryHandler : IRequestHandler<GetAllFeedbackQuery, Result<List<FeedbackDto>>>
    {
        private readonly IDataContext _dataContext;

        public GetAllFeedbackQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<FeedbackDto>>> Handle(GetAllFeedbackQuery query, CancellationToken cancellationToken)
        {
            var feedbacks = await _dataContext.Get<Domain.Entities.Feedback>()
                .OrderByDescending(f => f.CreatedAt)
                .Select(f => new FeedbackDto
                {
                    Id           = f.Id,
                    OrderId      = f.OrderId,
                    OrderNumber  = f.Order.OrderNumber,
                    UserId       = f.UserId,
                    CustomerName = f.AppUser.FirstName + " " + f.AppUser.LastName,
                    Rating       = f.Rating,
                    Note         = f.Note,
                    CreatedAt    = f.CreatedAt,
                })
                .ToListAsync(cancellationToken);

            return await Result<List<FeedbackDto>>.SuccessAsync(feedbacks);
        }
    }
}
