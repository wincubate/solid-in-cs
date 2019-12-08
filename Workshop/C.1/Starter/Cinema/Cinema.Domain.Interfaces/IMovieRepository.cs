using System;
using System.Linq;
using System.Linq.Expressions;

namespace Cinema.Domain.Interfaces
{
    public interface IMovieRepository
    {
        IQueryable<Movie> GetAll();
        IQueryable<Movie> GetAll(Expression<Func<Movie, bool>> filter);
    }
}
