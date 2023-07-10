using AdamDevelopmentEnvironment.Core;
using AdamDevelopmentEnvironment.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;
using Settings = AdamDevelopmentEnvironment.Core.Properties.Settings;

namespace AdamDevelopmentEnvironment.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public  string Title => "Adam Development Environment";
        public DelegateCommand OpenSettingsWindowCommand { get; private set; }

        private double mBlocklyWidthRegion = Settings.Default.BlocklyWidthRegion;
        private double mSourceEditorHeight = Settings.Default.SourceEditorHeight;
        private ILoggerService LoggerService { get; set; }
        private IRegionManager RegionManager { get; set; }

        public MainWindowViewModel(IRegionManager regionManager, ILoggerService loggerService)
        {
            RegionManager = regionManager;
            LoggerService = loggerService;

            LoggerService.WriteInformationLog("Main window loaded");
            OpenSettingsWindowCommand = new DelegateCommand(OpenSettingsWindow);
        }

        private void OpenSettingsWindow()
        {
            string settingRegionName = RegionNames.SettingsRegion;
            RegionManager.RequestNavigate(settingRegionName, settingRegionName);   
        }


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
                LoggerService.WriteDebugLog($"Update {nameof(BlocklyWidthRegion)} with value {value.Value}");
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
                LoggerService.WriteDebugLog($"Update {nameof(SourceEditorHeight)} with value {value.Value}");
                SetProperty(ref mSourceEditorHeight, value.Value);
                Settings.Default.SourceEditorHeight = value.Value;
            } 
        }

        #endregion
    }
}
