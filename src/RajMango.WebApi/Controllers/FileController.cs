using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
//using System.Net.Http.Headers;

namespace RajMango.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        [Route("upload-image")]
        public async Task<IActionResult> UploadImage()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var imageDirectory = GetImageDirectory(file.Name.Trim());
                var rootDirectory = Path.Combine(Directory.GetCurrentDirectory(), imageDirectory);
                
                if(!Directory.Exists(rootDirectory))
                {
                    Directory.CreateDirectory(rootDirectory);
                }
                
                if (file.Length > 0)
                {
                    //var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(rootDirectory, file.FileName.Trim());
                    var imagePath = Path.Combine(imageDirectory, file.FileName.Trim());
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { imagePath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpDelete]
        [Route("delete-image/{fileName}/{location}")]
        public IActionResult Delete(string fileName, string location)
        {
            try
            {
                if (!string.IsNullOrEmpty(fileName))
                {
                    var imageDirectory = GetImageDirectory(location);
                    var rootDirectory = Path.Combine(Directory.GetCurrentDirectory(), imageDirectory);
                    var fileToDelete = Path.Combine(rootDirectory, fileName);

                    if (System.IO.File.Exists(fileToDelete))
                    {
                        System.IO.File.Delete(fileToDelete);
                    }
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("download")]
        public async Task<IActionResult> Download([FromQuery] string fileUrl)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileUrl);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var memory = new MemoryStream();
            await using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(filePath), filePath);
        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("get-images")]
        public IActionResult GetPhotos()
        {
            try
            {
                var folderName = Path.Combine("Resources", "Images");
                var pathToRead = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var photos = Directory.EnumerateFiles(pathToRead)
                    .Where(IsImageFile)
                    .Select(fullPath => Path.Combine(folderName, Path.GetFileName(fullPath)));

                return Ok(new { photos });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        private bool IsImageFile(string fileName)
        {
            return fileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                   || fileName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                   || fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase);
        }

        private string GetImageDirectory(string location)
        {
            var imageDirectory = Path.Combine("Resources", "Images");
            var splitLocation = location.Trim().Split(' ');
            if (splitLocation.Length == 1)
                imageDirectory = Path.Combine("Resources", "Images", splitLocation[0]);
            if (splitLocation.Length == 2)
                imageDirectory = Path.Combine("Resources", "Images", splitLocation[0], splitLocation[1]);
            return imageDirectory;
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return contentType;
        }
    }
}