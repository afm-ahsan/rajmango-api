using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using RajMango.Application.Common;
using RajMango.Application.Interfaces;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileStorageService _storage;

        public FileController(IFileStorageService storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Upload an image to the specified domain folder.
        /// domain: mango-types | users | feedbacks | complaints
        /// </summary>
        [HttpPost("upload")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(
            IFormFile file,
            [FromQuery] string domain,
            [FromQuery] string prefix = "file",
            [FromQuery] int? entityId = null,
            CancellationToken ct = default)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { message = "No file provided." });

            if (!UploadDomain.IsValid(domain))
                return BadRequest(new { message = $"Invalid upload domain '{domain}'. Allowed: mango-types, users, feedbacks, complaints." });

            try
            {
                var relativePath = await _storage.SaveAsync(
                    file.OpenReadStream(),
                    file.FileName,
                    file.ContentType,
                    file.Length,
                    domain,
                    prefix,
                    entityId,
                    ct);

                return Ok(new { relativePath });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>Delete a previously uploaded file by its relative path.</summary>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] string relativePath, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return BadRequest(new { message = "relativePath is required." });

            await _storage.DeleteAsync(relativePath, ct);
            return Ok();
        }

        /// <summary>Download a file by its relative path (for non-public files served outside wwwroot).</summary>
        [HttpGet("download")]
        public async Task<IActionResult> Download([FromQuery] string relativePath, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return BadRequest();

            var normalized   = relativePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar);
            var webRoot      = HttpContext.RequestServices
                                   .GetRequiredService<IWebHostEnvironment>().WebRootPath ?? string.Empty;
            var physicalPath = Path.Combine(webRoot, normalized);

            if (!System.IO.File.Exists(physicalPath))
                return NotFound();

            var memory = new MemoryStream();
            await using (var stream = new FileStream(physicalPath, FileMode.Open, FileAccess.Read))
                await stream.CopyToAsync(memory, ct);

            memory.Position = 0;
            return File(memory, GetContentType(physicalPath));
        }

        private static string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            return provider.TryGetContentType(path, out var ct) ? ct : "application/octet-stream";
        }
    }
}
