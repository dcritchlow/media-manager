using System;
using System.Collections.Generic;
using MediaManager.SharedKernel;

namespace MediaManager.LibraryComponent.Evaluators
{
  internal class EvaluatorRunner : IEvaluator
  {
    private readonly ILog _log;
    private readonly IEvaluatorFactory _evaluatorFactory;

    public EvaluatorRunner(IEvaluatorFactory evaluatorFactory, ILog log)
    {
      _evaluatorFactory = evaluatorFactory ?? throw new ArgumentNullException(nameof(evaluatorFactory));
      _log = log ?? throw new ArgumentNullException(nameof(log));
    }

    public void Evaluate(List<MovieInformationDto> movieInformations)
    {
      var evaluators = _evaluatorFactory.CreateOrderedEvaluators();
      evaluators.ForEach(evaluator => evaluator.Evaluate(movieInformations));
      _log.Info("Completed evaluation of MovieInformation");
    }
  }
}