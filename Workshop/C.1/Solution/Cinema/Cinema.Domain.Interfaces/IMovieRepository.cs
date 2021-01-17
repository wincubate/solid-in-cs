using System.Collections.Generic;

namespace Cinema.Domain.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        IEnumerable<Movie> GetAllShowing();
    }
}
