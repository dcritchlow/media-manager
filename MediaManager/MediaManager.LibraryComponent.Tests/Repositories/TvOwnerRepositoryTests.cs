using System;
using System.Data.Entity;
using MediaManager.LibraryComponent.Entities;
using MediaManager.LibraryComponent.Repositories;
using Moq;
using NUnit.Framework;

namespace MediaManager.LibraryComponent.Tests.Repositories
{
  [TestFixture]
  public class TvOwnerRepositoryTests
  {
    [Test, Description("Constructor_WHEN_tvownerrepository_isnull_THEN_throwsArgumentNullException")]
    public void Constructor_WHEN_tvownerrepository_isnull_THEN_throwsArgumentNullException()
    {
      Assert.That(() => new TvOwnerRepository(null), Throws.TypeOf<ArgumentNullException>());
    }

    [Test, Description("AddTvOwner_CallsSaveChanges")]
    public void AddTvOwner_CallsSaveChanges()
    {
      var context = new Mock<ITvOwnerContext>();
      var mockSet = new Mock<DbSet<TvOwner>>();
      context.Setup(c => c.TvOwnerSet).Returns(mockSet.Object);
      context.Setup(c => c.SaveChanges()).Returns(1);
      var repo = new TvOwnerRepository(context.Object);
      repo.AddTvOwner(1, 1, "testUser");
      context.Verify(x => x.SaveChanges(), Times.Once);
    }
  }
}