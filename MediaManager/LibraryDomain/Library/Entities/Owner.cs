using System.Collections.Generic;
using MediaManager.SharedKernel;

namespace MediaManager.Domain.Library.Entities
{
  public class Owner
  {
    public int OwnerId { get; set; }
    public string OwnerName { get; set; }
    public AuditInfo AuditInfo { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }
    public virtual ICollection<TvShow> TvShows { get; set; }
  }
}