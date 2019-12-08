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
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Composition Root
            IMovieService service = new MovieService(
                //new SqlMovieRepository( new MovieContext() )
                new XmlMovieRepository(@"..\..\..\..\..\..\..\02 - Movies.xml")
            );

            // UI Layer
            IEnumerable<MovieShowing> movies = service.GetMoviesShowing();
            MainViewModel vm = new MainViewModel(movies);

            this.MainWindow = new MainWindow(vm);
            this.MainWindow.Show();
        }
    }
}
