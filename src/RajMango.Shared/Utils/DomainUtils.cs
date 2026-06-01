using RajMango.Shared.Enums;

namespace RajMango.Shared.Utils
{
    public static class DomainUtils
    {
        public static int GetCrateWeight(CrateType crateType)
        {
            return crateType switch
            {
                CrateType.Crate10Kg => 10,
                CrateType.Crate20Kg => 20,
                _ => 0
            };
        }

        /// <summary>
        /// Normalizes a Bangladesh phone number to the local 11-digit format (01XXXXXXXXX).
        /// Handles +8801…, 8801…, 01…, and bare 1… (10-digit) inputs.
        /// </summary>
        public static string NormalizeBangladeshPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return string.Empty;
            var digits = new string(phone.Where(char.IsDigit).ToArray());
            if (digits.StartsWith("880") && digits.Length >= 12)
                return "0" + digits.Substring(3);
            if (digits.Length == 10 && digits.StartsWith("1"))
                return "0" + digits;
            return digits;
        }
    }
}
