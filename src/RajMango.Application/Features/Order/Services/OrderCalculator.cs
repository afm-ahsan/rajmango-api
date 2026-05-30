using RajMango.Application.DTOs.Order;
using RajMango.Shared.Utils;

namespace RajMango.Application.Features.Services
{
    public class OrderSummary
    {
        public int TotalQuantity { get; set; }
        public decimal ProductTotalAmount { get; set; }
        public decimal CourierCharge { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public static class OrderCalculator
    {
        /// <summary>
        /// Calculates order totals using backend-enforced prices from MangoAvailability.
        /// pricePerKgByMangoTypeId: MangoTypeId → PricePerKg from the active availability record.
        /// UnitPrice on each OrderDetailInputDto is intentionally ignored; pricing is always server-authoritative.
        /// </summary>
        public static OrderSummary CalculateTotals(
            IEnumerable<OrderDetailInputDto> details,
            IReadOnlyDictionary<int, decimal> pricePerKgByMangoTypeId,
            decimal courierCharge = 0m)
        {
            var totalKg = 0;
            decimal productTotal = 0;

            foreach (var item in details)
            {
                var crateWeight = DomainUtils.GetCrateWeight(item.CrateType);
                var pricePerKg  = pricePerKgByMangoTypeId[item.MangoTypeId];
                var lineKg      = item.Quantity * crateWeight;
                var lineAmount  = lineKg * pricePerKg - item.Discount;

                totalKg      += lineKg;
                productTotal += lineAmount;
            }

            return new OrderSummary
            {
                TotalQuantity      = totalKg,
                ProductTotalAmount = productTotal,
                CourierCharge      = courierCharge,
                TotalAmount        = productTotal + courierCharge,
            };
        }

        /// <summary>
        /// Calculates courier charge from weight and rate config.
        /// Returns max(totalWeightKg * ratePerKg, minimumCharge).
        /// </summary>
        public static decimal CalculateCourierCharge(int totalWeightKg, decimal ratePerKg, decimal? minimumCharge)
        {
            var calculated = totalWeightKg * ratePerKg;
            return minimumCharge.HasValue && minimumCharge.Value > calculated
                ? minimumCharge.Value
                : calculated;
        }
    }
}
