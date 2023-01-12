using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Services.Interfaces;
using Prism.Regions;

namespace AdamDevelopmentEnvironment.Modules.SourceEditor.ViewModels
{
    public class SourceEditorViewModel : RegionViewModelBase
    {
        private string mMessage;
        public string Message
        {
            get { return mMessage; }
            set { SetProperty(ref mMessage, value); }
        }

        public SourceEditorViewModel(IRegionManager regionManager, IMessageService messageService) :
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
