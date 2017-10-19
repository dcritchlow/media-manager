using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MediaManager.LibraryComponent.Entities;
using MediaManager.LibraryComponent.Repositories;
using Moq;
using NUnit.Framework;

namespace MediaManager.LibraryComponent.Tests.Repositories
{
  [TestFixture]
  public class MovieRepositoryTests
  {
    [Test, Description("Constructor_WHEN_movierepository_isnull_THEN_throwsArgumentNullException")]
    public void Constructor_WHEN_movierepository_isnull_THEN_throwsArgumentNullException()
    {
      Assert.That(() => new MovieRepository(null, new Mock<IMovieWishListContext>().Object), Throws.TypeOf<ArgumentNullException>());
    }

    [Test, Description("AddMovie_CallsSaveChanges")]
    public void AddMovie_CallsSaveChanges()
    {
      var movieContext = new Mock<IMovieContext>();
      var movieWishListContext = new Mock<IMovieWishListContext>();
      var mockSet = new Mock<DbSet<Movie>>();
      movieContext.Setup(c => c.MovieSet).Returns(mockSet.Object);
      movieContext.Setup(c => c.SaveChanges()).Returns(1);
      var repo = new MovieRepository(movieContext.Object, movieWishListContext.Object);
      repo.AddMovie(string.Empty, string.Empty, new DateTime(), string.Empty, string.Empty, true, MovieMpaaRating.G, Format.BluRay, "imdbId", string.Empty);
      movieContext.Verify(x => x.SaveChanges(), Times.Once);
    }

    [Test, Description("AddMovie_CallsSaveChanges")]
    public void AddMovieToWishList_CallsSaveChanges()
    {
      var movieContext = new Mock<IMovieContext>();
      var movieWishListContext = new Mock<IMovieWishListContext>();
      var movieMockSet = new Mock<DbSet<Movie>>();
      movieContext.Setup(c => c.MovieSet).Returns(movieMockSet.Object);
      movieContext.Setup(c => c.SaveChanges()).Returns(1);
      var mockWishListSet = new Mock<DbSet<MovieWishList>>();
      movieWishListContext.Setup(c => c.MovieWishListSet).Returns(mockWishListSet.Object);
      movieWishListContext.Setup(c => c.SaveChanges()).Returns(1);
      var repo = new MovieRepository(movieContext.Object, movieWishListContext.Object);
      repo.AddMovieToWishList("FakeMovie", "FakeSummary", DateTime.Now, "year", "Fake Poster URL",MovieMpaaRating.G, Format.Dvd, "imdbId", "testUser");
      movieContext.Verify(x => x.SaveChanges(), Times.Exactly(2));
    }

    [Test, Description("WHEN_CallToRepoForAllMovies_THEN_ReturnsListOfMovies")]
    public void WHEN_CallToRepoForAllMovies_THEN_ReturnsListOfMovies()
    {
      var movieList = new List<Movie>
      {
        Movie.CreateMovie("Title", "Summary", null, "year", "Poster URL", true, MovieMpaaRating.G, Format.BluRay,"imdbId", "testUser"),
        Movie.CreateMovie("AnotherTitle", "Another Summary", null, "year", "Another Poster URL", true, MovieMpaaRating.PG, Format.Dvd,"imdbId", "testUser")
      };
      var mockSet = new Mock<DbSet<Movie>>();
      SetupDbSet(mockSet, movieList.AsQueryable());
      var movieContext = new Mock<IMovieContext>();
      movieContext.Setup(m => m.MovieSet).Returns(mockSet.Object);
      var movieWishListContext = new Mock<IMovieWishListContext>();

      var repository = new MovieRepository(movieContext.Object, movieWishListContext.Object);
      var movies = repository.GetAllMovies();
      Assert.That(movies.Any());
    }

    private static void SetupDbSet<TEntity>(Mock<DbSet<TEntity>> mockSet, IQueryable<TEntity> querySet) where TEntity : class
    {
      mockSet.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(querySet.Provider);
      mockSet.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(querySet.Expression);
      mockSet.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(querySet.ElementType);
      mockSet.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(querySet.GetEnumerator());
    }
  }
}