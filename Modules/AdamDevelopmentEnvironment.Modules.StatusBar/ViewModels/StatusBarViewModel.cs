using AdamDevelopmentEnvironment.Core.Commands;
using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Core.Notification;
using AdamDevelopmentEnvironment.Core.Properties;
using AdamDevelopmentEnvironment.Services.Interfaces;
using AdamDevelopmentEnvironment.Services.Interfaces.ILoggerDependency;
using Prism.Commands;
using Prism.Regions;

namespace AdamDevelopmentEnvironment.Modules.StatusBar.ViewModels
{
    public class StatusBarViewModel : RegionViewModelBase
    {
        public DelegateCommand ClearNotifyBarGrowlsMenuItemCommand { get; private set; }
        private IApplicationGrowls ApplicationGrowls { get; set; }
        private bool mIsSilentModeEnabled = false;
        private LogLevel? mLogLevel = null;

        private IApplicationCommands mApplicationCommands;
        private string mLogMessage;
        private bool mIsGrowlsHappened;

        public StatusBarViewModel(IRegionManager regionManager, ILoggerService loggerService,
            IApplicationCommands applicationCommands, IApplicationGrowls applicationGrowls) : base(regionManager, loggerService)
        {
            LoggerService.RaiseLogWriteEvent += HandleLogWriteEvent;

            ApplicationCommands = applicationCommands;
            ApplicationGrowls = applicationGrowls;

            ApplicationGrowls.RaiseClearGrowlsEvent += RaiseClearGrowlsEvent;
            ApplicationGrowls.RaiseGrowlsHappenedEvent += RaiseGrowlsHappenedEvent;

            ClearNotifyBarGrowlsMenuItemCommand = new DelegateCommand(ClearAllGrowls);
        }

        public IApplicationCommands ApplicationCommands
        {
            get { return mApplicationCommands; }
            set { SetProperty(ref mApplicationCommands, value); }
        }

        #region BellMenu fields

        public bool IsSilentModeEnabled
        {
            get { return mIsSilentModeEnabled; }    
            set 
            {
                ApplicationGrowls.IsSilentModeEnabled = value;
                SetProperty(ref mIsSilentModeEnabled, value); 
            }
        }

        public bool IsGrowlsHappened
        {
            get { return mIsGrowlsHappened; }
            set 
            {
                if (mIsGrowlsHappened == value)
                    return;

                SetProperty(ref mIsGrowlsHappened, value); 
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

        #region Growls method

        private void ClearAllGrowls()
        {
            ApplicationGrowls.ClearNotifyBarGrowls();
            ApplicationGrowls.ClearClobalGrowls();
        }

        #endregion

        #region Logger Event Show

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

        #region GrowlsEvent

        private void RaiseGrowlsHappenedEvent(object sender)
        {
            IsGrowlsHappened = true;
        }

        private void RaiseClearGrowlsEvent(object sender, ClearGrowlsEventArgs e)
        {
            IsGrowlsHappened = false;
        }

        #endregion
    }
}
