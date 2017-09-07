using System;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;
using MediaManager.SharedKernel;

namespace MediaManager.Domain.Library.Entities
{
  public class TvShow
  {
    [ExcludeFromCodeCoverage]
    public int TvShowId { get; private set; }
    public string TvShowTitle { get; private set; }
    public string TvShowSummary { get; private set; }
    public DateTime? ReleaseDate { get;private set; }
    public DateTime? EndDate { get; private set; }
    public int NumberOfSeasons { get; private set; }
    public bool Purchased { get; private set; }
    public int TvRatingId { get; private set; }
    public int FormatId { get; private set; }
    public AuditInfo AuditInfo { get; private set; }

    [ExcludeFromCodeCoverage]
    private TvShow() { }

    private TvShow(
      string title,
      string summary,
      DateTime? releaseDate,
      DateTime? endDate,
      int numberOfSeasons,
      bool purchased,
      TvRating rating,
      Format format,
      string userId)
    {
      TvShowTitle = title;
      TvShowSummary = summary;
      ReleaseDate = releaseDate;
      EndDate = endDate;
      NumberOfSeasons = numberOfSeasons;
      Purchased = purchased;
      TvRatingId = (int) rating;
      FormatId = (int) format;
      AuditInfo = AuditInfo.CreateNew(userId);
    }

    public static TvShow CreateTvShow(
      string title, 
      string summary, 
      DateTime? releaseDate, 
      DateTime? endDate,
      int numberOfSeasons, 
      bool purchased, 
      TvRating rating, 
      Format format, 
      string userId
      ) => new TvShow(title, summary, releaseDate, endDate, numberOfSeasons, purchased, rating, format, userId);

    public void UpdateTvShowTitle(string title, string userId)
    {
      TvShowTitle = title;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    public void UpdateTvShowSummary(string summary, string userId)
    {
      TvShowSummary = summary;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    public void UpdateTvShowReleaseDate(DateTime? releaseDate, string userId)
    {
      ReleaseDate = releaseDate;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    public void UpdateTvShowEndDate(DateTime? endDate, string userId)
    {
      EndDate = endDate;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    public void UpdateTvShowNumberOfSeasons(int numberOfSeasons, string userId)
    {
      NumberOfSeasons = numberOfSeasons;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    public void UpdateTvShowPurchased(bool purchased, string userId)
    {
      Purchased = purchased;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    public void UpdateTvShowRating(TvRating rating, string userId)
    {
      TvRatingId = (int) rating;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    public void UpdateTvShowFormat(Format format, string userId)
    {
      FormatId = (int) format;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    [ExcludeFromCodeCoverage]
    internal class Configuration : EntityTypeConfiguration<TvShow>
    {
      public Configuration()
      {
        ToTable("TvShow", "MediaManager");
        HasKey(x => x.TvShowId);
      }
    }
  }
}