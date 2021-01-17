using Cinema.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cinema.Domain.Test
{
    internal class FakeMovieRepository : IMovieRepository
    {
        private readonly IEnumerable<Movie> _movies;

        public FakeMovieRepository(IEnumerable<Movie> movies)
        {
            _movies = movies.ToList();
        }

        public FakeMovieRepository(params Movie[] movies) : this(movies.AsEnumerable())
        {
        }

        public IEnumerable<Movie> GetAll() => _movies.ToList();

        public IEnumerable<Movie> GetAllShowing() =>
            _movies
                .Where(movie => movie.IsShowing)
                .ToList()
                ;
    }
}
