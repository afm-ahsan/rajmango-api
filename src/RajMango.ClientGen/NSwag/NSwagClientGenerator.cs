using NJsonSchema.CodeGeneration.TypeScript;
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
                "D:\\Workspace\\Projects\\RajMango\\rajmango-ai-governance\\rajmango-web",
                "src",
                "app",
                "services",
                "client-proxy.ts");

            Console.WriteLine($"⏳ Fetching OpenAPI from: {swaggerUrl}");

            var document = await OpenApiDocument.FromUrlAsync(swaggerUrl);

            var settings = new TypeScriptClientGeneratorSettings
            {
                ClassName = "{controller}ServiceProxy",
                Template = TypeScriptTemplate.Angular,
                HttpClass = HttpClass.HttpClient,
                RxJsVersion = 6.0m,
                TypeScriptGeneratorSettings =
                {
                    TypeNameGenerator = new CustomTypeNameGenerator(),
                    MarkOptionalProperties = false,    // emit "prop!: T" (required) to match Angular13 components
                    GenerateCloneMethod = false,
                    GenerateDefaultValues = true,
                    TypeScriptVersion = 4.5m,
                    DateTimeType = TypeScriptDateTimeType.MomentJS  // components call .toDate() on dates
                }
            };

            var generator = new TypeScriptClientGenerator(document, settings);
            var code = generator.GenerateFile();

            // NSwag 14 Angular template emits deprecated OpaqueToken for Angular 2 compat.
            // Angular 4+ requires InjectionToken — fix it here so the output compiles in Angular 13.
            code = code
                .Replace(
                    "import { Injectable, Inject, Optional, OpaqueToken } from '@angular/core';",
                    "import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';")
                .Replace(
                    "export const API_BASE_URL = new OpaqueToken('API_BASE_URL');",
                    "export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
            await File.WriteAllTextAsync(outputPath, code);

            Console.WriteLine($"✅ TypeScript client generated at: {outputPath}");
        }
    }
}