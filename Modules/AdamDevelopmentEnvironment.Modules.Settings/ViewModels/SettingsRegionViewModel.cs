using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Modules.Settings.Views;
using AdamDevelopmentEnvironment.Services.Interfaces;
using HandyControl.Controls;
using Prism.Regions;
using System;

namespace AdamDevelopmentEnvironment.Modules.Settings.ViewModels
{
    public class SettingsRegionViewModel : RegionViewModelBase
    {
        public string Title => "Настройки приложения";

        public SettingsRegionViewModel(IRegionManager regionManager, ILoggerService loggerService) : base(regionManager, loggerService)
        {
        }

        public override void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            Dialog.Show(new SettingsRegionView());
        }
    }
}
