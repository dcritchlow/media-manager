using System;
using System.Data.Entity;
using MediaManager.Domain.Library.Entities;
using MediaManager.Domain.Library.Interfaces;
using MediaManager.Domain.Library.Repositories;
using Moq;
using NUnit.Framework;

namespace MediaManager.Domain.Tests.Library.Repositories
{
  [TestFixture]
  public class MovieOwnerRepositoryTests
  {
    [Test, Description("Constructor_WHEN_movieownerrepository_isnull_THEN_throwsArgumentNullException")]
    public void Constructor_WHEN_movieownerrepository_isnull_THEN_throwsArgumentNullException()
    {
      Assert.That(() => new MovieOwnerRepository(null), Throws.TypeOf<ArgumentNullException>());
    }

    [Test, Description("AddMovieOwner_CallsSaveChanges")]
    public void AddMovieOwner_CallsSaveChanges()
    {
      var context = new Mock<IMovieOwnerContext>();
      var mockSet = new Mock<DbSet<MovieOwner>>();
      context.Setup(c => c.MovieOwnerSet).Returns(mockSet.Object);
      context.Setup(c => c.SaveChanges()).Returns(1);
      var repo = new MovieOwnerRepository(context.Object);
      repo.AddMovieOwner(1, 1, "testUser");
      context.Verify(x => x.SaveChanges(), Times.Once);
    }
  }
}