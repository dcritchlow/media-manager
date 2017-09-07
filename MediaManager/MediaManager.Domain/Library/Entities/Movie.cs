using System;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;
using MediaManager.SharedKernel;

namespace MediaManager.Domain.Library.Entities
{
  public class Movie
  {
    [ExcludeFromCodeCoverage]
    public int MovieId { get; private set; }
    public string MovieTitle { get; private set; }
    public string MovieSummary { get; private set; }
    public DateTime? ReleaseDate { get; private set; }
    public bool Purchased { get; private set; }
    public int MpaaRatingId { get; private set; }
    public int FormatId { get; private set; }
    public AuditInfo AuditInfo { get; private set; }

    [ExcludeFromCodeCoverage]
    private Movie() { }

    private Movie(string title, string summary, DateTime? releaseDate, bool purchased, MovieMpaaRating rating, Format format, string userId)
    {
      MovieTitle = title;
      MovieSummary = summary;
      ReleaseDate = releaseDate;
      Purchased = purchased;
      MpaaRatingId = (int) rating;
      FormatId = (int) format;
      AuditInfo = AuditInfo.CreateNew(userId);
    }

    public static Movie CreateMovie(string title, string summary, DateTime? releaseDate, bool purchased, MovieMpaaRating rating, Format format, string userId)
    {
      return new Movie(title, summary, releaseDate, purchased, rating, format, userId);
    }

    public void UpdateMovieTitle(string title, string userId)
    {
      MovieTitle = title;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    public void UpdateMovieSummary(string summary, string userId)
    {
      MovieSummary = summary;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    public void UpdateMovieReleaseDate(DateTime releaseDate, string userId)
    {
      ReleaseDate = releaseDate;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    public void UpdateMoviePurchased(bool purchased, string userId)
    {
      Purchased = purchased;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    public void UpdateMovieMpaaRating(MovieMpaaRating mpaaRating, string userId)
    {
      MpaaRatingId = (int) mpaaRating;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    public void UpdateMovieFormat(Format format, string userId)
    {
      FormatId = (int) format;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    [ExcludeFromCodeCoverage]
    internal class Configuration : EntityTypeConfiguration<Movie>
    {
      public Configuration()
      {
        ToTable("Movie", "MediaManager");
        HasKey(x => x.MovieId);
      }
    }
  }
}