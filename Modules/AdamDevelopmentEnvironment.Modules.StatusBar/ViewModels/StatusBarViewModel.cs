using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Services.Interfaces;
using AdamDevelopmentEnvironment.Services.Interfaces.ILoggerDependency;
using Prism.Regions;

namespace AdamDevelopmentEnvironment.Modules.StatusBar.ViewModels
{
    public class StatusBarViewModel : RegionViewModelBase
    {
        public StatusBarViewModel(IRegionManager regionManager, ILoggerService loggerService) 
            : base(regionManager, loggerService)
        {
            loggerService.LogWriteEvent += LoggerService_LogWriteEvent; 
        }

        private void LoggerService_LogWriteEvent(string logMessage, LogLevel logLevel)
        {
            // you can filtered level shown message
            //if(logLevel <= LogLevel.Error)
            //{

            //}

            LogEventContent = $"{logMessage} is {logLevel} level log";
        }

        private string mLogEventContent;
        public string LogEventContent
        {
            get { return mLogEventContent; }
            set { SetProperty(ref mLogEventContent, value); }
        }

    }
}
