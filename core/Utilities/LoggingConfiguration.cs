using core.Models.AppSettings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace core.Utilities;

/// <summary>
/// Logging Configuration
/// </summary>
public class LoggingConfiguration
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly LoggingSettings _loggingSettings;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="loggerFactory">Logging Factory implements <see cref="ILoggerFactory"/></param>
    /// <param name="loggingSettings">Logging Settings <see cref="LoggingSettings"/></param>
    public LoggingConfiguration(ILoggerFactory loggerFactory, IOptions<LoggingSettings> loggingSettings)
    {
        _loggerFactory = loggerFactory;
        _loggingSettings = loggingSettings.Value;
    }

    /// <summary>
    /// Configure
    /// </summary>
    public void Configure()
    {
        var fileLoggingSettings = _loggingSettings.File;
        var consoleLoggingSettings = _loggingSettings.Console;
        var seqLoggingSettings = _loggingSettings.Seq;

        var loggerConfiguration = new LoggerConfiguration()
            .MinimumLevel.ControlledBy(new LoggingLevelSwitch(GetLogLevel(fileLoggingSettings.MinLogLevel)))
            .Enrich.FromLogContext()
            .WriteTo.File(fileLoggingSettings.Path,
                fileSizeLimitBytes: fileLoggingSettings.FileSizeLimitBytes,
                retainedFileCountLimit: fileLoggingSettings.RetainedFileCountLimit,
                rollingInterval: GetRollingInterval(fileLoggingSettings.RollingInterval),
                rollOnFileSizeLimit: fileLoggingSettings.RollOnFileSizeLimit);

        if (!string.IsNullOrEmpty(seqLoggingSettings.ServerUrl))
        {
            loggerConfiguration = loggerConfiguration
                .WriteTo.Seq(seqLoggingSettings.ServerUrl);
        }

        if (GetLogLevel(consoleLoggingSettings.MinLogLevel) != LogEventLevel.Fatal)
        {
            loggerConfiguration = loggerConfiguration
                .WriteTo.Console(GetLogLevel(consoleLoggingSettings.MinLogLevel));
        }

        _loggerFactory.AddSerilog(loggerConfiguration.CreateLogger());
    }

    private static LogEventLevel GetLogLevel(string minLogLevel) => minLogLevel?.ToLower() switch
    {
        "debug" => LogEventLevel.Debug,
        "information" => LogEventLevel.Information,
        "warning" => LogEventLevel.Warning,
        "error" => LogEventLevel.Error,
        "fatal" => LogEventLevel.Fatal,
        _ => LogEventLevel.Information,
    };

    private static RollingInterval GetRollingInterval(string rollingInterval) => rollingInterval switch
    {
        "Hour" => RollingInterval.Hour,
        "Minute" => RollingInterval.Minute,
        "Day" => RollingInterval.Day,
        "Month" => RollingInterval.Month,
        _ => RollingInterval.Day,
    };
}