using System;
using MediaManager.LibraryComponent.Entities;

namespace MediaManager.LibraryComponent.Repositories
{
  internal class TvOwnerRepository : ITvOwnerRepository
  {
    private readonly ITvOwnerContext _context;

    public TvOwnerRepository(ITvOwnerContext context)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void AddTvOwner(int tvShowId, int ownerId, string userId)
    {
      var tvOwner = TvOwner.AddTvOwner(tvShowId, ownerId, userId);
      _context.TvOwnerSet.Add(tvOwner);
      SaveChanges();
    }

    public void SaveChanges()
    {
      _context.SaveChanges();
    }
  }
}