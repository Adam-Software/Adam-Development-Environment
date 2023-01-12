using AdamDevelopmentEnvironment.Core;
using AdamDevelopmentEnvironment.Modules.Blockly.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace AdamDevelopmentEnvironment.Modules.Blockly
{
    public class BlocklyModule : IModule
    {
        private readonly IRegionManager mRegionManager;

        public BlocklyModule(IRegionManager regionManager)
        {
            mRegionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            mRegionManager.RequestNavigate(RegionNames.BlocklyRegion, nameof(BlocklyView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<BlocklyView>();
        }
    }
}