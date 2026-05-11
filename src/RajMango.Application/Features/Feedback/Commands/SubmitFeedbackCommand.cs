using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Feedback.Commands
{
    public record SubmitFeedbackCommand : IRequest<Result<int>>
    {
        public int OrderId { get; set; }
        public int Rating { get; set; }
        public string Note { get; set; }
        public IEnumerable<string>? ImagePaths { get; set; }
    }

    public class SubmitFeedbackCommandValidator : AbstractValidator<SubmitFeedbackCommand>
    {
        public SubmitFeedbackCommandValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("A valid order must be specified.");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

            RuleFor(x => x.ImagePaths)
                .Must(paths => paths == null || paths.Count() <= 3)
                .WithMessage("A maximum of 3 images is allowed per feedback.");

            RuleForEach(x => x.ImagePaths)
                .NotEmpty().WithMessage("Image path must not be empty.")
                .MaximumLength(512);
        }
    }

    public class SubmitFeedbackCommandHandler : IRequestHandler<SubmitFeedbackCommand, Result<int>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public SubmitFeedbackCommandHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<int>> Handle(SubmitFeedbackCommand command, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            var order = await _dataContext.Get<Order>()
                .FirstOrDefaultAsync(o => o.Id == command.OrderId && o.UserId == userId, cancellationToken);

            if (order == null)
                return await Result<int>.FailureAsync("Order not found.");

            if (order.OrderStatus != OrderStatus.Delivered)
                return await Result<int>.FailureAsync("Feedback can only be submitted for delivered orders.");

            var alreadyExists = await _dataContext.Get<Domain.Entities.Feedback>()
                .AnyAsync(f => f.OrderId == command.OrderId && f.UserId == userId, cancellationToken);

            if (alreadyExists)
                return await Result<int>.FailureAsync("You have already submitted feedback for this order.");

            var feedback = new Domain.Entities.Feedback
            {
                OrderId   = command.OrderId,
                UserId    = userId,
                Rating    = command.Rating,
                Note      = command.Note,
                CreatedBy = userId,
                CreatedAt = Clock.Now(),
            };

            if (command.ImagePaths?.Any() == true)
            {
                var sortOrder = 0;
                foreach (var path in command.ImagePaths.Take(3))
                    feedback.Images.Add(new FeedbackImage { ImagePath = path, SortOrder = sortOrder++, UploadedAt = Clock.Now() });
            }

            _dataContext.Get<Domain.Entities.Feedback>().Add(feedback);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return await Result<int>.SuccessAsync(feedback.Id, "Feedback submitted. Thank you!");
        }
    }
}
