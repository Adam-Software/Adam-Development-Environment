using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Services.Interfaces;
using Prism.Regions;

namespace AdamDevelopmentEnvironment.Modules.StatusBar.ViewModels
{
    public class StatusBarViewModel : RegionViewModelBase
    {
        private string mMessage;
        public string Message
        {
            get { return mMessage; }
            set { SetProperty(ref mMessage, value); }
        }

        public StatusBarViewModel(IRegionManager regionManager, IMessageService messageService) :
            base(regionManager)
        {
            Message = messageService.GetMessage();
        }
    }
}
