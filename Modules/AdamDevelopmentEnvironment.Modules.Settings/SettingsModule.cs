using AdamDevelopmentEnvironment.Core;
using AdamDevelopmentEnvironment.Modules.Settings.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace AdamDevelopmentEnvironment.Modules.Settings
{
    public class SettingsModule : IModule
    {
        private readonly IRegionManager mRegionManager;

        public SettingsModule(IRegionManager regionManager)
        {
            mRegionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            mRegionManager.RequestNavigate(RegionNames.SettingsRegion, nameof(SettingsRegionView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SettingsRegionView>();
        }
    }
}