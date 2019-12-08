using Cinema.DataAccess.Sql;
using Cinema.DataAccess.Xml;
using Cinema.Domain;
using Cinema.Domain.Interfaces;
using Cinema.PresentationLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Composition Root
            IMovieService service = new MovieService(
                //new SqlMovieRepository( new MovieContext() )
                new XmlMovieRepository( @"..\..\..\..\..\..\..\02 - Movies.xml" )
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
