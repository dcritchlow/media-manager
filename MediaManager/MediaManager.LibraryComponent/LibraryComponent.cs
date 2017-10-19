using System;
using System.Collections.Generic;
using System.Linq;
using MediaManager.LibraryComponent.Entities;
using MediaManager.LibraryComponent.Evaluators;
using MediaManager.LibraryComponent.Repositories;
using MediaManager.SharedKernel;
using Microsoft.Practices.Unity;

namespace MediaManager.LibraryComponent
{
  public class LibraryComponent : ILibraryComponent
  {
    private readonly IOwnerRepository _ownerRepository;
    private readonly IMovieRepository _movieRepository;
    private readonly IMovieOwnerRepository _movieOwnerRepository;
    private readonly IEvaluator _evaluator;
    private readonly ILog _log;

    public LibraryComponent(IUnityContainer container)
    {
      if (container == null) throw new ArgumentNullException(nameof(container));
      RegisterComponents(container);
      _movieRepository = container.Resolve<IMovieRepository>();
      _ownerRepository = container.Resolve<IOwnerRepository>();
      _movieOwnerRepository = container.Resolve<IMovieOwnerRepository>();
      _evaluator = container.Resolve<IEvaluator>();
      _log = container.Resolve<ILog>();
    }

    private void AddMovie(MovieInformationDto movieInformation)
    {
      var rating = (MovieMpaaRating)Enum.Parse(typeof(MovieMpaaRating), movieInformation.Rated);
      DateTime.TryParse(movieInformation.Released, out DateTime released);
      var newMovie = Movie.CreateMovie(movieInformation.Title, movieInformation.Plot, released, movieInformation.Year, movieInformation.Poster, false, rating, movieInformation.Format, movieInformation.imdbID, Environment.UserName);
      _movieRepository.AddMovie(newMovie);
    }

    public void AddMovies(List<MovieInformationDto> movieInformations)
    {
      Evaluate(movieInformations);
      var validMovies = movieInformations.Where(m => m.Valid).ToList();
      var movies = _movieRepository.GetAllMovies().ToList();
      foreach (var movie in validMovies)
      {
        if (!movies.Any(m => m.MovieTitle.Equals(movie.Title)))
        {
          AddMovie(movie);
        }
      }
      _movieRepository.SaveChanges();
    }

    private void AddMovieOwner(MovieOwnerDto movieOwnerDto, Movie movie, Option<Owner> owner, Option<MovieOwner> movieOwner)
    {
      if (string.IsNullOrEmpty(movieOwnerDto.OwnerName)) throw new ArgumentException("Value cannot be null or empty.", nameof(movieOwnerDto.OwnerName));
      if (string.IsNullOrEmpty(movieOwnerDto.MovieTitle)) throw new ArgumentException("Value cannot be null or empty.", nameof(movieOwnerDto.MovieTitle));

      if (!owner.Any())
      {
        owner = Option<Owner>.Some(GetOwner(movieOwnerDto.OwnerName));
      }
      if (!movieOwner.Any())
      {
        movieOwner = Option<MovieOwner>.Some(_movieOwnerRepository.GetMovieOwner(owner.First().OwnerId, movie.MovieId));
      }
      if (movieOwner.First().MovieOwnerId == 0)
      {
        _movieOwnerRepository.AddMovieOwner(movieOwner.First(), Environment.UserName);
      }
      if (!movie.Purchased)
      {
        _movieRepository.UpdateMovieToPurchased(movie);
      }
    }

    private void AddMovieOwnerIntendingToBuy(MovieOwnerDto movieOwnerDto, Movie movie, Option<Owner> owner, Option<MovieOwner> movieOwner)
    {
      if (string.IsNullOrEmpty(movieOwnerDto.MovieTitle)) throw new ArgumentException("Value cannot be null or empty.", nameof(movieOwnerDto.MovieTitle));
      if (string.IsNullOrEmpty(movieOwnerDto.IntendingToBuy)) throw new ArgumentException("Value cannot be null or empty.", nameof(movieOwnerDto.IntendingToBuy));

      if (!owner.Any())
      {
        owner = Option<Owner>.Some(GetOwner(movieOwnerDto.IntendingToBuy));
      }
      if (movieOwner.Any())
      {
        _log.Error($"Found a Movie Owner already for {movie.MovieTitle}. Did not add owner Intending to buy {movieOwnerDto.IntendingToBuy} someone already owns it.");
        return;
      }
      movieOwner = Option<MovieOwner>.Some(_movieOwnerRepository.GetMovieOwner(owner.First().OwnerId, movie.MovieId));
      if (movieOwner.First().MovieOwnerId == 0)
      {
        _movieOwnerRepository.AddMovieOwner(movieOwner.First(), Environment.UserName);
      }
    }

    public void AddMovieOwners(List<MovieOwnerDto> movieOwnerDtos)
    {
      var movies = _movieRepository.GetAllMovies().ToList();
      var owners = _ownerRepository.GetAllOwners().ToList();
      var movieOwners = _movieOwnerRepository.GetAllMovieOwners().ToList();
      foreach (var movieOwnerDto in movieOwnerDtos)
      {
        var movie = FindMovie(movies, movieOwnerDto);
        if (movie.Any())
        {
          var owner = FindOwner(owners, movieOwnerDto.OwnerName);
          var movieOwner = FindMovieOwner(movieOwners, movie.First().MovieId, owner);
          AddMovieOwner(movieOwnerDto, movie.First(), owner, movieOwner);
        }
        else
        {
          _log.Error($"Did not find a movie with title {movieOwnerDto.MovieTitle} {(!string.IsNullOrEmpty(movieOwnerDto.Year) ? "and year " + movieOwnerDto.Year : string.Empty)}. Did not add owner {movieOwnerDto.OwnerName}");
        }
      }
      _movieRepository.SaveChanges();
      _movieOwnerRepository.SaveChanges();
    }

    public void AddMovieOwnersIntendingToBuy(List<MovieOwnerDto> movieOwnersDtos)
    {
      
      var movies = _movieRepository.GetAllMovies().ToList();
      var owners = _ownerRepository.GetAllOwners().ToList();
      var movieOwners = _movieOwnerRepository.GetAllMovieOwners().ToList();

      foreach (var movieOwnerDto in movieOwnersDtos)
      {
        var movie = FindMovie(movies, movieOwnerDto);
        if (movie.Any())
        {
          var owner = FindOwner(owners, movieOwnerDto.IntendingToBuy);
          var movieOwner = FindMovieOwner(movieOwners, movie.First().MovieId, owner);
          AddMovieOwnerIntendingToBuy(movieOwnerDto, movie.First(), owner, movieOwner);
        }
        else
        {
          _log.Error($"Did not find a movie with title {movieOwnerDto.MovieTitle} {(!string.IsNullOrEmpty(movieOwnerDto.Year) ? "and year " + movieOwnerDto.Year : string.Empty)}. Did not add owner intending to buy {movieOwnerDto.OwnerName}");
        }
      }
      _movieRepository.SaveChanges();
      _movieOwnerRepository.SaveChanges();
    }

    private Option<Movie> FindMovie(IEnumerable<Movie> movies, MovieOwnerDto movieOwnerDto)
    {
      Movie movieFound = null;
      try
      {
        movieFound = !string.IsNullOrEmpty(movieOwnerDto.Year)
          ? movies.SingleOrDefault(
            m => m.MovieTitle.Equals(movieOwnerDto.MovieTitle, StringComparison.InvariantCultureIgnoreCase) && string.Compare(m.Year,
                   movieOwnerDto.Year, StringComparison.InvariantCulture) == 0)
          : movies.SingleOrDefault(m => m.MovieTitle.Equals(movieOwnerDto.MovieTitle, StringComparison.InvariantCultureIgnoreCase));
      }
      catch (InvalidOperationException ex)
      {
        _log.Error($"More than one movie with the same title found. {ex.Message}");
      }
      return movieFound == null ? Option<Movie>.None() : Option<Movie>.Some(movieFound);
    }

    private static Option<Owner> FindOwner(IEnumerable<Owner> owners, string ownerName)
    {
      var ownerFound = owners.SingleOrDefault(o => o.OwnerName.Equals(ownerName, StringComparison.InvariantCultureIgnoreCase));
      return ownerFound == null ? Option<Owner>.None() : Option<Owner>.Some(ownerFound);
    }

    private static Option<MovieOwner> FindMovieOwner(IEnumerable<MovieOwner> movieOwners, int movieId, Option<Owner> owner)
    {
      if(!owner.Any()) return Option<MovieOwner>.None();
      var movieOwnerFound = movieOwners.SingleOrDefault(mo => mo.OwnerId == owner.First().OwnerId && mo.MovieId == movieId);
      return movieOwnerFound == null ? Option<MovieOwner>.None() : Option<MovieOwner>.Some(movieOwnerFound);
    }

    private Owner GetOwner(string ownerName)
    {
      var owner = _ownerRepository.GetOwner(ownerName);
      if (owner.OwnerId != 0) return owner;
      _ownerRepository.AddOwner(owner);
      _ownerRepository.SaveChanges();
      return owner;
    }

    private void RegisterComponents(IUnityContainer container)
    {
      if (container == null) throw new ArgumentNullException(nameof(container));
      ComponentRegistration.Register(container);
    }

    private void Evaluate(List<MovieInformationDto> movieInformations)
    {
      _evaluator.Evaluate(movieInformations);
    }
  }
}