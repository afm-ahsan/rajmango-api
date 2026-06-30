using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using RajMango.Application.Features.Queries;

namespace RajMango.WebApi.Services
{
    public static class PdfExportService
    {
        public static byte[] ExportOrderSummary(OrderSummaryReportDto report)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(30);
                    page.DefaultTextStyle(x => x.FontSize(9));

                    page.Header().Column(col =>
                    {
                        col.Item().Text("Order Summary Report").FontSize(18).Bold();
                        col.Item().Text($"Period: {report.From:dd MMM yyyy} – {report.To:dd MMM yyyy}").FontSize(10).FontColor(Colors.Grey.Darken1);
                    });

                    page.Content().Column(col =>
                    {
                        col.Spacing(12);

                        // Summary cards
                        col.Item().PaddingTop(8).Row(row =>
                        {
                            SummaryCard(row, "Total Orders", report.TotalOrders.ToString());
                            SummaryCard(row, "Total Revenue", $"৳{report.TotalRevenue:N0}");
                            SummaryCard(row, "Collected", $"৳{report.TotalCollected:N0}");
                            SummaryCard(row, "Outstanding", $"৳{report.TotalOutstanding:N0}");
                        });

                        col.Item().Row(row =>
                        {
                            SummaryCard(row, "Pending", report.PendingOrders.ToString());
                            SummaryCard(row, "Confirmed", report.ConfirmedOrders.ToString());
                            SummaryCard(row, "Processing", report.ProcessingOrders.ToString());
                            SummaryCard(row, "Shipped", report.ShippedOrders.ToString());
                            SummaryCard(row, "Delivered", report.DeliveredOrders.ToString());
                            SummaryCard(row, "Cancelled", report.CancelledOrders.ToString());
                        });

                        // Order lines table
                        col.Item().PaddingTop(8).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(1.3f); // Order #
                                columns.RelativeColumn(1f);   // Date
                                columns.RelativeColumn(1.3f); // Mango Type
                                columns.RelativeColumn(1.5f); // Customer
                                columns.RelativeColumn(0.7f); // Qty
                                columns.RelativeColumn(1f);   // Total
                                columns.RelativeColumn(1f);   // Paid
                                columns.RelativeColumn(1f);   // Due
                                columns.RelativeColumn(1f);   // Status
                                columns.RelativeColumn(1f);   // Payment
                            });

                            table.Header(header =>
                            {
                                foreach (var text in new[] { "Order #", "Date", "Mango Type", "Customer", "Qty", "Total", "Paid", "Due", "Status", "Payment" })
                                    header.Cell().Element(HeaderCell).Text(text).Bold();
                            });

                            foreach (var o in report.Orders)
                            {
                                table.Cell().Element(BodyCell).Text(o.OrderNumber);
                                table.Cell().Element(BodyCell).Text(o.OrderDate.ToString("dd MMM yyyy"));
                                table.Cell().Element(BodyCell).Text(o.MangoTypeNames ?? "-");
                                table.Cell().Element(BodyCell).Text(o.CustomerName);
                                table.Cell().Element(BodyCell).Text(o.TotalQuantity.ToString());
                                table.Cell().Element(BodyCell).Text(o.TotalAmount.ToString("N0"));
                                table.Cell().Element(BodyCell).Text(o.PaidAmount.ToString("N0"));
                                table.Cell().Element(BodyCell).Text(o.DueAmount.ToString("N0"));
                                table.Cell().Element(BodyCell).Text(o.OrderStatus.ToString());
                                table.Cell().Element(BodyCell).Text(o.PaymentStatus.ToString());
                            }
                        });
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Generated ").FontSize(8).FontColor(Colors.Grey.Darken1);
                        x.Span($"{DateTime.Now:dd MMM yyyy HH:mm}").FontSize(8).FontColor(Colors.Grey.Darken1);
                        x.Span(" — Page ").FontSize(8).FontColor(Colors.Grey.Darken1);
                        x.CurrentPageNumber().FontSize(8).FontColor(Colors.Grey.Darken1);
                        x.Span(" of ").FontSize(8).FontColor(Colors.Grey.Darken1);
                        x.TotalPages().FontSize(8).FontColor(Colors.Grey.Darken1);
                    });
                });
            });

            return document.GeneratePdf();
        }

        private static IContainer HeaderCell(IContainer container)
        {
            return container
                .Background(Colors.Grey.Lighten2)
                .PaddingVertical(4)
                .PaddingHorizontal(3)
                .BorderBottom(1)
                .BorderColor(Colors.Grey.Darken1);
        }

        private static IContainer BodyCell(IContainer container)
        {
            return container
                .PaddingVertical(3)
                .PaddingHorizontal(3)
                .BorderBottom(0.5f)
                .BorderColor(Colors.Grey.Lighten2);
        }

        private static void SummaryCard(RowDescriptor row, string label, string value)
        {
            row.RelativeItem().Border(1).BorderColor(Colors.Grey.Lighten2).Padding(8).Column(col =>
            {
                col.Item().Text(label).FontSize(8).FontColor(Colors.Grey.Darken1);
                col.Item().Text(value).FontSize(13).Bold();
            });
        }
    }
}
