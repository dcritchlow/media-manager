using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MediaManager.LibraryComponent.Entities;

namespace MediaManager.LibraryComponent.Repositories
{
  internal class MovieOwnerRepository : IMovieOwnerRepository
  {
    private readonly IMovieOwnerContext _movieOwnerContext;

    public MovieOwnerRepository(IMovieOwnerContext movieOwnerContext)
    {
      _movieOwnerContext = movieOwnerContext ?? throw new ArgumentNullException(nameof(movieOwnerContext));
    }

    public void AddMovieOwner(int movieId, int ownerId, string userId)
    {
      var movieOwner = MovieOwner.AddMovieOwner(movieId, ownerId, userId);
      AddMovieOwner(movieOwner, userId);
    }

    public IEnumerable<MovieOwner> GetAllMovieOwners()
    {
      var query = from mo in _movieOwnerContext.MovieOwnerSet select mo;
      return query.AsNoTracking().ToList();
    }

    public void AddMovieOwner(MovieOwner movieOwner, string userId)
    {
      if (movieOwner == null) throw new ArgumentNullException(nameof(movieOwner));
      if (string.IsNullOrEmpty(userId)) throw new ArgumentException("Value cannot be null or empty.", nameof(userId));
      _movieOwnerContext.MovieOwnerSet.Add(movieOwner);
    }

    public MovieOwner GetMovieOwner(int ownerId, int movieId)
    {
      var movieOwner = _movieOwnerContext.MovieOwnerSet.FirstOrDefault(mo => mo.Movie.MovieId == movieId && mo.Owner.OwnerId == ownerId) 
        ?? MovieOwner.AddMovieOwner(movieId, ownerId, Environment.UserName);
      return movieOwner;
    }

    public void SaveChanges()
    {
      _movieOwnerContext.SaveChanges();
    }
  }
}