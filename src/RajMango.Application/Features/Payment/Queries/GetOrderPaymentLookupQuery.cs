using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Queries
{
    public record GetOrderPaymentLookupQuery : IRequest<Result<List<OrderPaymentLookupDto>>>
    {
        /// <summary>
        /// Partial or full Order Number to search. Minimum 3 characters; returns up to 10 results.
        /// </summary>
        public string Search { get; init; } = string.Empty;
    }

    public class OrderPaymentLookupDto
    {
        /// <summary>Internal Order PK — sent in CreatePaymentCommand, never displayed in UI.</summary>
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string ReceiverName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }

    internal class GetOrderPaymentLookupQueryHandler
        : IRequestHandler<GetOrderPaymentLookupQuery, Result<List<OrderPaymentLookupDto>>>
    {
        private const int MaxResults = 10;
        private const int MinTermLength = 3;

        private readonly IDataContext _dataContext;
        private readonly ICurrentUserService _currentUserService;

        public GetOrderPaymentLookupQueryHandler(
            IDataContext dataContext,
            ICurrentUserService currentUserService)
        {
            _dataContext = dataContext;
            _currentUserService = currentUserService;
        }

        public async Task<Result<List<OrderPaymentLookupDto>>> Handle(
            GetOrderPaymentLookupQuery request, CancellationToken cancellationToken)
        {
            if (!_currentUserService.IsAdmin && !_currentUserService.IsSuperAdmin)
                return await Result<List<OrderPaymentLookupDto>>.FailureAsync("Unauthorized.");

            var term = (request.Search ?? string.Empty).Trim();

            if (term.Length < MinTermLength)
                return await Result<List<OrderPaymentLookupDto>>.SuccessAsync(
                    new List<OrderPaymentLookupDto>(),
                    "Enter at least 3 characters to search.");

            var results = await _dataContext.Get<Order>()
                .Include(o => o.AppUser)
                .Where(o => o.OrderNumber.Contains(term))
                .OrderByDescending(o => o.OrderDate)
                .Take(MaxResults)
                .Select(o => new OrderPaymentLookupDto
                {
                    OrderId       = o.Id,
                    OrderNumber   = o.OrderNumber,
                    CustomerName  = o.AppUser != null
                                        ? (o.AppUser.FirstName + " " + o.AppUser.LastName).Trim()
                                        : string.Empty,
                    ReceiverName  = o.ReceiverType == ReceiverType.Self
                                        ? (o.AppUser != null
                                               ? (o.AppUser.FirstName + " " + o.AppUser.LastName).Trim()
                                               : string.Empty)
                                        : (o.ReceiverName ?? string.Empty),
                    TotalAmount   = o.TotalAmount,
                    PaidAmount    = o.PaidAmount,
                    DueAmount     = o.DueAmount,
                    PaymentStatus = o.PaymentStatus,
                })
                .ToListAsync(cancellationToken);

            return await Result<List<OrderPaymentLookupDto>>.SuccessAsync(results);
        }
    }
}
