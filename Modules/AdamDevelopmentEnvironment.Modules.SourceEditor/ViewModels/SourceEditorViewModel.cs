using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Services.Interfaces;
using Prism.Regions;

namespace AdamDevelopmentEnvironment.Modules.SourceEditor.ViewModels
{
    public class SourceEditorViewModel : RegionViewModelBase
    {
        public SourceEditorViewModel(IRegionManager regionManager, ILoggerService loggerService) 
            : base(regionManager, loggerService)
        {
            
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }
    }
}
