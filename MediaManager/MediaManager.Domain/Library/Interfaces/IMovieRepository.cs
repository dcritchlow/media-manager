using System;
using MediaManager.Domain.Library.Entities;

namespace MediaManager.Domain.Library.Interfaces
{
  public interface IMovieRepository
  {
    void AddMovie(string title, string summary, DateTime releaseDate, bool purchased, MovieMpaaRating rating, Format format, string userId);
  }
}