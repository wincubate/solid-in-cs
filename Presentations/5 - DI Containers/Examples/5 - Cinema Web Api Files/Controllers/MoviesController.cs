using Cinema.Domain.Interfaces;
using Cinema.PresentationLogic;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Cinema.UI.WebApi.Controllers
{
    public class MoviesController : ApiController
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET api/movies     
        public IEnumerable<string> Get()
        {
            IEnumerable<MovieShowing> movies = _movieService.GetMoviesShowing();
            MainViewModel vm = new MainViewModel(movies);

            return vm.Movies.Select(movieVm => movieVm.DisplayText);
        }
    }
}
