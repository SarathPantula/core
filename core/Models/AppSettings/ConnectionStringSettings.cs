namespace core.Models.AppSettings;

/// <summary>
/// ConnectionStrings
/// </summary>
public class ConnectionStringSettings
{
    /// <summary>
    /// PostgresConnectionString
    /// </summary>
    public string PostgresConnectionString { get; set; } = null!;

    /// <summary>
    /// Azure Blob Storage Connection String
    /// </summary>

    public string AzureBlobStorageConnectionString { get; set; } = null!;
}
