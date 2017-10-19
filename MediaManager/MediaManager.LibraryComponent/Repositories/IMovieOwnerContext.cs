using System.Data.Entity;
using MediaManager.LibraryComponent.Entities;

namespace MediaManager.LibraryComponent.Repositories
{
  internal interface IMovieOwnerContext
  {
    DbSet<MovieOwner> MovieOwnerSet { get; set; }
    int SaveChanges();
  }
}