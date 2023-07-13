using AdamDevelopmentEnvironment.Core;
using AdamDevelopmentEnvironment.Services;
using AdamDevelopmentEnvironment.Services.Interfaces;
using AdamDevelopmentEnvironment.Views;
using HandyControl.Controls;
using HandyControl.Data;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Threading.Tasks;
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
        private ILoggerService LoggerService { get; }
        private IRegionManager RegionManager { get; }
        private ITcpClientService TcpClientService { get; }

        public MainWindowViewModel(IRegionManager regionManager, ILoggerService loggerService, ITcpClientService tcpClientService)
        {
            RegionManager = regionManager;
            LoggerService = loggerService;
            TcpClientService = tcpClientService;

            LoggerService.WriteInformationLog("Main window loaded");
            OpenSettingsWindowCommand = new DelegateCommand(OpenSettingsWindow);

            tcpClientService.ConnectAsync().Await();

            Application.Current.MainWindow.Loaded += MainWindowLoaded;
            Application.Current.MainWindow.Closed += MainWindowClosed;
        }

        #region MainWindow event

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            //Test connect, so that the log has time to be displayed on the status bar
            TcpClientService.ConnectAsync();
        }

        private void MainWindowClosed(object sender, EventArgs e)
        {
            TcpClientService.Dispose();
        }


        #endregion 

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
