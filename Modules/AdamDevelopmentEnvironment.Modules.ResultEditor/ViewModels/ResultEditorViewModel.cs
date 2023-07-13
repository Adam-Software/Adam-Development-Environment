using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Services.Interfaces;
using HandyControl.Controls;
using Prism.Commands;
using Prism.Regions;
using System;

namespace AdamDevelopmentEnvironment.Modules.ResultEditor.ViewModels
{
    public class ResultEditorViewModel : RegionViewModelBase
    {
        public DelegateCommand TestCommand { get; private set; }
        public DelegateCommand TestCommand2 { get; private set; }

        public ResultEditorViewModel(IRegionManager regionManager, ILoggerService loggerService) : base(regionManager, loggerService)
        {
            TestCommand = new DelegateCommand(Test);
            TestCommand2 = new DelegateCommand(Test2);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext){}

        private void Test()
        {
            Growl.Success("File saved successfully!", "AllMessage");
        }

        private void Test2()
        {
            Growl.Error("On no! error", "AllMessage");
        }
    }
}
