namespace RajMango.Shared
{
    public class AppSettings
    {
        public Security Security { get; set; }
        public ApiInfo ApiInfo { get; set; }
        public BkashSettings Bkash { get; set; }
        public RedisSettings Redis { get; set; }
    }

    public class BkashSettings
    {
        public string BaseUrl { get; set; }
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
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
}
