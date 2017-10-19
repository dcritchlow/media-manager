using System.Collections.Generic;

namespace MediaManager.LibraryComponent.Evaluators
{
  internal interface IEvaluatorFactory
  {
    List<IEvaluator> CreateOrderedEvaluators();
  }
}