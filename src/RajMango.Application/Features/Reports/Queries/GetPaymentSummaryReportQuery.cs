using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Queries
{
    public class PaymentSummaryReportDto
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public int TotalPayments { get; set; }
        public decimal TotalGross { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalNet { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalDue { get; set; }

        public List<PaymentByMethodDto> ByMethod { get; set; } = new();
        public List<PaymentSummaryLineDto> Payments { get; set; } = new();
    }

    public class PaymentByMethodDto
    {
        public PaymentMethod Method { get; set; }
        public int Count { get; set; }
        public decimal TotalPaid { get; set; }
    }

    public class PaymentSummaryLineDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string TransactionId { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public record GetPaymentSummaryReportQuery : IRequest<Result<PaymentSummaryReportDto>>
    {
        public DateTime From { get; init; }
        public DateTime To { get; init; }
    }

    public class GetPaymentSummaryReportQueryHandler : IRequestHandler<GetPaymentSummaryReportQuery, Result<PaymentSummaryReportDto>>
    {
        private readonly IDataContext _dataContext;

        public GetPaymentSummaryReportQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<PaymentSummaryReportDto>> Handle(GetPaymentSummaryReportQuery query, CancellationToken cancellationToken)
        {
            var from = query.From.Date;
            var to   = query.To.Date.AddDays(1).AddTicks(-1);

            var payments = await _dataContext.Get<Payment>()
                .Include(p => p.Order)
                .Where(p => p.CreatedAt >= from && p.CreatedAt <= to)
                .OrderByDescending(p => p.CreatedAt)
                .Select(p => new PaymentSummaryLineDto
                {
                    Id             = p.Id,
                    OrderId        = p.OrderId,
                    OrderNumber    = p.Order.OrderNumber,
                    TransactionId  = p.TransactionId,
                    GrossAmount    = p.GrossAmount,
                    DiscountAmount = p.DiscountAmount,
                    NetAmount      = p.NetAmount,
                    PaidAmount     = p.PaidAmount,
                    DueAmount      = p.DueAmount,
                    PaymentStatus  = p.PaymentStatus,
                    PaymentMethod  = p.PaymentMethod,
                    CreatedAt      = p.CreatedAt,
                })
                .ToListAsync(cancellationToken);

            var byMethod = payments
                .GroupBy(p => p.PaymentMethod)
                .Select(g => new PaymentByMethodDto
                {
                    Method    = g.Key,
                    Count     = g.Count(),
                    TotalPaid = g.Sum(p => p.PaidAmount),
                })
                .OrderByDescending(g => g.TotalPaid)
                .ToList();

            var dto = new PaymentSummaryReportDto
            {
                From           = query.From.Date,
                To             = query.To.Date,
                TotalPayments  = payments.Count,
                TotalGross     = payments.Sum(p => p.GrossAmount),
                TotalDiscount  = payments.Sum(p => p.DiscountAmount),
                TotalNet       = payments.Sum(p => p.NetAmount),
                TotalPaid      = payments.Sum(p => p.PaidAmount),
                TotalDue       = payments.Sum(p => p.DueAmount),
                ByMethod       = byMethod,
                Payments       = payments,
            };

            return await Result<PaymentSummaryReportDto>.SuccessAsync(dto);
        }
    }
}
