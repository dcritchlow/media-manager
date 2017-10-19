using System.Collections.Generic;
using MediaManager.LibraryComponent.Entities;

namespace MediaManager.LibraryComponent.Repositories
{
  internal interface IMovieOwnerRepository
  {
    void AddMovieOwner(int movieId, int ownerId, string userId);
    MovieOwner GetMovieOwner(int ownerId, int movieId);
    IEnumerable<MovieOwner> GetAllMovieOwners();
    void AddMovieOwner(MovieOwner movieOwner, string userId);
    void SaveChanges();
  }
}