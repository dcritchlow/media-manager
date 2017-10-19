using System.Collections.Generic;
using MediaManager.SharedKernel;

namespace MediaManager.LibraryComponent.Evaluators
{
  internal class EvaluatorFactory : IEvaluatorFactory
  {
    private readonly ILog _log;

    public EvaluatorFactory(ILog log)
    {
      _log = log;
    }

    public List<IEvaluator> CreateOrderedEvaluators()
    {
      return new List<IEvaluator>
      {
        new MovieResponseEvaluator(_log),
        new MovieRatingEvaluator(),
        new MovieReleaseEvaluator()
      };
    }
  }
}