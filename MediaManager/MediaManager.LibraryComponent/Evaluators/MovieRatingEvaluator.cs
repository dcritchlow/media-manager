using System;
using System.Collections.Generic;
using MediaManager.LibraryComponent.Rules;

namespace MediaManager.LibraryComponent.Evaluators
{
  internal class MovieRatingEvaluator : IEvaluator
  {
    private Func<List<MovieInformationDto>, List<IMovieRatingRule>> GenerateOrderedMovieRatingRules { get; } = movieInformationDto => new List<IMovieRatingRule>
    {
      new NotApplicableRating(),
      new NotRatedRating(),
      new UnRatedRating(),
      new ApprovedRating(),
      new NrRating(), 
      new PassedRating(),
      new TvYMovieRating(),
      new TvGRating(),
      new TvPgRating(),
      new Tv14Rating(),
      new TvMaMovieRating(),
      new HyphenRemoval()
    };

    public void Evaluate(List<MovieInformationDto> movieInformations)
    {
      var movieRatingRules = GenerateOrderedMovieRatingRules(movieInformations);
      foreach (var movieInformation in movieInformations)
      {
        if (!movieInformation.Valid) continue;
        foreach (var rule in movieRatingRules)
        {
          rule.Validate(movieInformation);
        }
      }
    }
  }
}