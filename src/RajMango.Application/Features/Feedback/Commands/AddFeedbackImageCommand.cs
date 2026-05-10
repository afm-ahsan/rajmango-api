using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;

namespace RajMango.Application.Features.Feedback.Commands
{
    public record AddFeedbackImageCommand : IRequest<Result<int>>
    {
        public int FeedbackId { get; set; }
        public string ImagePath { get; set; }
        public int SortOrder { get; set; } = 0;
    }

    public class AddFeedbackImageCommandValidator : AbstractValidator<AddFeedbackImageCommand>
    {
        public AddFeedbackImageCommandValidator()
        {
            RuleFor(x => x.FeedbackId)
                .GreaterThan(0).WithMessage("A valid feedback ID is required.");

            RuleFor(x => x.ImagePath)
                .NotEmpty().WithMessage("Image path is required.")
                .MaximumLength(512);
        }
    }

    public class AddFeedbackImageCommandHandler : IRequestHandler<AddFeedbackImageCommand, Result<int>>
    {
        private const int MaxImagesPerFeedback = 3;

        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public AddFeedbackImageCommandHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<int>> Handle(AddFeedbackImageCommand command, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            var feedback = await _dataContext.Get<Domain.Entities.Feedback>()
                .FirstOrDefaultAsync(f => f.Id == command.FeedbackId && f.UserId == userId, cancellationToken);

            if (feedback == null)
                return await Result<int>.FailureAsync("Feedback not found.");

            var existingCount = await _dataContext.Get<FeedbackImage>()
                .CountAsync(fi => fi.FeedbackId == command.FeedbackId, cancellationToken);

            if (existingCount >= MaxImagesPerFeedback)
                return await Result<int>.FailureAsync($"A maximum of {MaxImagesPerFeedback} images is allowed per feedback.");

            var image = new FeedbackImage
            {
                FeedbackId = command.FeedbackId,
                ImagePath  = command.ImagePath,
                SortOrder  = command.SortOrder,
                UploadedAt = Clock.Now(),
            };

            _dataContext.Get<FeedbackImage>().Add(image);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return await Result<int>.SuccessAsync(image.Id, "Image attached to feedback.");
        }
    }
}
