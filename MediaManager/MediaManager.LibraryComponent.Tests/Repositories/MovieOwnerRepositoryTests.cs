using System;
using System.Data.Entity;
using MediaManager.LibraryComponent.Entities;
using MediaManager.LibraryComponent.Repositories;
using Moq;
using NUnit.Framework;

namespace MediaManager.LibraryComponent.Tests.Repositories
{
  [TestFixture]
  public class MovieOwnerRepositoryTests
  {
    [Test, Description("Constructor_WHEN_MovieContext_isnull_THEN_throwsArgumentNullException")]
    public void Constructor_WHEN_MovieContext_isnull_THEN_throwsArgumentNullException()
    {
      Assert.That(() => new MovieOwnerRepository(null), Throws.TypeOf<ArgumentNullException>());
    }

    [Test, Description("AddMovieOwner_CallsSaveChanges")]
    public void AddMovieOwner_CallsSaveChanges()
    {
      var movieOwnerContext = new Mock<IMovieOwnerContext>();
      var mockSet = new Mock<DbSet<MovieOwner>>();
      movieOwnerContext.Setup(c => c.MovieOwnerSet).Returns(mockSet.Object);
      movieOwnerContext.Setup(c => c.SaveChanges()).Returns(1);
      var repo = new MovieOwnerRepository(movieOwnerContext.Object);
      repo.AddMovieOwner(1, 1, "testUser");
      movieOwnerContext.Verify(x => x.SaveChanges(), Times.Once);
    }
  }
}