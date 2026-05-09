using NSwag;
using NSwag.CodeGeneration.TypeScript;

namespace RajMango.ClientGen.NSwag
{
    public static class NSwagClientGenerator
    {
        public static async Task RunAsync()
        {
            var swaggerUrl = "https://localhost:7215/swagger/v1/swagger.json";
            var outputPath = Path.Combine(
                "D:\\Workspace\\Projects\\RajMango\\rajmango_client",
                "src",
                "api",
                "generated-client.ts");

            Console.WriteLine($"⏳ Fetching OpenAPI from: {swaggerUrl}");

            var document = await OpenApiDocument.FromUrlAsync(swaggerUrl);

            var settings = new TypeScriptClientGeneratorSettings
            {
                ClassName = "{controller}Client",
                Template = TypeScriptTemplate.Fetch,
                TypeScriptGeneratorSettings =
                {
                    TypeNameGenerator = new CustomTypeNameGenerator(),
                    MarkOptionalProperties = true,
                    GenerateCloneMethod = false,
                    GenerateDefaultValues = true,
                    TypeScriptVersion = 4.5m
                }
            };

            var generator = new TypeScriptClientGenerator(document, settings);
            var code = generator.GenerateFile();

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            await File.WriteAllTextAsync(outputPath, code);

            Console.WriteLine($"✅ TypeScript client generated at: {outputPath}");
        }
    }
}