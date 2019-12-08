using Cinema.DataAccess.Xml;
using Cinema.Domain;
using Cinema.Domain.Interfaces;
using Cinema.PresentationLogic;
using System;
using System.Collections.Generic;

namespace Cinema.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Composition Root
            using (DependencyInjectionConfig diConfig = new DependencyInjectionConfig())
            {
                diConfig.Register();

                IMovieService service = diConfig.Resolve<IMovieService>();
                
                // UI Layer
                IEnumerable<MovieShowing> movies = service.GetMoviesShowing();
                MainViewModel vm = new MainViewModel(movies);

                foreach (MovieViewModel movie in vm.Movies)
                {
                    Console.WriteLine(movie.DisplayText);
                }
            }
        }
    }
}
