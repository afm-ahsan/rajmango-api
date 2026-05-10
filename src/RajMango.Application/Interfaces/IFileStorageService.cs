namespace RajMango.Application.Interfaces
{
    public interface IFileStorageService
    {
        /// <summary>
        /// Saves a file to the upload store. Returns a relative public URL path
        /// such as /uploads/mango-types/2026/05/mango-type-1-a8f92c.jpg.
        /// Throws InvalidOperationException on validation failure.
        /// </summary>
        Task<string> SaveAsync(
            Stream content,
            string originalFileName,
            string contentType,
            long length,
            string domain,
            string prefix,
            int? entityId = null,
            CancellationToken ct = default);

        /// <summary>Deletes a file by its stored relative path. No-ops if file does not exist.</summary>
        Task DeleteAsync(string relativePath, CancellationToken ct = default);
    }
}
