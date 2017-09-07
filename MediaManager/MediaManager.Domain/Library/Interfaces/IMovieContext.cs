using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MediaManager.Domain.Library.Entities;

namespace MediaManager.Domain.Library.Interfaces
{
  public interface IMovieContext
  {
    DbSet<Movie> MovieSet { get; set; }
    int SaveChanges();
    DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
  }
}