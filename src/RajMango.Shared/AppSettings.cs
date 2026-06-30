namespace RajMango.Shared
{
    public class AppSettings
    {
        public Security Security { get; set; }
        public ApiInfo ApiInfo { get; set; }
        public BkashSettings Bkash { get; set; }
        public RedisSettings Redis { get; set; }
        public SmsSettings Sms { get; set; }
    }

    public class BkashSettings
    {
        public string BaseUrl { get; set; }
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        // Full URL bKash will call after customer completes/cancels/fails payment
        public string CallbackUrl { get; set; }
        // Frontend pages to redirect to after callback is processed
        public string FrontendSuccessUrl { get; set; }
        public string FrontendFailureUrl { get; set; }
        public string FrontendCancelUrl { get; set; }
        public bool SandboxMode { get; set; } = true;
        // HTTP call timeout for all bKash gateway requests (Grant/Create/Execute/Query)
        public int TimeoutSeconds { get; set; } = 15;
        // How long a Pending bKash payment may sit unconfirmed before it no longer blocks a retry.
        public int PendingPaymentExpiryMinutes { get; set; } = 15;
    }

    public class RedisSettings
    {
        public string ConnectionString { get; set; }
        public int DefaultExpiryMinutes { get; set; } = 10;
    }

    public class Security
    {
        public Jwt Jwt { get; set; }
    }

    public class Jwt
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Audience { get; set; }
        public string Authority { get; set; }
        public string SecurityScheme { get; set; }
        public string Description { get; set; }
    }

    public class ApiInfo
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
    }

    public class SmsSettings
    {
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Ghonta SMS endpoint.
        /// Format: GET {BaseUrl}?toNo={phone}&amp;msg={encodedMessage}
        /// </summary>
        public string BaseUrl { get; set; } = "https://api.ghonta.com/api/services/app/Event/sms";

        /// <summary>Maximum characters per message. 280 covers two-segment SMS on Ghonta.</summary>
        public int MaxMessageLength { get; set; } = 280;

        /// <summary>HTTP call timeout in seconds. Keeps order updates responsive under provider latency.</summary>
        public int TimeoutSeconds { get; set; } = 5;

        /// <summary>Send SMS to the customer who placed the order.</summary>
        public bool SendToCustomer { get; set; } = true;

        /// <summary>Send a brief admin alert SMS for Confirmed, Cancelled, and Delivered orders.</summary>
        public bool SendToAdmin { get; set; } = false;

        /// <summary>Mobile number for admin alerts. Set via env var SMS__ADMINMOBILENUMBER.</summary>
        public string AdminMobileNumber { get; set; }

        /// <summary>
        /// Dev/test only. When set, all customer SMS are redirected to this number instead of
        /// the real customer phone. Admin SMS (SendToAdmin) are never redirected.
        /// Leave empty in production.
        /// </summary>
        public string TestMobileNumber { get; set; }
    }
}
