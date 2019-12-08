using Cinema.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Domain
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService( IMovieRepository repository )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<MovieShowing> GetMoviesShowing()
        {
            var moviesShowing = _repository
                .GetAll()
                .Where(movie => movie.IsShowing)
                .Select( movie => movie.ToMovieShowing() )
                ;

            return moviesShowing;
        }
    }
}
