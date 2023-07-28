using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Core.Notification;
using AdamDevelopmentEnvironment.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using System;

namespace AdamDevelopmentEnvironment.Modules.ResultEditor.ViewModels
{
    public class ResultEditorViewModel : RegionViewModelBase
    {
        public DelegateCommand TestCommand { get; private set; }
        public DelegateCommand TestCommand2 { get; private set; }
        public DelegateCommand TestCommand3 { get; private set; }

        private readonly IApplicationGrowls mApplicationGrowls;

        public ResultEditorViewModel(IRegionManager regionManager, ILoggerService loggerService, IApplicationGrowls applicationGrowls) : base(regionManager, loggerService)
        {
            mApplicationGrowls = applicationGrowls;

            TestCommand = new DelegateCommand(Test);
            TestCommand2 = new DelegateCommand(Test2);
            TestCommand3 = new DelegateCommand(Test3);
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

        private void Test3()
        {
            mApplicationGrowls.AskGrowls("Growl ask happened",  AskAction);
        }

        private bool AskAction(bool arg)
        {
            mApplicationGrowls.InformationGrowls($"Ask action work! Arg is {arg}");
            return arg;
        }
    }
}
