namespace MediaManager.Domain.Library.Interfaces
{
  public interface ITvOwnerRepository
  {
    void AddTvOwner(int tvShowId, int ownerId, string userId);
  }
}