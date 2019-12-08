using Cinema.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.PresentationLogic
{
    public class MainViewModel
    {
        public IEnumerable<MovieViewModel> Movies { get; }

        public MainViewModel(IEnumerable<MovieShowing> movies)
        {
            Movies = movies
                .Select(movie => new MovieViewModel(movie))
                ;
        }
    }
}
