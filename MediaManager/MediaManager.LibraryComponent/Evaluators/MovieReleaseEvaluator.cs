using System;
using System.Collections.Generic;
using MediaManager.LibraryComponent.Rules;

namespace MediaManager.LibraryComponent.Evaluators
{
  internal class MovieReleaseEvaluator : IEvaluator
  {
    private Func<List<MovieInformationDto>, List<IMovieReleaseRule>> GenerateOrderedMovieReleaseRules { get; } = movieInformationDto => new List<IMovieReleaseRule>
    {
      new NotApplicableReleaseDate()
    };

    public void Evaluate(List<MovieInformationDto> movieInformations)
    {
      var movieReleaseRules = GenerateOrderedMovieReleaseRules(movieInformations);
      foreach(var movieInformation in movieInformations)
      {
        if(!movieInformation.Valid) continue;
        foreach(var rule in movieReleaseRules)
        {
          rule.Validate(movieInformation);
        }
      }
    }
  }
}