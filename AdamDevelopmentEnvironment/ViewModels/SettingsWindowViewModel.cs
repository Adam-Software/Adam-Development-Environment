using Prism.Services.Dialogs;
using System;

namespace AdamDevelopmentEnvironment.ViewModels
{
    class SettingsWindowViewModel : IDialogAware
    {
        public string Title => "Настройки приложения";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
            //throw new NotImplementedException();
        }

        public void OnDialogClosed()
        {
            //throw new NotImplementedException();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            //throw new NotImplementedException();
        }
    }
}
