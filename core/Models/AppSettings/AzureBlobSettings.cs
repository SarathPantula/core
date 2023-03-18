namespace core.Models.AppSettings;

/// <summary>
/// Azure Blob Storage Settings
/// </summary>
public class AzureBlobSettings
{
    /// <summary>
    /// Azure Blob Storage Container
    /// </summary>
    public string ContainerName { get; set; } = null!;
}
