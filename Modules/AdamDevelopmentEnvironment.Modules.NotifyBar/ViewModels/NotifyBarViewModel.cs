using AdamDevelopmentEnvironment.Core.Commands;
using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Core.Notification;
using AdamDevelopmentEnvironment.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using System.Windows.Input;

namespace AdamDevelopmentEnvironment.Modules.NotifyBar.ViewModels
{
    public class NotifyBarViewModel : RegionViewModelBase
    {
        public DelegateCommand ExpandNotifyBarCommand { get; private set; }
        public DelegateCommand ClearNotifyBarGrowlsBarCommand { get; private set; }
        public DelegateCommand<object> NotShowClobalGrowlCommand { get; private set; }

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
            NotShowClobalGrowlCommand = new DelegateCommand<object>(NotShowClobalGrowl, CanSubmit);

            ApplicationCommands.ExpandNotifyBarCommand.RegisterCommand(ExpandNotifyBarCommand);
            ApplicationCommands.NotShowClobalGrowlCommand.RegisterCommand(NotShowClobalGrowlCommand);
        }

        private void ClearNotifyBarGrowlsBar()
        {
            ApplicationGrowls.ClearNotifyBarGrowls();
        }

        private void NotShowClobalGrowl(object IsNotShowEnable)
        {
            var s = IsNotShowEnable;
        }

        bool CanSubmit(object parameter)
        {
            return true;
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

                ApplicationGrowls.NotShowClobalGrowl = value;
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
