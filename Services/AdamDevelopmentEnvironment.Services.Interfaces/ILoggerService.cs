using AdamDevelopmentEnvironment.Services.Interfaces.ILoggerDependency;
using System;

namespace AdamDevelopmentEnvironment.Services.Interfaces
{
    public delegate void LogWriteEventHandler(string logMessage, LogLevel logLevel);

    public interface ILoggerService : IDisposable
    {
        public event LogWriteEventHandler LogWriteEvent;

        /// <summary>
        /// Anything and everything you might want to know about
        /// a running block of code.
        /// </summary>
        public void WriteVerboseLog(string logMessage);

        /// <summary>
        /// Internal system events that aren't necessarily
        /// observable from the outside.
        /// </summary>
        public void WriteDebugLog(string logMessage);

        /// <summary>
        /// The lifeblood of operational intelligence - things
        /// happen.
        /// </summary>
        public void WriteInformationLog(string logMessage);

        /// <summary>
        /// Service is degraded or endangered.
        /// </summary>
        public void WriteWarningLog(string logMessage);

        /// <summary>
        /// Functionality is unavailable, invariants are broken
        /// or data is lost.
        /// </summary>
        public void WriteErrorLog(string logMessage);

        /// <summary>
        /// If you have a pager, it goes off when one of these
        /// occurs.
        /// </summary>
        public void WriteFatalLog(string logMessage);
    }
}
