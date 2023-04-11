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

        
        public void WriteWarningLog(string logMessage)
        {
            Log.Write(LogEventLevel.Warning, $"{logMessage}");
        }

        public void Dispose()
        {
           Log.CloseAndFlush();
        }
    }
}
