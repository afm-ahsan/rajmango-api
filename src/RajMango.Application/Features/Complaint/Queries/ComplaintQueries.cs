using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Complaint.Queries
{
    public class ComplaintDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int UserId { get; set; }
        public string CustomerName { get; set; }
        public ComplaintCategory Category { get; set; }
        public string Description { get; set; }
        public ComplaintStatus Status { get; set; }
        public string AdminNote { get; set; }
        public List<string> ImagePaths { get; set; } = new();
        public int? ResolvedBy { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    // --- GET /api/complaint/{id} ---
    public record GetComplaintByIdQuery(int Id) : IRequest<Result<ComplaintDto>>;

    public class GetComplaintByIdQueryHandler : IRequestHandler<GetComplaintByIdQuery, Result<ComplaintDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetComplaintByIdQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<ComplaintDto>> Handle(GetComplaintByIdQuery query, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            var complaint = await _dataContext.Get<Domain.Entities.Complaint>()
                .Where(c => c.Id == query.Id &&
                            (_currentUserService.IsAdmin || c.UserId == userId))
                .Select(c => new ComplaintDto
                {
                    Id           = c.Id,
                    OrderId      = c.OrderId,
                    OrderNumber  = c.Order.OrderNumber,
                    UserId       = c.UserId,
                    CustomerName = c.AppUser.FirstName + " " + c.AppUser.LastName,
                    Category     = c.Category,
                    Description  = c.Description,
                    Status       = c.Status,
                    AdminNote    = c.AdminNote,
                    ImagePaths   = c.Images.OrderBy(i => i.SortOrder).Select(i => i.ImagePath).ToList(),
                    ResolvedBy   = c.ResolvedBy,
                    ResolvedAt   = c.ResolvedAt,
                    CreatedAt    = c.CreatedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (complaint == null)
                return await Result<ComplaintDto>.FailureAsync("Complaint not found.");

            return await Result<ComplaintDto>.SuccessAsync(complaint);
        }
    }

    // --- GET /api/complaint/mine (customer's own complaints) ---
    public record GetMyComplaintsQuery : IRequest<Result<List<ComplaintDto>>>;

    public class GetMyComplaintsQueryHandler : IRequestHandler<GetMyComplaintsQuery, Result<List<ComplaintDto>>>
    {
        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetMyComplaintsQueryHandler(IDataContext dataContext, ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<List<ComplaintDto>>> Handle(GetMyComplaintsQuery query, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            var complaints = await _dataContext.Get<Domain.Entities.Complaint>()
                .Where(c => c.UserId == userId)
                .OrderByDescending(c => c.CreatedAt)
                .Select(c => new ComplaintDto
                {
                    Id          = c.Id,
                    OrderId     = c.OrderId,
                    OrderNumber = c.Order.OrderNumber,
                    UserId      = c.UserId,
                    Category    = c.Category,
                    Description = c.Description,
                    Status      = c.Status,
                    AdminNote   = c.AdminNote,
                    ImagePaths  = c.Images.OrderBy(i => i.SortOrder).Select(i => i.ImagePath).ToList(),
                    ResolvedAt  = c.ResolvedAt,
                    CreatedAt   = c.CreatedAt,
                })
                .ToListAsync(cancellationToken);

            return await Result<List<ComplaintDto>>.SuccessAsync(complaints);
        }
    }

    // --- GET /api/complaint (admin) ---
    public record GetAllComplaintsQuery : IRequest<Result<List<ComplaintDto>>>;

    public class GetAllComplaintsQueryHandler : IRequestHandler<GetAllComplaintsQuery, Result<List<ComplaintDto>>>
    {
        private readonly IDataContext _dataContext;

        public GetAllComplaintsQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<List<ComplaintDto>>> Handle(GetAllComplaintsQuery query, CancellationToken cancellationToken)
        {
            var complaints = await _dataContext.Get<Domain.Entities.Complaint>()
                .OrderByDescending(c => c.CreatedAt)
                .Select(c => new ComplaintDto
                {
                    Id           = c.Id,
                    OrderId      = c.OrderId,
                    OrderNumber  = c.Order.OrderNumber,
                    UserId       = c.UserId,
                    CustomerName = c.AppUser.FirstName + " " + c.AppUser.LastName,
                    Category     = c.Category,
                    Description  = c.Description,
                    Status       = c.Status,
                    AdminNote    = c.AdminNote,
                    ImagePaths   = c.Images.OrderBy(i => i.SortOrder).Select(i => i.ImagePath).ToList(),
                    ResolvedBy   = c.ResolvedBy,
                    ResolvedAt   = c.ResolvedAt,
                    CreatedAt    = c.CreatedAt,
                })
                .ToListAsync(cancellationToken);

            return await Result<List<ComplaintDto>>.SuccessAsync(complaints);
        }
    }
}
