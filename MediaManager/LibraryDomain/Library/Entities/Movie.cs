using System.Collections.Generic;
using MediaManager.SharedKernel;

namespace MediaManager.Domain.Library.Entities
{
  public class Movie
  {
    public int MovieId { get; set; }
    public string MovieTitle { get; set; }
    public string MovieSummary { get; set; }
    public bool Purchased { get; set; }
    public string MpaaRatingId { get; set; }
    public string FormatId { get; set; }
    public AuditInfo AuditInfo { get; set; }
    public virtual ICollection<MovieOwner> MovieOwners { get; set; }
  }
}