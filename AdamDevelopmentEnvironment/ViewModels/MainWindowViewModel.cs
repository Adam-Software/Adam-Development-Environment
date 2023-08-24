using AdamDevelopmentEnvironment.Core;
using AdamDevelopmentEnvironment.Core.Notification;
using AdamDevelopmentEnvironment.Services.Interfaces;
using AdamDevelopmentEnvironment.Services.Interfaces.ITcpClientDependency;
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
        public static string Title => "Adam Development Environment";
        public DelegateCommand OpenSettingsWindowCommand { get; }

        private double mBlocklyWidthRegion = Settings.Default.BlocklyWidthRegion;
        private double mSourceEditorHeight = Settings.Default.SourceEditorHeight;
        private ILoggerService LoggerService { get; }
        private IRegionManager RegionManager { get; }
        private ITcpClientService TcpClientService { get; }
        private IApplicationGrowls ApplicationGrowls { get; }

        public MainWindowViewModel(IRegionManager regionManager, ILoggerService loggerService, ITcpClientService tcpClientService, 
            IApplicationGrowls applicationGrowls)
        {
            RegionManager = regionManager;
            LoggerService = loggerService;
            TcpClientService = tcpClientService;
            ApplicationGrowls = applicationGrowls;

            OpenSettingsWindowCommand = new DelegateCommand(OpenSettingsWindow);

            TcpClientService.RaiseClientConnectedEvent += RaiseClientConnectedEvent;
            TcpClientService.RaiseClientDisconnectedEvent += RaiseClientDisconnectedEvent;

            Task.Run(ReconnectAsync);
        }

        private void DisconnectGrowlShow()
        {
            ApplicationGrowls.AskGrowls("Робот отключен. Переподключить?", isConfirmed =>
            {
                if (isConfirmed)
                {
                    Task.Run(ReconnectAsync);
                }

                return true;
            });
        }
        
        private async void ReconnectAsync()
        {
            try 
            {
                await TcpClientService.ConnectAsync();

                if (!TcpClientService.IsConnected)
                    DisconnectGrowlShow();

            }
            catch(Exception ex)
            {
                LoggerService.WriteErrorLog($"Error when tcp connect {ex.Message}");
                ApplicationGrowls.ErrorGrowls("Задача переподключения закончена с ошибками");
            }
        }

        #region tcp client connected/disconected event

        private void RaiseClientConnectedEvent(object sender, ConnectionEventArgs e)
        {
            ApplicationGrowls.InformationGrowls("Робот подключен");
        }

        private void RaiseClientDisconnectedEvent(object sender, ConnectionEventArgs e)
        {
            DisconnectGrowlShow();
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
    }
}
