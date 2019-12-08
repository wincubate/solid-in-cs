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
            IMovieService service = new MovieService(
                new XmlMovieRepository( @"..\..\..\..\..\..\..\02 - Movies.xml"),
                new DefaultTimeProvider()
            );

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
