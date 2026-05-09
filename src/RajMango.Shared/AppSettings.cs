namespace RajMango.Shared
{
    public class AppSettings
    {
        public Security Security { get; set; }
        public ApiInfo ApiInfo { get; set; }
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
