using Admin.Domain.Interfaces;
using Admin.UI.WpfApp.ViewModels;
using System.Windows;

namespace Admin.UI.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnApplicationStartup(object sender, StartupEventArgs e)
        {
            // Composition Root
            ICreateUserService service = null; // <-- TODO: Create proper service

            // UI Layer
            CreateUserViewModel vm = new CreateUserViewModel(service);

            this.MainWindow = new CreateUserWindow(vm);
            this.MainWindow.Show();
        }
    }
}
