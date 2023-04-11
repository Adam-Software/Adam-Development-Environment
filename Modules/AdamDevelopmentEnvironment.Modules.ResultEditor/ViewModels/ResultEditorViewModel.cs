using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Services.Interfaces;
using Prism.Regions;

namespace AdamDevelopmentEnvironment.Modules.ResultEditor.ViewModels
{
    public class ResultEditorViewModel : RegionViewModelBase
    {
        public ResultEditorViewModel(IRegionManager regionManager, ILoggerService loggerService) 
            : base(regionManager, loggerService)
        {
            
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }
    }
}
