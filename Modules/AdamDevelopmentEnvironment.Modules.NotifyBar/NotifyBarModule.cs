using AdamDevelopmentEnvironment.Core;
using AdamDevelopmentEnvironment.Modules.NotifyBar.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace AdamDevelopmentEnvironment.Modules.NotifyBar
{
    public class NotifyBarModule : IModule
    {
        private readonly IRegionManager mRegionManager;

        public NotifyBarModule(IRegionManager regionManager)
        {
            mRegionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            mRegionManager.RequestNavigate(RegionNames.NotifyBar, nameof(NotifyBarView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NotifyBarView>();
        }
    }
}