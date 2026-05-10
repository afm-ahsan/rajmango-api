using ClosedXML.Excel;
using RajMango.Application.Features.Queries;

namespace RajMango.WebApi.Services
{
    public static class ExcelExportService
    {
        public static byte[] ExportOrderSummary(OrderSummaryReportDto report)
        {
            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Orders");

            // Summary block
            ws.Cell(1, 1).Value = "Order Summary Report";
            ws.Cell(1, 1).Style.Font.Bold = true;
            ws.Cell(1, 1).Style.Font.FontSize = 14;
            ws.Cell(2, 1).Value = $"Period: {report.From:dd MMM yyyy} – {report.To:dd MMM yyyy}";

            ws.Cell(4, 1).Value = "Total Orders";    ws.Cell(4, 2).Value = report.TotalOrders;
            ws.Cell(5, 1).Value = "Total Revenue";   ws.Cell(5, 2).Value = report.TotalRevenue;
            ws.Cell(6, 1).Value = "Total Collected"; ws.Cell(6, 2).Value = report.TotalCollected;
            ws.Cell(7, 1).Value = "Outstanding";     ws.Cell(7, 2).Value = report.TotalOutstanding;

            // Orders table
            var headers = new[] { "Order #", "Order Date", "Customer", "Qty", "Total", "Paid", "Due", "Status", "Payment" };
            for (int i = 0; i < headers.Length; i++)
            {
                ws.Cell(9, i + 1).Value = headers[i];
                ws.Cell(9, i + 1).Style.Font.Bold = true;
                ws.Cell(9, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
            }

            int row = 10;
            foreach (var o in report.Orders)
            {
                ws.Cell(row, 1).Value = o.OrderNumber;
                ws.Cell(row, 2).Value = o.OrderDate.ToString("dd MMM yyyy");
                ws.Cell(row, 3).Value = o.CustomerName;
                ws.Cell(row, 4).Value = o.TotalQuantity;
                ws.Cell(row, 5).Value = (double)o.TotalAmount;
                ws.Cell(row, 6).Value = (double)o.PaidAmount;
                ws.Cell(row, 7).Value = (double)o.DueAmount;
                ws.Cell(row, 8).Value = o.OrderStatus.ToString();
                ws.Cell(row, 9).Value = o.PaymentStatus.ToString();
                row++;
            }

            ws.Columns().AdjustToContents();

            using var ms = new MemoryStream();
            wb.SaveAs(ms);
            return ms.ToArray();
        }

        public static byte[] ExportPaymentSummary(PaymentSummaryReportDto report)
        {
            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Payments");

            ws.Cell(1, 1).Value = "Payment Summary Report";
            ws.Cell(1, 1).Style.Font.Bold = true;
            ws.Cell(1, 1).Style.Font.FontSize = 14;
            ws.Cell(2, 1).Value = $"Period: {report.From:dd MMM yyyy} – {report.To:dd MMM yyyy}";

            ws.Cell(4, 1).Value = "Total Payments";  ws.Cell(4, 2).Value = report.TotalPayments;
            ws.Cell(5, 1).Value = "Total Collected"; ws.Cell(5, 2).Value = (double)report.TotalPaid;

            var headers = new[] { "Order #", "Date", "Paid", "Net", "Method", "Transaction ID", "Status" };
            for (int i = 0; i < headers.Length; i++)
            {
                ws.Cell(7, i + 1).Value = headers[i];
                ws.Cell(7, i + 1).Style.Font.Bold = true;
                ws.Cell(7, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
            }

            int row = 8;
            foreach (var p in report.Payments)
            {
                ws.Cell(row, 1).Value = p.OrderNumber;
                ws.Cell(row, 2).Value = p.CreatedAt.ToString("dd MMM yyyy");
                ws.Cell(row, 3).Value = (double)p.PaidAmount;
                ws.Cell(row, 4).Value = (double)p.NetAmount;
                ws.Cell(row, 5).Value = p.PaymentMethod.ToString();
                ws.Cell(row, 6).Value = p.TransactionId;
                ws.Cell(row, 7).Value = p.PaymentStatus.ToString();
                row++;
            }

            ws.Columns().AdjustToContents();

            using var ms = new MemoryStream();
            wb.SaveAs(ms);
            return ms.ToArray();
        }

        public static byte[] ExportExpenseSummary(ExpenseSummaryReportDto report)
        {
            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Expenses");

            ws.Cell(1, 1).Value = "Expense Summary Report";
            ws.Cell(1, 1).Style.Font.Bold = true;
            ws.Cell(1, 1).Style.Font.FontSize = 14;
            ws.Cell(2, 1).Value = $"Period: {report.From:dd MMM yyyy} – {report.To:dd MMM yyyy}";

            ws.Cell(4, 1).Value = "Total Expenses"; ws.Cell(4, 2).Value = (double)report.TotalAmount;

            var headers = new[] { "Date", "Type", "Name", "Paid To", "Amount", "Method", "Transaction ID" };
            for (int i = 0; i < headers.Length; i++)
            {
                ws.Cell(6, i + 1).Value = headers[i];
                ws.Cell(6, i + 1).Style.Font.Bold = true;
                ws.Cell(6, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
            }

            int row = 7;
            foreach (var e in report.Expenses)
            {
                ws.Cell(row, 1).Value = e.ExpenseDate.ToString("dd MMM yyyy");
                ws.Cell(row, 2).Value = e.ExpenseTypeName;
                ws.Cell(row, 3).Value = e.Name;
                ws.Cell(row, 4).Value = e.PaidTo;
                ws.Cell(row, 5).Value = (double)e.Amount;
                ws.Cell(row, 6).Value = e.PaymentMethod.ToString();
                ws.Cell(row, 7).Value = e.TransactionId;
                row++;
            }

            ws.Columns().AdjustToContents();

            using var ms = new MemoryStream();
            wb.SaveAs(ms);
            return ms.ToArray();
        }
    }
}
