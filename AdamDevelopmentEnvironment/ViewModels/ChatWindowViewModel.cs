using AdamDevelopmentEnvironment.Core.Mvvm;
using AdamDevelopmentEnvironment.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;

namespace AdamDevelopmentEnvironment.ViewModels
{
    public class ChatWindowViewModel : RegionViewModelBase, IDialogAware
    {
        private string mPhoneNumber;
        private readonly IChatBotService mChatBotService;
        public ChatWindowViewModel(IRegionManager regionManager, IChatBotService chatBotService) : base(regionManager)
        {
            mChatBotService = chatBotService;
            
            LoginUserIfNeeded = new DelegateCommand(LoginUser);
        }

        private void LoginUser()
        {
            mChatBotService.LoginUserIfNeeded(PhoneNumber);
        }

        public string PhoneNumber
        {
            get { return mPhoneNumber; }
            set { SetProperty(ref mPhoneNumber, value); }
        }

        public string Title => "Чат помощи";
        public DelegateCommand LoginUserIfNeeded { get; private set; }

        #region IDialogAvare interface method

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

        #endregion
    }
}
