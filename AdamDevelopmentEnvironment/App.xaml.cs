
using AdamDevelopmentEnvironment.Modules.Blockly;
using AdamDevelopmentEnvironment.Modules.ResultEditor;
using AdamDevelopmentEnvironment.Modules.SourceEditor;
using AdamDevelopmentEnvironment.Modules.StatusBar;
using AdamDevelopmentEnvironment.Views;
using Bluegrams.Application;
using Prism.Ioc;
using Prism.Modularity;
using HandyWindow = HandyControl.Controls.Window;
using Settings = AdamDevelopmentEnvironment.Core.Properties.Settings;

namespace AdamDevelopmentEnvironment
{
    public partial class App
    {
        protected override HandyWindow CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            // Saved settings in app folder (PortableSettingsProvider nuget package)
            PortableSettingsProvider.SettingsFileName = "settings.config";
            PortableSettingsProvider.ApplyProvider(Settings.Default);

            // Fires after change
            // Settings.Default.SettingChanging fires BEFORE change
            Settings.Default.PropertyChanged += OnPropertyChange;

            base.OnStartup(e);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //services
            //containerRegistry.RegisterInstance<IChatBotService>(new ChatBotService());
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
            Settings.Default.PropertyChanged -= OnPropertyChange;

            base.OnExit(e);
        }

        private void OnPropertyChange(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
