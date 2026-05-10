namespace RajMango.Application.Common
{
    public static class UploadDomain
    {
        public const string MangoTypes = "mango-types";
        public const string Users      = "users";
        public const string Feedbacks  = "feedbacks";
        public const string Complaints = "complaints";

        private static readonly HashSet<string> _valid = new(StringComparer.OrdinalIgnoreCase)
            { MangoTypes, Users, Feedbacks, Complaints };

        public static bool IsValid(string domain) => _valid.Contains(domain ?? string.Empty);
    }
}
