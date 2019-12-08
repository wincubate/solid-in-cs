using Cinema.DataAccess.Xml;
using Cinema.Domain;
using Cinema.Domain.Interfaces;
using Cinema.PresentationLogic;
using System.Collections.Generic;
using System.Windows;

namespace Cinema.UI.WpfApp
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

            IMovieService service = _diConfig.Resolve<IMovieService>();

            // UI Layer
            IEnumerable<MovieShowing> movies = service.GetMoviesShowing();
            MainViewModel vm = new MainViewModel(movies);

            this.MainWindow = new MainWindow(vm);
            this.MainWindow.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            _diConfig.Dispose();
        }
    }
}
