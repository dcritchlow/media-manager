using System;
using System.Collections.Generic;
using MediaManager.LibraryComponent.Entities;

namespace MediaManager.LibraryComponent.Repositories
{
  internal interface IMovieRepository
  {
    void AddMovie(Movie movie);
    void AddMovie(string title, string summary, DateTime releaseDate, string year, string poster, bool purchased, MovieMpaaRating rating, Format format, string imdbId, string userId);

    void AddMovieToWishList(string title, string summary, DateTime releaseDate, string year, string poster, MovieMpaaRating rating, Format format, string imdbId, string userId);
    Movie GetMovie(string title);
    Movie GetMovie(string title, string released);
    Movie GetMovieWithTitleAndYear(string title, string year);
    IEnumerable<Movie> GetAllMovies();
    IEnumerable<MovieWishList> GetAllWishListMovies();
    void UpdateMovieToPurchased(Movie movie);
    void SaveChanges();
  }
}