using core.Models.AppSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace core.Extensions.StartUpExtensions;

/// <summary>
/// Logging Configuration
/// </summary>
public static class LoggingExtension
{
    /// <summary>
    /// Register Serilog Logging
    /// </summary>
    /// <param name="services">Implements <see cref="IServiceCollection"/></param>
    /// <param name="configuration">Implements <see cref="IConfiguration"/></param>
    /// <param name="hostName">IHostname</param>
    /// <param name="loggerConfiguration">Logger Configuration</param>
    /// <returns></returns>
    public static IServiceCollection RegisterSerilogLogging(this IServiceCollection services, IConfiguration configuration, HostBuilderContext hostName, LoggerConfiguration loggerConfiguration)
    {
        LoggingSettings loggingSettings = configuration.GetSection("Logging").Get<LoggingSettings>()!;

        services.AddLogging(loggingBuilder =>
        {
            loggerConfiguration
            .MinimumLevel.Is(LogEventLevel.Verbose)
            .WriteTo.File(loggingSettings.File.Path ?? "Logs/log.log",
                restrictedToMinimumLevel: GetLogLevel(loggingSettings.File.LogLevel.Default),
                rollingInterval: GetRollingInterval(loggingSettings.File.RollingInterval),
                rollOnFileSizeLimit: loggingSettings.File.RollOnFileSizeLimit,
                fileSizeLimitBytes: loggingSettings.File.FileSizeLimitBytes,
                retainedFileCountLimit: loggingSettings.File.RetainedFileCountLimit)
            .WriteTo.Console(restrictedToMinimumLevel: GetLogLevel(loggingSettings.Console.LogLevel.Default))
            .WriteTo.Seq(loggingSettings.Seq.ServerUrl,
                restrictedToMinimumLevel: GetLogLevel(loggingSettings.Seq.LogLevel.Default));
        });

        return services;
    }

    private static LogEventLevel GetLogLevel(string minLogLevel) => minLogLevel?.ToLower() switch
    {
        "trace" => LogEventLevel.Verbose,
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
