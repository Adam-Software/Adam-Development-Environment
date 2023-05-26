using AdamDevelopmentEnvironment.Services.Interfaces;
using Prism.Mvvm;
using System.Windows;
using Settings = AdamDevelopmentEnvironment.Core.Properties.Settings;

namespace AdamDevelopmentEnvironment.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public string Title => "Adam Development Environment";

        private double mBlocklyWidthRegion = Settings.Default.BlocklyWidthRegion;
        private double mSourceEditorHeight = Settings.Default.SourceEditorHeight;
        private ILoggerService LoggerService { get; set; }

        public MainWindowViewModel(ILoggerService loggerService)
        {
            LoggerService = loggerService;
            LoggerService.WriteInformationLog("Main window loaded");
            //loggerService.WriteInformationLog("Main window loaded");
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
