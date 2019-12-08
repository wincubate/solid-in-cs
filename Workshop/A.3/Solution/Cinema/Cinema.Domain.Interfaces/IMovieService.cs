using System.Collections.Generic;

namespace Cinema.Domain.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<MovieShowing> GetMoviesShowing();
    }
}
