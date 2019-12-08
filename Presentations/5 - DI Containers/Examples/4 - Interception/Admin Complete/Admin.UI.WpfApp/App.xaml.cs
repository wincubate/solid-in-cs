using System.Windows;

namespace Admin.UI.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private DependencyInjectionConfig _diConfig;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Composition Root
            _diConfig = new DependencyInjectionConfig();
            _diConfig.Register();

            this.MainWindow = _diConfig.Resolve<CreateUserWindow>();
            this.MainWindow.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            _diConfig.Dispose();
        }
    }
}
