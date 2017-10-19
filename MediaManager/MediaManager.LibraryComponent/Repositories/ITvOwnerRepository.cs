namespace MediaManager.LibraryComponent.Repositories
{
  internal interface ITvOwnerRepository
  {
    void AddTvOwner(int tvShowId, int ownerId, string userId);
    void SaveChanges();
  }
}