using RajMango.Application.DTOs.Order;
using RajMango.Shared.Utils;

namespace RajMango.Application.Features.Services
{
    public class OrderSummary
    {
        public int TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public static class OrderCalculator
    {
        public static OrderSummary CalculateTotals(IEnumerable<OrderDetailInputDto> details)
        {
            var totalQuantity = 0;
            decimal totalAmount = 0;

            foreach (var item in details)
            {
                var crateWeight = DomainUtils.GetCrateWeight(item.CrateType);
                totalQuantity += item.Quantity * crateWeight;
                totalAmount += item.Quantity * item.UnitPrice * crateWeight;
            }

            return new OrderSummary
            {
                TotalQuantity = totalQuantity,
                TotalAmount = totalAmount
            };
        }
    }
}
