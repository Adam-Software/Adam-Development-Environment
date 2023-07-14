using AdamDevelopmentEnvironment.Core.Commands;
using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Core.Notification;
using AdamDevelopmentEnvironment.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using System;

namespace AdamDevelopmentEnvironment.Modules.NotifyBar.ViewModels
{
    public class NotifyBarViewModel : RegionViewModelBase
    {
        public DelegateCommand ExpandNotifyBarCommand { get; private set; }
        public DelegateCommand ClearNotifyBarGrowlsBarCommand { get; private set; }

        private readonly IApplicationCommands mApplicationCommands;
        private bool mNotifyBarIsExpanded = false;

        public NotifyBarViewModel(IRegionManager regionManager, ILoggerService loggerService, IApplicationCommands applicationCommands) : base(regionManager, loggerService)
        {
            mApplicationCommands = applicationCommands;
            ExpandNotifyBarCommand = new DelegateCommand(ExpandNotifyBar);
            ClearNotifyBarGrowlsBarCommand = new DelegateCommand(ClearNotifyBarGrowlsBar);
            mApplicationCommands.ExpandNotifyBarCommand.RegisterCommand(ExpandNotifyBarCommand);
        }

        private void ClearNotifyBarGrowlsBar()
        {
            Growls.ClearNotifyBarGrowls();
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
                    Growls.ClearClobalGrowls();

                Growls.NotShowClobalGrowl = value;
                SetProperty(ref mNotifyBarIsExpanded, value); 
            }
        }

        #endregion

        //TODO Destroy not work
        public override void Destroy()
        {
            mApplicationCommands.ExpandNotifyBarCommand.UnregisterCommand(ExpandNotifyBarCommand);
        }
    }
}
