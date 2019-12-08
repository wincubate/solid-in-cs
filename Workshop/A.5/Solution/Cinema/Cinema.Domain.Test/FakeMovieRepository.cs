using Cinema.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cinema.Domain.Test
{
    internal class FakeMovieRepository : IMovieRepository
    {
        private readonly IQueryable<Movie> _movies;

        public FakeMovieRepository( IEnumerable<Movie> movies )
        {
            _movies = movies.AsQueryable();
        }

        public FakeMovieRepository( params Movie[] movies) : this( movies.AsEnumerable() )
        {
        }

        public IQueryable<Movie> GetAll() => _movies;

        public IQueryable<Movie> GetAll(Expression<Func<Movie, bool>> filter) =>
            _movies.Where(filter);
    }
}
