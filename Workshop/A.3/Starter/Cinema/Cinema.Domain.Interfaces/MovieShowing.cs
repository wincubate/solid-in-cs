namespace Cinema.Domain.Interfaces
{
    public class MovieShowing
    {
        public string Name { get; }
        public short Year { get; }
        public decimal? TicketPrice { get; }

        public MovieShowing( string name, short year, decimal? ticketPrice )
        {
            Name = name;
            Year = year;
            TicketPrice = ticketPrice;
        }
    }
}
