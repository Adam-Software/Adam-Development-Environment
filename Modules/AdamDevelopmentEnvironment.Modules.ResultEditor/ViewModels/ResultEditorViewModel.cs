using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Services.Interfaces;
using HandyControl.Controls;
using HandyControl.Data;
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
            Growl.Success("File saved successfully!", "GrowlMessage");
        }

        private void Test2()
        {
            GrowlInfo gf = new()
            {
                Message = "On no! error",
                StaysOpen = true,
                IsCustom = true,
                ShowCloseButton = true,
                WaitTime = 3


                /*ActionBeforeClose = isConfirmed =>
                {
                    Growl.InfoGlobal(isConfirmed.ToString());
                    return true;
                }*/
            };
            Growl.Error(gf);

            gf.StaysOpen = false;
            Growl.ErrorGlobal(gf);
        }
    }
}
