using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace core.Utilities;

/// <summary>
/// Json Utility
/// </summary>
public static class JsonUtility
{
    /// <summary>
    /// Validate Json
    /// </summary>
    /// <param name="file">Implements <see cref="IFormFile"/></param>
    /// <returns>Returns <see cref="bool"/></returns>
    public async static Task<bool> ValidateJson(IFormFile file)
    {
        string jsonString = await FileUtility.ReadFileContentsAsync(file);
        try
        {
            using JsonDocument document = JsonDocument.Parse(jsonString);
            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }
}
