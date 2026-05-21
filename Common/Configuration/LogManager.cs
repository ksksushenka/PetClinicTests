using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Reflection;

namespace PetClinicTests.Common.Configuration
{
    public static class LogManager
    {
        private static ILogger Logger;

        public static ILogger CreateLogger()
        {
            if (Logger != null) 
                return Logger;

            // Register Serilog logging serive.
            var logPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/Logs/{Assembly.GetExecutingAssembly().GetName().Name ?? "log"}_.log";
            var template = "[{Timestamp:MM/dd/yyy HH:mm:ss}] {Message}{NewLine}{Exception}";

            Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                .WriteTo.File(path: logPath,
                              rollingInterval: RollingInterval.Day,
                              outputTemplate: template)
                .WriteTo.Console(outputTemplate: template,
                                 theme: AnsiConsoleTheme.Code)
                .CreateLogger();

            return Logger;
        }
    }
}
