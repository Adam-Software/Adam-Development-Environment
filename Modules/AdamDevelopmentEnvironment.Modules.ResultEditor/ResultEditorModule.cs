using AdamDevelopmentEnvironment.Core;
using AdamDevelopmentEnvironment.Modules.ResultEditor.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace AdamDevelopmentEnvironment.Modules.ResultEditor
{
    public class ResultEditorModule : IModule
    {
        private readonly IRegionManager mRegionManager;

        public ResultEditorModule(IRegionManager regionManager)
        {
            mRegionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            mRegionManager.RequestNavigate(RegionNames.ResultsEditorRegion, nameof(ResultEditorView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ResultEditorView>();
        }
    }
}