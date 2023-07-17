using AdamDevelopmentEnvironment.Services.Interfaces;
using AdamDevelopmentEnvironment.Services.Interfaces.ILoggerDependency;
using Serilog;
using Serilog.Events;
using System;

namespace AdamDevelopmentEnvironment.Services
{
    public class LoggerService : ILoggerService
    {
        public event LogWriteEventHandler RaiseLogWriteEvent;

        public LoggerService() 
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings(filePath: "App.config")
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit:10)
                .CreateLogger();            
        }

        public void WriteVerboseLog(string logMessage)
        {
            OnRaiseLogWriteEvent(DateTime.Now.ToLocalTime(), logMessage, LogLevel.Verbose);
            Log.Write(LogEventLevel.Verbose, $"{logMessage}");
        }

        public void WriteDebugLog(string logMessage)
        {
            OnRaiseLogWriteEvent(DateTime.Now.ToLocalTime(), logMessage, LogLevel.Debug);
            Log.Write(LogEventLevel.Debug, $"{logMessage}");
        }

        public void WriteInformationLog(string logMessage)
        {
            OnRaiseLogWriteEvent(DateTime.Now.ToLocalTime(), logMessage, LogLevel.Information);
            Log.Write(LogEventLevel.Information, $"{logMessage}");
        }

        public void WriteWarningLog(string logMessage)
        {
            OnRaiseLogWriteEvent(DateTime.Now.ToLocalTime(), logMessage, LogLevel.Warning);
            Log.Write(LogEventLevel.Warning, $"{logMessage}");
        }

        public void WriteErrorLog(string logMessage)
        {
            OnRaiseLogWriteEvent(DateTime.Now.ToLocalTime(), logMessage, LogLevel.Error);
            Log.Write(LogEventLevel.Error, $"{logMessage}");
        }

        public void WriteFatalLog(string logMessage)
        {
            OnRaiseLogWriteEvent(DateTime.Now.ToLocalTime(), logMessage, LogLevel.Fatal);
            Log.Write(LogEventLevel.Fatal, $"{logMessage}");
        }

        public void Dispose()
        {
           Log.CloseAndFlush();
        }
        protected virtual void OnRaiseLogWriteEvent(DateTime logDateTime, string logMessage, LogLevel logLevel)
        {
            LogWriteEventHandler raiseEvent = RaiseLogWriteEvent;

            LogWriteEventArgs eventArgs = new LogWriteEventArgs
            {
                LogDateTime = logDateTime,
                LogMessage = logMessage,
                LogLevel = logLevel
            };

            raiseEvent?.Invoke(this, eventArgs);
        }
    }
}
