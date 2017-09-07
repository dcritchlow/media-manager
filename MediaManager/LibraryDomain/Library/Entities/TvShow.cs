using System.Collections.Generic;

namespace MediaManager.Domain.Library.Entities
{
  public class TvShow
  {
    public int TvShowId { get; set; }
    public string TvShowTitle { get; set; }
    public string TvShowSummary { get; set; }
    public bool Purchased { get; set; }
    public string TvRatingId { get; set; }
    public string FormatId { get; set; }
    public AuditInfo AuditInfo { get; set; }
    public virtual ICollection<Owner> Owners { get; set; }
  }
}