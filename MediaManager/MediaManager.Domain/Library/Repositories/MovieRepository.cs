using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MediaManager.Domain.Library.Entities;
using MediaManager.Domain.Library.Interfaces;
using MediaManager.SharedKernel;

namespace MediaManager.Domain.Library.Repositories
{
  public class MovieRepository : IMovieRepository
  {
    private readonly IMovieContext _movieContext;

    public MovieRepository(IMovieContext movieContext)
    {
      _movieContext = movieContext ?? throw new ArgumentNullException(nameof(movieContext));
    }

    public void AddMovie(string title, string summary, DateTime releaseDate, bool purchased, MovieMpaaRating rating, Format format, string userId)
    {
      var movie = Movie.CreateMovie(title, summary, releaseDate, purchased, rating, format, userId);
      _movieContext.MovieSet.Add(movie);
      SaveChanges();
    }

    public IEnumerable<Movie> AllMovies()
    {
      var query = from m in _movieContext.MovieSet select m;
      return query.AsNoTracking().ToList();
    }

    public void SaveChanges()
    {
      _movieContext.SaveChanges();
    }
  }
}