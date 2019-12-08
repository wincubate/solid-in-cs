using Cinema.DataAccess.Sql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Domain
{
    public class MovieService
    {
        private readonly MovieContext _context;

        public MovieService()
        {
            _context = new MovieContext();
        }

        public IEnumerable<Movie> GetMoviesShowing()
        {
            var moviesShowing = _context.Movies
                    .Where(movie => movie.IsShowing)
                    ;

            return moviesShowing;
        }
    }
}
