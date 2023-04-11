
using AdamDevelopmentEnvironment.Modules.Blockly;
using AdamDevelopmentEnvironment.Modules.ResultEditor;
using AdamDevelopmentEnvironment.Modules.SourceEditor;
using AdamDevelopmentEnvironment.Modules.StatusBar;
using AdamDevelopmentEnvironment.Services;
using AdamDevelopmentEnvironment.Services.Interfaces;
using AdamDevelopmentEnvironment.Views;
using Bluegrams.Application;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Serilog;
using System;
using System.Windows.Threading;
using HandyWindow = HandyControl.Controls.Window;
using Settings = AdamDevelopmentEnvironment.Core.Properties.Settings;

namespace AdamDevelopmentEnvironment
{
    public partial class App : PrismApplication
    {
        private ILoggerService mILoggerService { get; set; } = new LoggerService();

        public App()
        {
            Dispatcher.UnhandledException += this.OnDispatcherUnhandledException;
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
            containerRegistry.RegisterInstance(mILoggerService);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<BlocklyModule>();
            moduleCatalog.AddModule<SourceEditorModule>();
            moduleCatalog.AddModule<ResultEditorModule>();
            moduleCatalog.AddModule<StatusBarModule>();
        }

        protected override void OnExit(System.Windows.ExitEventArgs e)
        {
            mILoggerService.WriteLog($"App close with code {e.ApplicationExitCode}");

            OnAppCrashOrExit();

            base.OnExit(e);
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            //TODO make this ErrorLog
            mILoggerService.WriteLog($"Unhandled exception: {e.Exception}");

            OnAppCrashOrExit();
        }

        private void OnAppCrashOrExit()
        {
            Settings.Default.PropertyChanged -= OnPropertyChange;
            mILoggerService.Dispose();
        }

        private void OnPropertyChange(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
