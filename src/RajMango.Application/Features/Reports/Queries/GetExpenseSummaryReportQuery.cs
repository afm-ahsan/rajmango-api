using MediatR;
using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Queries
{
    public class ExpenseSummaryReportDto
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public int TotalExpenses { get; set; }
        public decimal TotalAmount { get; set; }

        public List<ExpenseByTypeDto> ByType { get; set; } = new();
        public List<ExpenseSummaryLineDto> Expenses { get; set; } = new();
    }

    public class ExpenseByTypeDto
    {
        public int ExpenseTypeId { get; set; }
        public string ExpenseTypeName { get; set; }
        public int Count { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class ExpenseSummaryLineDto
    {
        public int Id { get; set; }
        public string ExpenseTypeName { get; set; }
        public string Name { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string PaymentReference { get; set; }
        public string PaidTo { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }

    public record GetExpenseSummaryReportQuery : IRequest<Result<ExpenseSummaryReportDto>>
    {
        public DateTime From { get; init; }
        public DateTime To { get; init; }
    }

    public class GetExpenseSummaryReportQueryHandler : IRequestHandler<GetExpenseSummaryReportQuery, Result<ExpenseSummaryReportDto>>
    {
        private readonly IDataContext _dataContext;

        public GetExpenseSummaryReportQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<ExpenseSummaryReportDto>> Handle(GetExpenseSummaryReportQuery query, CancellationToken cancellationToken)
        {
            var from = query.From.Date;
            var to   = query.To.Date.AddDays(1).AddTicks(-1);

            var expenses = await _dataContext.Get<Expense>()
                .Include(e => e.ExpenseType)
                .Where(e => e.ExpenseDate >= from && e.ExpenseDate <= to && e.IsActive)
                .OrderByDescending(e => e.ExpenseDate)
                .Select(e => new ExpenseSummaryLineDto
                {
                    Id              = e.Id,
                    ExpenseTypeName = e.ExpenseType.Name,
                    Name            = e.Name,
                    ExpenseDate     = e.ExpenseDate,
                    PaymentReference   = e.PaymentReference,
                    PaidTo          = e.PaidTo,
                    Amount          = e.Amount,
                    PaymentMethod   = e.PaymentMethod,
                })
                .ToListAsync(cancellationToken);

            var byType = await _dataContext.Get<Expense>()
                .Include(e => e.ExpenseType)
                .Where(e => e.ExpenseDate >= from && e.ExpenseDate <= to && e.IsActive)
                .GroupBy(e => new { e.ExpenseTypeId, e.ExpenseType.Name })
                .Select(g => new ExpenseByTypeDto
                {
                    ExpenseTypeId   = g.Key.ExpenseTypeId,
                    ExpenseTypeName = g.Key.Name,
                    Count           = g.Count(),
                    TotalAmount     = g.Sum(e => e.Amount),
                })
                .OrderByDescending(g => g.TotalAmount)
                .ToListAsync(cancellationToken);

            var dto = new ExpenseSummaryReportDto
            {
                From          = query.From.Date,
                To            = query.To.Date,
                TotalExpenses = expenses.Count,
                TotalAmount   = expenses.Sum(e => e.Amount),
                ByType        = byType,
                Expenses      = expenses,
            };

            return await Result<ExpenseSummaryReportDto>.SuccessAsync(dto);
        }
    }
}
