using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Services.Interfaces;
using Prism.Regions;

namespace AdamDevelopmentEnvironment.Modules.StatusBar.ViewModels
{
    public class StatusBarViewModel : RegionViewModelBase
    {
        public StatusBarViewModel(IRegionManager regionManager, ILoggerService loggerService) 
            : base(regionManager, loggerService)
        {
            
        }
    }
}
