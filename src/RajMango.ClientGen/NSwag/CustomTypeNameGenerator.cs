using NJsonSchema;

namespace RajMango.ClientGen.NSwag
{
    public class CustomTypeNameGenerator : ITypeNameGenerator
    {
        public string Generate(JsonSchema schema, string typeNameHint, IEnumerable<string> reservedTypeNames)
        {
            // Strip namespace and apply "I" prefix
            var rawName = typeNameHint.Split('.').Last();
            var name = rawName.StartsWith("I") ? rawName : $"I{rawName}";

            var finalName = name;
            int i = 1;
            while (reservedTypeNames.Contains(finalName))
            {
                finalName = name + i;
                i++;
            }

            return finalName;
        }
    }
}

