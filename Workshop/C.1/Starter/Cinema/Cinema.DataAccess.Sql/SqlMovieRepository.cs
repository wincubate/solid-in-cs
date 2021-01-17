using Cinema.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.DataAccess.Sql
{
    public class SqlMovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;

        public SqlMovieRepository(MovieContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Movie> GetAll() => _context.Movies
            .ToList()
            ;

        public IEnumerable<Movie> GetAllShowing() => _context.Movies
            .Where(movie => movie.IsShowing)
            .ToList();
    }
}
