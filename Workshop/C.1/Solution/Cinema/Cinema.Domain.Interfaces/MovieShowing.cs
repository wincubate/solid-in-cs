using System;

namespace Cinema.Domain.Interfaces
{
    public class MovieShowing
    {
        public string Name { get; }
        public short Year { get; }
        public decimal? TicketPrice { get; }

        public MovieShowing(string name, short year, decimal? ticketPrice)
        {
            Name = name;
            Year = year;
            TicketPrice = ticketPrice;
        }

        public MovieShowing ApplySpecialDayDiscounts(ITimeProvider timeProvider)
        {
            int happyHourDiscountPercentage = (timeProvider.Now.DayOfWeek == DayOfWeek.Friday ? 50 : 0);
            return ApplyDiscount(happyHourDiscountPercentage);
        }

        private MovieShowing ApplyDiscount(int discountPercentage)
        {
            decimal? newTicketPrice = null;
            if (TicketPrice.HasValue)
            {
                decimal discountFactor = (100 - discountPercentage) / 100m;
                newTicketPrice = TicketPrice.Value * discountFactor;
            }

            return new MovieShowing(
                Name,
                Year,
                newTicketPrice
            );
        }
    }
}
