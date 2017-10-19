using System;
using System.Collections.Generic;
using MediaManager.LibraryComponent.Entities;
using System.Linq;
using System.Data.Entity;
using System.Globalization;

namespace MediaManager.LibraryComponent.Repositories
{
  internal class MovieRepository : IMovieRepository
  {
    private readonly IMovieContext _movieContext;
    private readonly IMovieWishListContext _movieWishListContext;

    public MovieRepository(IMovieContext movieContext, IMovieWishListContext movieWishListContext)
    {
      _movieContext = movieContext ?? throw new ArgumentNullException(nameof(movieContext));
      _movieWishListContext = movieWishListContext ?? throw new ArgumentNullException(nameof(movieWishListContext));
    }

    public void AddMovie(Movie movie)
    {
      _movieContext.MovieSet.Add(movie);
    }

    public void AddMovie(string title, string summary, DateTime releaseDate, string year, string poster, bool purchased, MovieMpaaRating rating, Format format, string imdbId, string userId)
    {
      var movie = Movie.CreateMovie(title, summary, releaseDate, year, poster, purchased, rating, format, imdbId, userId);
      _movieContext.MovieSet.Add(movie);
    }

    public Movie GetMovie(string title)
    {
      var movie = _movieContext.MovieSet.Where(m => m.MovieTitle == title).SingleOrDefault();
      return movie;
    }

    public Movie GetMovie(string title, string released)
    {
      DateTime.TryParse(released, out DateTime releasedDate);
      var movie = _movieContext.MovieSet.Where(m => m.MovieTitle.Contains(title) && DateTime.Compare(m.ReleaseDate.Value, releasedDate) == 0).SingleOrDefault();
      return movie;
    }

    public Movie GetMovieWithTitleAndYear(string title, string year)
    {
      DateTime.TryParseExact(year, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releasedDate);
      var movie = _movieContext.MovieSet.Where(m => m.MovieTitle.Contains(title) && m.ReleaseDate.Value.Year == releasedDate.Year).SingleOrDefault();
      return movie;
    }

    public void AddMovieToWishList(string title, string summary, DateTime releaseDate, string year, string poster, MovieMpaaRating rating, Format format, string imdbId, string userId)
    {
      var movie = Movie.CreateMovie(title, summary, releaseDate, year, poster, false, rating, format, imdbId, userId);
      _movieContext.MovieSet.Add(movie);
      SaveChanges();

      var movieWishList = MovieWishList.CreateMovieWishList(movie.MovieId, userId);
      _movieWishListContext.MovieWishListSet.Add(movieWishList);
      SaveChanges();
    }

    public IEnumerable<Movie> GetAllMovies()
    {
      var query = from m in _movieContext.MovieSet select m;
      return query.AsNoTracking().ToList();
    }

    public IEnumerable<MovieWishList> GetAllWishListMovies()
    {
      return _movieWishListContext.MovieWishListSet.Include(s => s.Movie).Where(m => !m.Movie.Purchased).AsNoTracking().ToList();
    }

    public void UpdateMovieToPurchased(Movie movie)
    {
      var dbMovie = _movieContext.MovieSet.Find(movie.MovieId);
      dbMovie?.UpdateMoviePurchased(true, Environment.UserName);
    }

    public void SaveChanges()
    {
      _movieContext.SaveChanges();
      _movieWishListContext.SaveChanges();
    }
  }
}