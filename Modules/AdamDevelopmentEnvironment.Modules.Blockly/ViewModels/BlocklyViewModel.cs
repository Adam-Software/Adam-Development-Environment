using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Services.Interfaces;
using Prism.Regions;

namespace AdamDevelopmentEnvironment.Modules.Blockly.ViewModels
{
    public class BlocklyViewModel : RegionViewModelBase
    {
        public BlocklyViewModel(IRegionManager regionManager, ILoggerService loggerService) : base(regionManager, loggerService)
        {
            
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
     
        }


    }
}
