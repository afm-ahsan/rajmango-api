namespace RajMango.Application.DTOs.Order
{
    /// <summary>
    /// Extends the standard paginated result with aggregate summary totals computed
    /// across ALL records matching the current filter (not just the current page).
    /// </summary>
    public class AdminOrderPaginatedResult : RajMango.Shared.PaginatedResult<AdminOrderListDto>
    {
        private AdminOrderPaginatedResult() : base(true) { }

        /// <summary>Sum of Order.TotalQuantity across all filtered orders (in kg).</summary>
        public int SummaryTotalQuantityKg { get; set; }

        /// <summary>Total number of 10 kg crates across all filtered order lines.</summary>
        public int SummaryCrate10KgCount { get; set; }

        /// <summary>Total number of 20 kg crates across all filtered order lines.</summary>
        public int SummaryCrate20KgCount { get; set; }

        public static AdminOrderPaginatedResult Create(
            List<AdminOrderListDto> data,
            int totalCount,
            int pageNumber,
            int pageSize,
            int summaryTotalQuantityKg,
            int summaryCrate10KgCount,
            int summaryCrate20KgCount)
        {
            return new AdminOrderPaginatedResult
            {
                Data                  = data,
                Succeeded             = true,
                CurrentPage           = pageNumber,
                PageSize              = pageSize,
                TotalPages            = pageSize > 0 ? (int)Math.Ceiling(totalCount / (double)pageSize) : 0,
                TotalCount            = totalCount,
                SummaryTotalQuantityKg = summaryTotalQuantityKg,
                SummaryCrate10KgCount  = summaryCrate10KgCount,
                SummaryCrate20KgCount  = summaryCrate20KgCount,
            };
        }
    }
}
