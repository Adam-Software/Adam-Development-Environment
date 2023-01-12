using AdamDevelopmentEnvironment.Core;
using AdamDevelopmentEnvironment.Modules.SourceEditor.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace AdamDevelopmentEnvironment.Modules.SourceEditor
{
    public class SourceEditorModule : IModule
    {
        private readonly IRegionManager mRegionManager;

        public SourceEditorModule(IRegionManager regionManager)
        {
            mRegionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            mRegionManager.RequestNavigate(RegionNames.SourceEditorRegion, nameof(SourceEditorView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SourceEditorView>();
        }
    }
}