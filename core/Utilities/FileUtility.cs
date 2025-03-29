using Microsoft.AspNetCore.Http;

namespace core.Utilities;

/// <summary>
/// File Utility
/// </summary>
public static class FileUtility
{
    /// <summary>
    /// Read File Contents Async
    /// </summary>
    /// <param name="file">Implements <see cref="IFormFile"/></param>
    /// <returns>Returns <see cref="string"/></returns>
    public static async Task<string> ReadFileContentsAsync(IFormFile file)
    {
        using var reader = new StreamReader(file.OpenReadStream());
        return await reader.ReadToEndAsync();
    }
}
