using Cinema.Domain.Interfaces;
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Cinema.DataAccess.Xml
{
    public class XmlMovieRepository : IMovieRepository
    {
        private readonly string _filePath;

        public XmlMovieRepository(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));

            Debug.WriteLine($"{nameof(XmlMovieRepository)} created");
        }

        public IQueryable<Movie> GetAll()
        {
            XDocument xml = XDocument.Load(_filePath);
            return xml
                .Descendants("Movie")
                .AsQueryable()
                .Select(element => new Movie
                {
                    Id = (Guid)element.Element(nameof(Movie.Id)),
                    Name = (string) element.Element(nameof(Movie.Name)),
                    Year = (short)element.Element(nameof(Movie.Year)),
                    Plot = (string)element.Element(nameof(Movie.Plot)),
                    ImdbRating = (double?)element.Element(nameof(Movie.ImdbRating)),
                    IsShowing = (bool)element.Element(nameof(Movie.IsShowing)),
                    TicketPrice = (decimal?)element.Element(nameof(Movie.TicketPrice)),
                    LastUpdated = (DateTime?)element.Element(nameof(Movie.LastUpdated))
                })
                ;
        }

        public IQueryable<Movie> GetAll(Expression<Func<Movie, bool>> filter)
            => GetAll()
            .Where(filter)
            ;
    }
}
