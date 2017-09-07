using System.Data.Entity;
using MediaManager.Domain.Library.Entities;

namespace MediaManager.Domain.Library.Interfaces
{
  public interface IMovieOwnerContext
  {
    DbSet<MovieOwner> MovieOwnerSet { get; set; }
    int SaveChanges();
  }
}