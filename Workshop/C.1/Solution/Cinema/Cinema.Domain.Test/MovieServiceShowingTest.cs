using Cinema.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Domain.Test
{
    [TestClass]
    public class MovieServiceShowingTest
    {
        [TestMethod]
        public void Test_MovieServiceReturnsOnlyIsShowing_Ok()
        {
            // Arrange
            IMovieRepository repository = new FakeMovieRepository(
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Name = "Fake Movie #1",
                    IsShowing = true,
                    Year = 2019,
                    Plot = "This should be returned from MovieService",
                    TicketPrice = 1m
                },
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Name = "Fake Movie #2",
                    IsShowing = false,
                    Year = 2019,
                    Plot = "This should not be returned from MovieService",
                    TicketPrice = 2m
                }
            );

            IMovieService movieService = new MovieService(
                repository,
                new ConstantTimeProvider( new DateTime( 2018, 12, 24) ),
                new NullUserContext()
            );

            // Act
            IEnumerable<MovieShowing> movies = movieService.GetMoviesShowing();

            // Assert
            Assert.AreEqual(1, movies.Count());
            Assert.AreEqual("Fake Movie #1", movies.Single().Name );
        }
    }
}
