
using AdamDevelopmentEnvironment.Core.Commands;
using AdamDevelopmentEnvironment.Core.Notification;
using AdamDevelopmentEnvironment.Modules.Blockly;
using AdamDevelopmentEnvironment.Modules.NotifyBar;
using AdamDevelopmentEnvironment.Modules.ResultEditor;
using AdamDevelopmentEnvironment.Modules.Settings;
using AdamDevelopmentEnvironment.Modules.SourceEditor;
using AdamDevelopmentEnvironment.Modules.StatusBar;
using AdamDevelopmentEnvironment.Services;
using AdamDevelopmentEnvironment.Services.Interfaces;
using AdamDevelopmentEnvironment.Views;
using Bluegrams.Application;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows.Threading;
using HandyWindow = HandyControl.Controls.Window;
using Settings = AdamDevelopmentEnvironment.Core.Properties.Settings;

namespace AdamDevelopmentEnvironment
{
    public partial class App : PrismApplication
    {
        private ILoggerService LoggerService { get; } = new LoggerService();
        private ITcpClientService TcpClientService { get; }

        public App()
        {
            TcpClientService = new TcpClientService(LoggerService);

            Dispatcher.UnhandledException += OnDispatcherUnhandledException;
        }

        protected override HandyWindow CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            // Saved USER settings in app folder (PortableSettingsProvider nuget package)
            PortableSettingsProvider.SettingsFileName = "settings.config";
            PortableSettingsProvider.ApplyProvider(Settings.Default);

            // Fires after change
            // Settings.Default.SettingChanging fires BEFORE change
            Settings.Default.PropertyChanged += OnPropertyChange;

            base.OnStartup(e);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILoggerService>(()=> LoggerService);
            containerRegistry.RegisterSingleton<ITcpClientService>(() => TcpClientService);

            containerRegistry.RegisterSingleton<IApplicationCommands>(() => new ApplicationCommands());
            containerRegistry.RegisterSingleton<IApplicationGrowls>(() => new ApplicationGrowls());
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<BlocklyModule>();
            moduleCatalog.AddModule<SourceEditorModule>();
            moduleCatalog.AddModule<ResultEditorModule>();
            moduleCatalog.AddModule<StatusBarModule>();
            moduleCatalog.AddModule<SettingsModule>();
            moduleCatalog.AddModule<NotifyBarModule>();
        }

        protected override void OnExit(System.Windows.ExitEventArgs e)
        {
            LoggerService.WriteInformationLog($"App close with code {e.ApplicationExitCode}");
            OnAppCrashOrExit();

            base.OnExit(e);
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            LoggerService.WriteFatalLog($"Unhandled exception: {e.Exception}");
            OnAppCrashOrExit();
        }

        private void OnAppCrashOrExit()
        {
            Settings.Default.PropertyChanged -= OnPropertyChange;
            TcpClientService.Dispose();
            LoggerService.Dispose();
        }

        private void OnPropertyChange(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Settings.Default.Save();
            LoggerService.WriteInformationLog("Settings change and save");
        }
    }
}
