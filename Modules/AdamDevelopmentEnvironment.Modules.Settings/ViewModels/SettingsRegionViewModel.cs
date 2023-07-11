using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Modules.Settings.Views;
using AdamDevelopmentEnvironment.Services.Interfaces;
using AdamDevelopmentEnvironment.Services.Interfaces.ILoggerDependency;
using HandyControl.Controls;
using Prism.Regions;
using System;
using System.Windows;

namespace AdamDevelopmentEnvironment.Modules.Settings.ViewModels
{
    public class SettingsRegionViewModel : RegionViewModelBase
    {
        public string Title => "Настройки приложения";

        private bool IsVisible = false;
        public SettingsRegionViewModel(IRegionManager regionManager, ILoggerService loggerService) : base(regionManager, loggerService)
        {
            
        }

        public override void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            if (IsVisible)
                return;

            LoggerService.WriteInformationLog("Open settings window");

            Dialog dialog = Dialog.Show<SettingsRegionView>();
            IsVisible = dialog.IsVisible;
            dialog.Unloaded += DialogUnloaded;
        }

        private void DialogUnloaded(object sender, RoutedEventArgs e)
        {
            IsVisible = false;
            LoggerService.WriteInformationLog("Close settings window");
        }

        #region LogLevelCollection collection

        private Array mLogLevelCollection = Enum.GetValues(typeof(LogLevel));
        public Array LogLevelCollection
        {
            get { return mLogLevelCollection; }
            set { SetProperty(ref mLogLevelCollection, value); }
        }

        #endregion
    }
}
