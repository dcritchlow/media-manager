using System.Data.Entity;
using MediaManager.LibraryComponent.Entities;

namespace MediaManager.LibraryComponent.Repositories
{
  internal interface ITvOwnerContext
  {
    DbSet<TvOwner> TvOwnerSet { get; set; }
    int SaveChanges();
  }
}