namespace core.Models.AppSettings;

/// <summary>
/// Logging Settings
/// </summary>
public class LoggingSettings
{
    /// <summary>
    /// File Settings
    /// </summary>
    public FileLoggingSettings File { get; set; } = null!;
    /// <summary>
    /// Console Settings
    /// </summary>
    public ConsoleLoggingSettings Console { get; set; } = null!;
    /// <summary>
    /// Seq Settings
    /// </summary>
    public SeqLoggingSettings Seq { get; set; } = null!;
}

/// <summary>
/// File Logging Settings
/// </summary>
public class FileLoggingSettings
{
    /// <summary>
    /// File Path
    /// </summary>
    public string Path { get; set; } = null!;
    /// <summary>
    /// File Size Limit in Bytes
    /// </summary>
    public long FileSizeLimitBytes { get; set; }
    /// <summary>
    /// Count of files to be retained
    /// </summary>
    public int RetainedFileCountLimit { get; set; }
    /// <summary>
    /// Rolling Interval
    /// </summary>
    public string RollingInterval { get; set; } = null!;
    /// <summary>
    /// Roll on File Size Limit
    /// </summary>
    public bool RollOnFileSizeLimit { get; set; }
    /// <summary>
    /// Minimum Logging Level
    /// </summary>
    public string MinLogLevel { get; set; } = null!;
}

/// <summary>
/// Console Logging Settings
/// </summary>
public class ConsoleLoggingSettings
{
    /// <summary>
    /// Mimimum Logging Level
    /// </summary>
    public string MinLogLevel { get; set; } = null!;
}

/// <summary>
/// Seq Logging Settings
/// </summary>
public class SeqLoggingSettings
{
    /// <summary>
    /// Server URL
    /// </summary>
    public string ServerUrl { get; set; } = null!;
}
