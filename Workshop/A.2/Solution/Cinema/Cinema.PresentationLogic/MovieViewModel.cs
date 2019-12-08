using Cinema.Domain.Interfaces;

namespace Cinema.PresentationLogic
{
    public class MovieViewModel
    {
        public string Name { get; }
        public string DisplayText { get; }

        public MovieViewModel(MovieShowing movie)
        {
            string ticketPriceDisplay = movie.TicketPrice.HasValue
                                ? $"- {movie.TicketPrice?.ToString("C")}"
                                : string.Empty;
            DisplayText = $"{movie.Name} [{movie.Year}] {ticketPriceDisplay}";
        }
    }
}
