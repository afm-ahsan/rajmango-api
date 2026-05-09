namespace RajMango.Application.Features.Services
{
    public static class UserNameGenerator
    {
        private static readonly Random _random = new();

        public static string GenerateUsername(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("First and last names are required.");

            var initials = $"{char.ToUpper(firstName[0])}{char.ToUpper(lastName[0])}";
            var randomDigits = _random.Next(1000, 9999);
            return $"{initials}{randomDigits}";
        }
    }

}
