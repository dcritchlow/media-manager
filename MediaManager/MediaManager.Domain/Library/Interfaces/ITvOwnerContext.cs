using System.Data.Entity;
using MediaManager.Domain.Library.Entities;

namespace MediaManager.Domain.Library.Interfaces
{
  public interface ITvOwnerContext
  {
    DbSet<TvOwner> TvOwnerSet { get; set; }
    int SaveChanges();
  }
}