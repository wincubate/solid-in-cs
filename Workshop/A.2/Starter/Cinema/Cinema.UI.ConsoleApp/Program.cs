using Cinema.DataAccess.Sql;
using Cinema.Domain;
using System;
using System.Collections.Generic;

namespace Cinema.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieService service = new MovieService();
            IEnumerable<Movie> movies = service.GetMoviesShowing();

            foreach (Movie movie in movies)
            {
                string ticketPriceDisplay = movie.TicketPrice.HasValue
                    ? $"- {movie.TicketPrice?.ToString("C")}"
                    : string.Empty;
                Console.WriteLine($"{movie.Name} [{movie.Year}] {ticketPriceDisplay}");
            }
        }
    }
}
