using AdamDevelopmentEnvironment.Services.Interfaces;
using Serilog;
using Serilog.Events;
using System;

namespace AdamDevelopmentEnvironment.Services
{
    public class LoggerService : ILoggerService, IDisposable
    {
        public LoggerService() 
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings(filePath: "App.config")
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit:10)
                .CreateLogger();
        }

        public void WriteVerboseLog(string logMessage)
        {
            Log.Write(LogEventLevel.Verbose, $"{logMessage}");
        }

        public void WriteDebugLog(string logMessage)
        {
            Log.Write(LogEventLevel.Debug, $"{logMessage}");
        }

        public void WriteInformationLog(string logMessage)
        {
            Log.Write(LogEventLevel.Information, $"{logMessage}");
        }

        public void WriteWarningLog(string logMessage)
        {
            Log.Write(LogEventLevel.Warning, $"{logMessage}");
        }

        public void WriteErrorLog(string logMessage)
        {
            Log.Write(LogEventLevel.Error, $"{logMessage}");
        }

        public void WriteFatalLog(string logMessage)
        {
            Log.Write(LogEventLevel.Fatal, $"{logMessage}");
        }

        public void Dispose()
        {
           Log.CloseAndFlush();
        }
    }
}
