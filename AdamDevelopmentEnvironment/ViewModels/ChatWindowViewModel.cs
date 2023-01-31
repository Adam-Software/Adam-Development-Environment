using Prism.Services.Dialogs;
using System;

namespace AdamDevelopmentEnvironment.ViewModels
{
    public class ChatWindowViewModel : IDialogAware
    {
        public string Title => "Чат помощи";

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
