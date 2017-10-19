using System.Data.Entity;
using MediaManager.LibraryComponent.Entities;

namespace MediaManager.LibraryComponent.Repositories
{
  internal interface IMovieWishListContext
  {
    DbSet<MovieWishList> MovieWishListSet { get; set; }
    int SaveChanges();
  }
}