using System;

namespace AdamDevelopmentEnvironment.Services.Interfaces.ILoggerDependency
{
    public class LogWriteEventArgs : EventArgs
    {
        public DateTime LogDateTime { get; set; }
        public string LogMessage { get; set; }
        public LogLevel LogLevel { get; set; }
    }
}
