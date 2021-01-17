using System.Windows;

namespace Admin.UI.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Composition Root
            using( DependencyInjectionConfig diConfig = new DependencyInjectionConfig() )
            {
                diConfig.Register();

                // UI Layer
                this.MainWindow = diConfig.Resolve<CreateUserWindow>();
                this.MainWindow.Show();
            }
        }
    }
}
