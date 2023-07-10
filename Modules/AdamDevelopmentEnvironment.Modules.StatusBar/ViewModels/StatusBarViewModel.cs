using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Core.Properties;
using AdamDevelopmentEnvironment.Services.Interfaces;
using AdamDevelopmentEnvironment.Services.Interfaces.ILoggerDependency;
using Prism.Regions;
using System;

namespace AdamDevelopmentEnvironment.Modules.StatusBar.ViewModels
{
    public class StatusBarViewModel : RegionViewModelBase
    {
        private string mLogMessage;
        private LogLevel? mLogLevel = null;

        public StatusBarViewModel(IRegionManager regionManager, ILoggerService loggerService) : base(regionManager, loggerService)
        {
            LoggerService.LogWriteEvent += LogWriteEvent; 
        }

        #region Logger Event

        private void LogWriteEvent(DateTime logDateTime, string logMessage, LogLevel logLevel)
        {
            int displayFromLevel = Settings.Default.DisplayLogFromLevel;

            if (((int)logLevel) >= displayFromLevel)
            {
                LogLevel = logLevel;
                LogMessage = $"{logDateTime} {logMessage}";
            }
        }

        #endregion

        #region Logger StatusBar fields

        public string LogMessage
        {
            get { return mLogMessage; }
            set { SetProperty(ref mLogMessage, value); }
        }

        public LogLevel? LogLevel
        {
            get { return mLogLevel; }
            set { SetProperty(ref mLogLevel, value); }
        }

        #endregion
    }
}
