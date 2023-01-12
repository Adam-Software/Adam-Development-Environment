using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Services.Interfaces;
using Prism.Regions;

namespace AdamDevelopmentEnvironment.Modules.Blockly.ViewModels
{
    public class BlocklyViewModel : RegionViewModelBase
    {
        private string mMessage;
        public string Message
        {
            get { return mMessage; }
            set { SetProperty(ref mMessage, value); }
        }

        public BlocklyViewModel(IRegionManager regionManager, IMessageService messageService) :
            base(regionManager)
        {
            Message = messageService.GetMessage();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}
