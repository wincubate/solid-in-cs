using Cinema.Domain.Interfaces;
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Cinema.DataAccess.Sql
{
    public class SqlMovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;

        public SqlMovieRepository(MovieContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            Debug.WriteLine($"{nameof(SqlMovieRepository)} created");
        }

        public IQueryable<Movie> GetAll() => _context.Movies;

        public IQueryable<Movie> GetAll(Expression<Func<Movie, bool>> filter) => _context.Movies
            .Where(filter);
    }
}
