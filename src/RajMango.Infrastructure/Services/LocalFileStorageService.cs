using Microsoft.AspNetCore.Hosting;
using RajMango.Application.Interfaces;

namespace RajMango.Infrastructure.Services
{
    public class LocalFileStorageService : IFileStorageService
    {
        private const long MaxFileSizeBytes = 5 * 1024 * 1024; // 5 MB

        private static readonly HashSet<string> AllowedExtensions = new(StringComparer.OrdinalIgnoreCase)
            { ".jpg", ".jpeg", ".png", ".webp" };

        private static readonly HashSet<string> AllowedContentTypes = new(StringComparer.OrdinalIgnoreCase)
            { "image/jpeg", "image/png", "image/webp" };

        private readonly IWebHostEnvironment _env;

        public LocalFileStorageService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> SaveAsync(
            Stream content,
            string originalFileName,
            string contentType,
            long length,
            string domain,
            string prefix,
            int? entityId = null,
            CancellationToken ct = default)
        {
            Validate(originalFileName, contentType, length);

            var ext      = Path.GetExtension(originalFileName).ToLowerInvariant();
            var now      = DateTime.UtcNow;
            var year     = now.ToString("yyyy");
            var month    = now.ToString("MM");
            var middle   = entityId.HasValue ? entityId.Value.ToString() : Guid.NewGuid().ToString("N")[..8];
            var shortId  = Guid.NewGuid().ToString("N")[..6];
            var fileName = $"{prefix}-{middle}-{shortId}{ext}";

            var webRootPath = GetWebRootPath();
            var folderPath  = Path.Combine(webRootPath, "uploads", domain, year, month);
            Directory.CreateDirectory(folderPath);

            var physicalPath = Path.Combine(folderPath, fileName);
            await using var fs = new FileStream(physicalPath, FileMode.Create, FileAccess.Write, FileShare.None);
            await content.CopyToAsync(fs, ct);

            return $"/uploads/{domain}/{year}/{month}/{fileName}";
        }

        public Task DeleteAsync(string relativePath, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return Task.CompletedTask;

            var normalized = relativePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar);
            var physical   = Path.Combine(GetWebRootPath(), normalized);

            if (File.Exists(physical))
                File.Delete(physical);

            return Task.CompletedTask;
        }

        private static void Validate(string originalFileName, string contentType, long length)
        {
            if (length <= 0)
                throw new InvalidOperationException("File is empty.");

            if (length > MaxFileSizeBytes)
                throw new InvalidOperationException($"File exceeds the maximum allowed size of {MaxFileSizeBytes / 1024 / 1024} MB.");

            var ext = Path.GetExtension(originalFileName ?? string.Empty).ToLowerInvariant();
            if (!AllowedExtensions.Contains(ext))
                throw new InvalidOperationException($"File extension '{ext}' is not allowed. Allowed: {string.Join(", ", AllowedExtensions)}.");

            if (!AllowedContentTypes.Contains(contentType ?? string.Empty))
                throw new InvalidOperationException($"Content type '{contentType}' is not allowed.");
        }

        private string GetWebRootPath()
        {
            var webRoot = _env.WebRootPath;
            if (string.IsNullOrEmpty(webRoot))
            {
                // Fallback when wwwroot doesn't exist yet — create it under ContentRoot
                webRoot = Path.Combine(_env.ContentRootPath, "wwwroot");
                Directory.CreateDirectory(webRoot);
            }
            return webRoot;
        }
    }
}
