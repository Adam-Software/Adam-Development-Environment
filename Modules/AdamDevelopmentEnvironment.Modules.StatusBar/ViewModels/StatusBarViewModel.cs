using AdamDevelopmentEnvironment.Core.Commands;
using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Core.Properties;
using AdamDevelopmentEnvironment.Services.Interfaces;
using AdamDevelopmentEnvironment.Services.Interfaces.ILoggerDependency;
using Prism.Regions;

namespace AdamDevelopmentEnvironment.Modules.StatusBar.ViewModels
{
    public class StatusBarViewModel : RegionViewModelBase
    {
        private IApplicationCommands mApplicationCommands;
        private string mLogMessage;
        private LogLevel? mLogLevel = null;

        public StatusBarViewModel(IRegionManager regionManager, ILoggerService loggerService, IApplicationCommands applicationCommands) : base(regionManager, loggerService)
        {
            ApplicationCommands = applicationCommands;
            LoggerService.RaiseLogWriteEvent += HandleLogWriteEvent; 
        }

        public IApplicationCommands ApplicationCommands
        {
            get { return mApplicationCommands; }
            set { SetProperty(ref mApplicationCommands, value); }
        }

        #region Logger Event

        private void HandleLogWriteEvent(object sender, LogWriteEventArgs logWriteEventArgs)
        {
            int displayFromLevel = Settings.Default.DisplayLogFromLevel;

            if (((int)logWriteEventArgs.LogLevel) >= displayFromLevel)
            {
                LogLevel = logWriteEventArgs.LogLevel;
                LogMessage = $"{logWriteEventArgs.LogDateTime} {logWriteEventArgs.LogMessage}";
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
