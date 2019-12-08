using Cinema.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Domain
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly ITimeProvider _timeProvider;

        public MovieService(IMovieRepository repository, ITimeProvider timeProvider)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
        }

        public IEnumerable<MovieShowing> GetMoviesShowing()
        {
            var moviesShowing = _repository
                .GetAll()
                .Where(movie => movie.IsShowing)
                .Select(movie => movie.ToMovieShowing())
                .Select(movie => movie.ApplySpecialDayDiscounts(_timeProvider))
                ;

            return moviesShowing;
        }
    }
}
