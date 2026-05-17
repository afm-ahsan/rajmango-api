using NJsonSchema;

namespace RajMango.ClientGen.NSwag
{
    public class CustomTypeNameGenerator : ITypeNameGenerator
    {
        public string Generate(JsonSchema schema, string typeNameHint, IEnumerable<string> reservedTypeNames)
        {
            // Strip C# namespace prefix (e.g. "RajMango.Application.DTOs.AppUserDto" → "AppUserDto")
            var name = typeNameHint.Split('.').Last();

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

