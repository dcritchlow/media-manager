using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MediaManager.Domain.Library.Data;
using MediaManager.Domain.Library.Entities;
using MediaManager.Domain.Library.Interfaces;
using MediaManager.Domain.Library.Repositories;
using Moq;
using NUnit.Framework;

namespace MediaManager.Domain.Tests.Library.Repositories
{
  [TestFixture]
  public class MovieRepositoryTests
  {
    [Test, Description("Constructor_WHEN_movierepository_isnull_THEN_throwsArgumentNullException")]
    public void Constructor_WHEN_movierepository_isnull_THEN_throwsArgumentNullException()
    {
      Assert.That(() => new MovieRepository(null), Throws.TypeOf<ArgumentNullException>());
    }

    [Test, Description("AddMovie_CallsSaveChanges")]
    public void AddMovie_CallsSaveChanges()
    {
      var context = new Mock<IMovieContext>();
      var mockSet = new Mock<DbSet<Movie>>();
      context.Setup(c => c.MovieSet).Returns(mockSet.Object);
      context.Setup(c => c.SaveChanges()).Returns(1);
      var repo = new MovieRepository(context.Object);
      repo.AddMovie(string.Empty, string.Empty, new DateTime(), true, MovieMpaaRating.G, Format.BluRay, string.Empty);
      context.Verify(x => x.SaveChanges(), Times.Once);
    }

    [Test, Description("WHEN_CallToRepoForAllMovies_THEN_ReturnsListOfMovies")]
    public void WHEN_CallToRepoForAllMovies_THEN_ReturnsListOfMovies()
    {
      var movieList = new List<Movie>
      {
        Movie.CreateMovie("Title", "Summary", null, true, MovieMpaaRating.G, Format.BluRay, "testUser"),
        Movie.CreateMovie("AnotherTitle", "Another Summary", null, true, MovieMpaaRating.Pg, Format.Dvd, "testUser")
      }.AsQueryable();
      var mockSet = new Mock<DbSet<Movie>>();
      mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(movieList.Provider);
      mockSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(movieList.Expression);
      mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(movieList.ElementType);
      mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns<Movie>(_ => movieList.GetEnumerator());
      var context = new Mock<IMovieContext>();
      context.Setup(m => m.MovieSet).Returns(mockSet.Object);
      
      var repository = new MovieRepository(context.Object);
      var movies = repository.AllMovies();
      Assert.That(movies.Any());
    }
  }
}