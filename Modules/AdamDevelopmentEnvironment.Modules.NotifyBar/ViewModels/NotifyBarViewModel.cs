using AdamDevelopmentEnvironment.Core.Commands;
using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Core.Notification;
using AdamDevelopmentEnvironment.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;

namespace AdamDevelopmentEnvironment.Modules.NotifyBar.ViewModels
{
    public class NotifyBarViewModel : RegionViewModelBase
    {
        public DelegateCommand ExpandNotifyBarCommand { get; private set; }
        public DelegateCommand ClearNotifyBarGrowlsBarCommand { get; private set; }
        private IApplicationCommands ApplicationCommands { get; }
        private IApplicationGrowls ApplicationGrowls { get; }

        private bool mNotifyBarIsExpanded = false;

        public NotifyBarViewModel(IRegionManager regionManager, ILoggerService loggerService, 
            IApplicationCommands applicationCommands, IApplicationGrowls applicationGrowls) : base(regionManager, loggerService)
        {
            ApplicationCommands = applicationCommands;
            ApplicationGrowls = applicationGrowls;

            ExpandNotifyBarCommand = new DelegateCommand(ExpandNotifyBar);
            ClearNotifyBarGrowlsBarCommand = new DelegateCommand(ClearNotifyBarGrowlsBar);

            ApplicationCommands.ExpandNotifyBarCommand.RegisterCommand(ExpandNotifyBarCommand);
        }

        private void ClearNotifyBarGrowlsBar()
        {
            ApplicationGrowls.ClearNotifyBarGrowls();
        }

        #region Manipulate NotifyBar

        private void ExpandNotifyBar()
        {
            switch (NotifyBarIsExpanded)
            {
                case true:
                    NotifyBarIsExpanded = false;
                    break;
                case false:
                    NotifyBarIsExpanded = true;
                    break;
            }           
        }

        public bool NotifyBarIsExpanded
        {
            get { return mNotifyBarIsExpanded; }
            set 
            {
                if (value == true)
                    ApplicationGrowls.ClearClobalGrowls();

                SetProperty(ref mNotifyBarIsExpanded, value); 
            }
        }

        #endregion

        //TODO Destroy not work
        public override void Destroy()
        {
            ApplicationCommands.ExpandNotifyBarCommand.UnregisterCommand(ExpandNotifyBarCommand);
        }
    }
}
