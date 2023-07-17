using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Core.Notification;
using AdamDevelopmentEnvironment.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;

namespace AdamDevelopmentEnvironment.Modules.ResultEditor.ViewModels
{
    public class ResultEditorViewModel : RegionViewModelBase
    {
        public DelegateCommand TestCommand { get; private set; }
        public DelegateCommand TestCommand2 { get; private set; }

        private readonly IApplicationGrowls mApplicationGrowls;

        public ResultEditorViewModel(IRegionManager regionManager, ILoggerService loggerService, IApplicationGrowls applicationGrowls) : base(regionManager, loggerService)
        {
            mApplicationGrowls = applicationGrowls;

            TestCommand = new DelegateCommand(Test);
            TestCommand2 = new DelegateCommand(Test2);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext){}

        private void Test()
        {
            mApplicationGrowls.InformationGrowls("Growl information happened");
        }

        private void Test2()
        {
            mApplicationGrowls.ErrorGrowls("Growl error happened");
        }
    }
}
