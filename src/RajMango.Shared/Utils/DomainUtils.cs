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
    }
}
