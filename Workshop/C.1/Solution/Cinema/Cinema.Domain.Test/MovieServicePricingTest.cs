using Cinema.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Domain.Test
{
    [TestClass]
    public class MovieServicePricingTest
    {
        private IMovieRepository _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            _repository = new FakeMovieRepository(
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
        }

        [DataRow(12, UserRole.Customer, 100)]
        [DataRow(13, UserRole.Customer, 50)]
        [DataRow(12, UserRole.ClubMember, 90)]
        [DataRow(13, UserRole.ClubMember, 45)]
        [DataTestMethod]
        public void Test_MovieServiceHaveCorrectHappyHourAndOrClubMemberDiscount_Ok(int day, UserRole role, int expectedPrice)
        {
            // Arrange
            ITimeProvider timeProvider = new ConstantTimeProvider(new DateTime(2019, 09, day));
            IUserContext userContext = new FakeUserContext(role);

            IMovieService movieService = new MovieService(
                _repository,
                timeProvider,
                userContext
            );

            // Act
            IEnumerable<MovieShowing> movies = movieService.GetMoviesShowing();

            // Assert
            Assert.AreEqual(expectedPrice, movies.Single().TicketPrice);
        }
    }
}
