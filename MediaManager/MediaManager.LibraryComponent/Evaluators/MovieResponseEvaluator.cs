using System;
using System.Collections.Generic;
using MediaManager.LibraryComponent.Rules;
using MediaManager.SharedKernel;

namespace MediaManager.LibraryComponent.Evaluators
{
  internal class MovieResponseEvaluator : IEvaluator
  {
    internal MovieResponseEvaluator(ILog log)
    {
      if (log == null) throw new ArgumentNullException(nameof(log));

      GenerateOrderedMovieResponseRules = movieInformationDto => new List<IMovieResponseRule>
      {
        new MovieResponse(log)
      };
    }
    private Func<List<MovieInformationDto>, List<IMovieResponseRule>> GenerateOrderedMovieResponseRules { get; }

    public void Evaluate(List<MovieInformationDto> movieInformations)
    {
      var movieResponseRules = GenerateOrderedMovieResponseRules(movieInformations);
      movieInformations.ForEach(mi => movieResponseRules.ForEach(rule => rule.Validate(mi)));
    }
  }
}