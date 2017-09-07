using MediaManager.Domain.Library.Entities;

namespace MediaManager.Domain.Library.Interfaces
{
  public interface IMovieOwnerRepository
  {
    void AddMovieOwner(int movieId, int ownerId, string userId);
  }
}