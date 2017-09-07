using System;
using MediaManager.Domain.Library.Entities;
using MediaManager.Domain.Library.Interfaces;

namespace MediaManager.Domain.Library.Repositories
{
  public class MovieOwnerRepository : IMovieOwnerRepository
  {
    private readonly IMovieOwnerContext _context;

    public MovieOwnerRepository(IMovieOwnerContext context)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void AddMovieOwner(int movieId, int ownerId, string userId)
    {
      var movieOwner = MovieOwner.AddMovieOwner(movieId, ownerId, userId);
      _context.MovieOwnerSet.Add(movieOwner);
      SaveChanges();
    }

    public void SaveChanges()
    {
      _context.SaveChanges();
    }
  }
}