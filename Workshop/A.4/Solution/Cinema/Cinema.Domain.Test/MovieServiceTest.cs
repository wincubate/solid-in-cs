using Cinema.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Domain.Test
{
    [TestClass]
    public class MovieServiceTest
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
                new ConstantTimeProvider( new DateTime( 2018, 12, 24) )
            );

            // Act
            IEnumerable<MovieShowing> movies = movieService.GetMoviesShowing();

            // Assert
            Assert.AreEqual(1, movies.Count());
            Assert.AreEqual("Fake Movie #1", movies.Single().Name );
        }

        [TestMethod]
        public void Test_MovieServiceFridaysHaveHappyHourDiscount_Ok()
        {
            // Arrange
            IMovieRepository repository = new FakeMovieRepository(
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Name = "Friday the 13th - SOLID Edition (a.k.a. J(a)SON dies!)",
                    IsShowing = true,
                    Year = 2019,
                    Plot = "This move is Happy Hour-discounted",
                    TicketPrice = 100m
                }
            );

            DateTime someFriday = new DateTime(2019, 09, 13);
            IMovieService movieService = new MovieService(
                repository,
                new ConstantTimeProvider(someFriday)
            );

            // Act
            IEnumerable<MovieShowing> movies = movieService.GetMoviesShowing();

            // Assert
            decimal expectedPrice = 50m;
            Assert.AreEqual(expectedPrice, movies.Single().TicketPrice);
        }

        [TestMethod]
        public void Test_MovieServiceOtherDaysHaveNormalPricing_Ok()
        {
            // Arrange
            IMovieRepository repository = new FakeMovieRepository(
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Name = "Oh, Thursday)",
                    IsShowing = true,
                    Year = 2019,
                    Plot = "This move is normal-priced",
                    TicketPrice = 100m
                }
            );

            DateTime someThursday = new DateTime(2019, 09, 12);
            IMovieService movieService = new MovieService(
                repository,
                new ConstantTimeProvider(someThursday)
            );

            // Act
            IEnumerable<MovieShowing> movies = movieService.GetMoviesShowing();

            // Assert
            decimal expectedPrice = 100m;
            Assert.AreEqual(expectedPrice, movies.Single().TicketPrice);
        }
    }
}
