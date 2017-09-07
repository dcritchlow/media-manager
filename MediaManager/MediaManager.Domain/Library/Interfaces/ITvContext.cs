using System.Data.Entity;
using MediaManager.Domain.Library.Entities;

namespace MediaManager.Domain.Library.Interfaces
{
  public interface ITvContext
  {
    DbSet<TvShow> TvShowSet { get; set; }
  }
}