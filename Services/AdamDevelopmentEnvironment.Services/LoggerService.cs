using AdamDevelopmentEnvironment.Services.Interfaces;
using AdamDevelopmentEnvironment.Services.Interfaces.ILoggerDependency;
using Serilog;
using Serilog.Events;
using System;

namespace AdamDevelopmentEnvironment.Services
{
    public class LoggerService : ILoggerService
    {
        public event LogWriteEventHandler LogWriteEvent;

        public LoggerService() 
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings(filePath: "App.config")
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit:10)
                .CreateLogger();            
        }

        public void WriteVerboseLog(string logMessage)
        {
            LogWriteEvent?.Invoke(DateTime.Now.ToLocalTime(), logMessage, LogLevel.Verbose);
            Log.Write(LogEventLevel.Verbose, $"{logMessage}");
        }

        public void WriteDebugLog(string logMessage)
        {
            LogWriteEvent?.Invoke(DateTime.Now.ToLocalTime(), logMessage, LogLevel.Debug);
            Log.Write(LogEventLevel.Debug, $"{logMessage}");
        }

        public void WriteInformationLog(string logMessage)
        {
            LogWriteEvent?.Invoke(DateTime.Now.ToLocalTime(), logMessage, LogLevel.Information);
            Log.Write(LogEventLevel.Information, $"{logMessage}");
        }

        public void WriteWarningLog(string logMessage)
        {
            LogWriteEvent?.Invoke(DateTime.Now.ToLocalTime(), logMessage, LogLevel.Warning);
            Log.Write(LogEventLevel.Warning, $"{logMessage}");
        }

        public void WriteErrorLog(string logMessage)
        {
            LogWriteEvent?.Invoke(DateTime.Now.ToLocalTime(), logMessage, LogLevel.Error);
            Log.Write(LogEventLevel.Error, $"{logMessage}");
        }

        public void WriteFatalLog(string logMessage)
        {
            LogWriteEvent?.Invoke(DateTime.Now.ToLocalTime(), logMessage, LogLevel.Fatal);
            Log.Write(LogEventLevel.Fatal, $"{logMessage}");
        }

        public void Dispose()
        {
           Log.CloseAndFlush();
        }

      
    }
}
