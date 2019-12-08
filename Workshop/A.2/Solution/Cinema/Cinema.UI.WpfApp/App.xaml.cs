using Cinema.DataAccess.Sql;
using Cinema.Domain;
using Cinema.Domain.Interfaces;
using Cinema.PresentationLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Cinema.UI.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Composition Root
            IMovieService service = new MovieService(
                new SqlMovieRepository(new MovieContext())
            );

            // UI Layer
            IEnumerable<MovieShowing> movies = service.GetMoviesShowing();
            MainViewModel vm = new MainViewModel(movies);

            this.MainWindow = new MainWindow(vm);
            this.MainWindow.Show();
        }
    }
}
