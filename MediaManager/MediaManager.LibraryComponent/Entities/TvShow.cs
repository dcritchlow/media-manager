using System;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;
using MediaManager.SharedKernel;

namespace MediaManager.LibraryComponent.Entities
{
  internal class TvShow
  {
    [ExcludeFromCodeCoverage]
    internal int TvShowId { get; private set; }
    internal string TvShowTitle { get; private set; }
    internal string TvShowSummary { get; private set; }
    internal DateTime? ReleaseDate { get;private set; }
    internal DateTime? EndDate { get; private set; }
    internal int NumberOfSeasons { get; private set; }
    internal bool Purchased { get; private set; }
    internal int TvRatingId { get; private set; }
    internal int FormatId { get; private set; }
    internal AuditInfo AuditInfo { get; private set; }

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

    internal static TvShow CreateTvShow(
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

    internal void UpdateTvShowTitle(string title, string userId)
    {
      TvShowTitle = title;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    internal void UpdateTvShowSummary(string summary, string userId)
    {
      TvShowSummary = summary;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    internal void UpdateTvShowReleaseDate(DateTime? releaseDate, string userId)
    {
      ReleaseDate = releaseDate;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    internal void UpdateTvShowEndDate(DateTime? endDate, string userId)
    {
      EndDate = endDate;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    internal void UpdateTvShowNumberOfSeasons(int numberOfSeasons, string userId)
    {
      NumberOfSeasons = numberOfSeasons;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    internal void UpdateTvShowPurchased(bool purchased, string userId)
    {
      Purchased = purchased;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    internal void UpdateTvShowRating(TvRating rating, string userId)
    {
      TvRatingId = (int) rating;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    internal void UpdateTvShowFormat(Format format, string userId)
    {
      FormatId = (int) format;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    [ExcludeFromCodeCoverage]
    internal class Configuration : EntityTypeConfiguration<TvShow>
    {
      internal Configuration()
      {
        ToTable("TvShow", "MediaManager");
        HasKey(x => x.TvShowId);
      }
    }
  }
}