using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Common;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Complaint.Commands
{
    // ── Submit ──────────────────────────────────────────────────────────────

    public record SubmitComplaintCommand : IRequest<Result<int>>
    {
        public int OrderId { get; set; }
        public ComplaintCategory Category { get; set; }
        public string Description { get; set; }
    }

    public class SubmitComplaintCommandValidator : AbstractValidator<SubmitComplaintCommand>
    {
        public SubmitComplaintCommandValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("A valid order must be specified.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(1000);

            RuleFor(x => x.Category)
                .IsInEnum().WithMessage("A valid complaint category must be selected.");
        }
    }

    public class SubmitComplaintCommandHandler : IRequestHandler<SubmitComplaintCommand, Result<int>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IRealtimeService _realtime;

        public SubmitComplaintCommandHandler(
            IDataContext dataContext,
            ICurrentUserService currentUserService,
            IRealtimeService realtime)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
            _realtime = realtime;
        }

        public async Task<Result<int>> Handle(SubmitComplaintCommand command, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            var order = await _dataContext.Get<Order>()
                .FirstOrDefaultAsync(o => o.Id == command.OrderId && o.UserId == userId, cancellationToken);

            if (order == null)
                return await Result<int>.FailureAsync("Order not found.");

            var complaint = new Domain.Entities.Complaint
            {
                OrderId     = command.OrderId,
                UserId      = userId,
                Category    = command.Category,
                Description = command.Description,
                Status      = ComplaintStatus.Submitted,
                CreatedBy   = userId,
                CreatedAt   = Clock.Now(),
            };

            _dataContext.Get<Domain.Entities.Complaint>().Add(complaint);
            await _dataContext.SaveChangesAsync(cancellationToken);

            await _realtime.SendToAdminsAsync(RealtimeEvents.ComplaintSubmitted,
                new { ComplaintId = complaint.Id, complaint.OrderId, UserId = userId, Category = command.Category.ToString() },
                cancellationToken);

            return await Result<int>.SuccessAsync(complaint.Id, "Complaint submitted.");
        }
    }

    // ── Update Status (admin) ────────────────────────────────────────────────

    public record UpdateComplaintStatusCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public ComplaintStatus Status { get; set; }
        public string AdminNote { get; set; }
    }

    public class UpdateComplaintStatusCommandHandler : IRequestHandler<UpdateComplaintStatusCommand, Result<int>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly INotificationService _notificationService;
        private readonly IRealtimeService _realtime;

        public UpdateComplaintStatusCommandHandler(
            IDataContext dataContext,
            ICurrentUserService currentUserService,
            INotificationService notificationService,
            IRealtimeService realtime)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
            _notificationService = notificationService;
            _realtime = realtime;
        }

        public async Task<Result<int>> Handle(UpdateComplaintStatusCommand command, CancellationToken cancellationToken)
        {
            var complaint = await _dataContext.Get<Domain.Entities.Complaint>()
                .FirstOrDefaultAsync(c => c.Id == command.Id, cancellationToken);

            if (complaint == null)
                return await Result<int>.FailureAsync($"Complaint not found with Id {command.Id}.");

            complaint.Status    = command.Status;
            complaint.AdminNote = command.AdminNote;

            if (command.Status is ComplaintStatus.Resolved or ComplaintStatus.Rejected or ComplaintStatus.Closed)
            {
                complaint.ResolvedBy = _currentUserService.UserId;
                complaint.ResolvedAt = Clock.Now();
            }

            _dataContext.Get<Domain.Entities.Complaint>().Update(complaint);
            await _dataContext.SaveChangesAsync(cancellationToken);

            await _notificationService.SendComplaintStatusChangedAsync(
                complaint.UserId, complaint.Id, command.Status.ToString(), cancellationToken);

            var statusPayload = new { ComplaintId = complaint.Id, Status = command.Status.ToString(), complaint.UserId };
            await _realtime.SendToUserAsync(complaint.UserId, RealtimeEvents.ComplaintStatusUpdated, statusPayload, cancellationToken);
            await _realtime.SendToAdminsAsync(RealtimeEvents.ComplaintStatusUpdated, statusPayload, cancellationToken);

            return await Result<int>.SuccessAsync(complaint.Id, "Complaint status updated.");
        }
    }
}
