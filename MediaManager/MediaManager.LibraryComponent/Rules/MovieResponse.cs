using System;
using MediaManager.SharedKernel;

namespace MediaManager.LibraryComponent.Rules
{
  internal class MovieResponse : IMovieResponseRule
  {
    private readonly ILog _log;

    public MovieResponse(ILog log)
    {
      _log = log ?? throw new ArgumentNullException(nameof(log));
    }
    public void Validate(MovieInformationDto movieInformation)
    {
      if (movieInformation.Response == "False" || !string.IsNullOrEmpty(movieInformation.Error))
      {
        _log.Info($"Title: {movieInformation.OriginalTitle}");
        _log.Error($"Movie was not found and/or errors were encountered. Response: {movieInformation.Response} Error: {movieInformation.Error}");
        movieInformation.Valid = false;
      }
      else
      {
        movieInformation.Valid = true;
      }
    }
  }
}