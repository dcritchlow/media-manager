using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MediaManager.LibraryComponent.Entities;

namespace MediaManager.LibraryComponent.Repositories
{
  internal interface IMovieContext
  {
    DbSet<Movie> MovieSet { get; set; }
    int SaveChanges();
  }
}