using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Services.Interfaces;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;

namespace AdamDevelopmentEnvironment.ViewModels
{
    class SettingsWindowViewModel : RegionViewModelBase, IDialogAware
    {
       
        public SettingsWindowViewModel(IRegionManager regionManager, IChatBotService chatBotService) : base(regionManager)
        {
            
        }
        
        public string Title => "Настройки приложения";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
           
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }
    }
}
