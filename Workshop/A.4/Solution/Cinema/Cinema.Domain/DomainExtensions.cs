using Cinema.Domain.Interfaces;

namespace Cinema.Domain
{
    internal static class DomainExtensions
    {
        internal static MovieShowing ToMovieShowing(this Movie movie)
            => new MovieShowing(movie.Name, movie.Year, movie.TicketPrice);
    }
}
