using System.Text.RegularExpressions;

namespace RajMango.Application.Common
{
    public static class BangladeshPhoneNormalizer
    {
        private static readonly Regex _validFormat = new(@"^\+8801[3-9]\d{8}$", RegexOptions.Compiled);

        /// <summary>
        /// Converts any common BD number format into +8801XXXXXXXXX.
        /// Returns null for null/empty input. Non-matching input is returned as-is (validation will reject it).
        /// </summary>
        public static string Normalize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            var cleaned = input.Trim().Replace(" ", "").Replace("-", "");

            if (cleaned.StartsWith("+8801"))
                return cleaned;

            if (cleaned.StartsWith("8801"))
                return "+" + cleaned;

            if (cleaned.StartsWith("01"))
                return "+88" + cleaned;

            return cleaned;
        }

        public static bool IsValid(string normalized)
            => !string.IsNullOrEmpty(normalized) && _validFormat.IsMatch(normalized);
    }
}
