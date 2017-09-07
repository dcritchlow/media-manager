using System;
using MediaManager.Domain.Library.Entities;
using NUnit.Framework;

namespace MediaManager.Domain.Tests.Library.Entities
{
  [TestFixture]
  public class MovieTests
  {
    private readonly Movie _movie = Movie.CreateMovie("Test Title", "Awesome summary", DateTime.Today, true, MovieMpaaRating.G, Format.Dvd, "testUser");

    [Test]
    public void CreatingMovie_ReturnsMovieObject()
    {
      Assert.IsInstanceOf<Movie>(_movie);
      Assert.That(_movie.MovieTitle == "Test Title");
      Assert.That(_movie.MovieSummary == "Awesome summary");
      Assert.That(_movie.ReleaseDate == DateTime.Today);
      Assert.That(_movie.Purchased);
      Assert.That(_movie.MpaaRatingId == (int) MovieMpaaRating.G);
      Assert.That(_movie.FormatId == (int) Format.Dvd);
      Assert.That(_movie.AuditInfo.CreatedBy == "testUser");
    }

    [Test]
    public void UpdateMovieTitle_ReturnsCorrectMovieObject()
    {
      _movie.UpdateMovieTitle("Updated Test Title", "testUser2");
      Assert.That(_movie.MovieTitle == "Updated Test Title");
      Assert.That(_movie.AuditInfo.ModifiedBy == "testUser2");
      Assert.That(_movie.AuditInfo.ModifiedAt?.Day == DateTime.Today.Day);
    }

    [Test]
    public void UpdateMovieSummary_ReturnsCorrectMovieObject()
    {
      _movie.UpdateMovieSummary("Awesome summary updated", "testUser2");
      Assert.That(_movie.MovieSummary == "Awesome summary updated");
      Assert.That(_movie.AuditInfo.ModifiedBy == "testUser2");
      Assert.That(_movie.AuditInfo.ModifiedAt?.Day == DateTime.Today.Day);
    }

    [Test]
    public void UpdateMovieReleaseDate_ReturnsCorrectMovieObject()
    {
      var lastYear = DateTime.Today.AddYears(-1);
      _movie.UpdateMovieReleaseDate(lastYear , "testUser2");
      Assert.That(_movie.ReleaseDate == lastYear);
      Assert.That(_movie.AuditInfo.ModifiedBy == "testUser2");
      Assert.That(_movie.AuditInfo.ModifiedAt?.Day == DateTime.Today.Day);
    }

    [Test]
    public void UpdateMoviePurchase_ReturnsCorrectMovieObject()
    {
      _movie.UpdateMoviePurchased(false, "testUser2");
      Assert.That(!_movie.Purchased);
      Assert.That(_movie.AuditInfo.ModifiedBy == "testUser2");
      Assert.That(_movie.AuditInfo.ModifiedAt?.Day == DateTime.Today.Day);
    }

    [Test]
    public void UpdateMovieMpaaRating_ReturnsCorrectMovieObject()
    {
      _movie.UpdateMovieMpaaRating(MovieMpaaRating.Pg, "testUser2");
      Assert.That(_movie.MpaaRatingId == (int) MovieMpaaRating.Pg);
      Assert.That(_movie.AuditInfo.ModifiedBy == "testUser2");
      Assert.That(_movie.AuditInfo.ModifiedAt?.Day == DateTime.Today.Day);
    }

    [Test]
    public void UpdateMovieFormat_ReturnsCorrectMovieObject()
    {
      _movie.UpdateMovieFormat(Format.BluRay, "testUser2");
      Assert.That(_movie.FormatId == (int) Format.BluRay);
      Assert.That(_movie.AuditInfo.ModifiedBy == "testUser2");
      Assert.That(_movie.AuditInfo.ModifiedAt?.Day == DateTime.Today.Day);
    }
  }
}