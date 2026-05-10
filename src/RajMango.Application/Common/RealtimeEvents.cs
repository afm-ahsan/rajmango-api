namespace RajMango.Application.Common
{
    /// <summary>
    /// SignalR event name constants shared between backend handlers and the frontend client.
    /// Frontend (rajmango-web) must subscribe to these exact strings.
    /// </summary>
    public static class RealtimeEvents
    {
        public const string OrderCreated            = "order-created";
        public const string OrderStatusUpdated      = "order-status-updated";
        public const string PaymentReceived         = "payment-received";
        public const string ComplaintSubmitted      = "complaint-submitted";
        public const string ComplaintStatusUpdated  = "complaint-status-updated";
        public const string CatalogUpdated          = "catalog-updated";
        public const string AdminAlert              = "admin-alert";
    }
}
