using AdamDevelopmentEnvironment.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Windows;
using Settings = AdamDevelopmentEnvironment.Core.Properties.Settings;

namespace AdamDevelopmentEnvironment.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand OpenSettingsWindowCommand { get; private set; }

        private readonly IRegionManager mRegion;
        private readonly IDialogService mDialogService;
        private double mBlocklyWidthRegion = Settings.Default.BlocklyWidthRegion;
        private double mSourceEditorHeight = Settings.Default.SourceEditorHeight;

        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            mRegion = regionManager;
            mDialogService = dialogService;

            OpenSettingsWindowCommand = new DelegateCommand(ShowSettingsDialog);
        }

        public string Title => "Adam Development Environment";

        /// <summary>
        /// The fields determine the position of the splitters relative to the 
        /// left/top element and save it in the settings.
        /// If there are no saved settings, then the fields return a division by *.
        /// </summary>
        #region Position of splitters

        public GridLength BlocklyWidthRegion 
        { 
            get 
            {
                if (mBlocklyWidthRegion == 0)
                    return new GridLength(1, GridUnitType.Star);

                return new GridLength(mBlocklyWidthRegion);
            }

            set
            {
                SetProperty(ref mBlocklyWidthRegion, value.Value);
                Settings.Default.BlocklyWidthRegion = value.Value;
            } 
        }

        public GridLength SourceEditorHeight 
        {
            get
            {
                if (mSourceEditorHeight == 0)
                    return new GridLength(1, GridUnitType.Star);

                return new GridLength(mSourceEditorHeight);
            }

            set
            {
                SetProperty(ref mSourceEditorHeight, value.Value);
                Settings.Default.SourceEditorHeight = value.Value;
            } 
        }

        #endregion

        private void ShowSettingsDialog()
        {
            mDialogService.ShowDialog(nameof(SettingsWindow));
        }
    }
}
