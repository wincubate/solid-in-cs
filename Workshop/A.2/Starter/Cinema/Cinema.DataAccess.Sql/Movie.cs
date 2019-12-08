using System;

namespace Cinema.DataAccess.Sql
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public short Year { get; set; }
        public string Plot { get; set; }
        public double? ImdbRating { get; set; }
        public decimal? TicketPrice { get; set; }
        public bool IsShowing { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
