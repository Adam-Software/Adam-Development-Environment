using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Modules.Settings.Views;
using AdamDevelopmentEnvironment.Services.Interfaces;
using HandyControl.Controls;
using HandyControl.Interactivity;
using HandyControl.Tools;
using HandyControl.Tools.Extension;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Windows;

namespace AdamDevelopmentEnvironment.Modules.Settings.ViewModels
{
    public class SettingsRegionViewModel : RegionViewModelBase
    {
        public DelegateCommand CloseSettingsWindowCommand { get; private set; }
        public bool IsVisible = false;
        
        public SettingsRegionViewModel(IRegionManager regionManager, ILoggerService loggerService) : base(regionManager, loggerService)
        {
           
        }

        public override void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            if (IsVisible)
                return;

            Dialog dialog = Dialog.Show<SettingsRegionView>();

            IsVisible = dialog.IsVisible;
            dialog.Unloaded += DialogUnloaded;
        }

        private void DialogUnloaded(object sender, RoutedEventArgs e)
        {
            IsVisible = false;
        }
    }
}
