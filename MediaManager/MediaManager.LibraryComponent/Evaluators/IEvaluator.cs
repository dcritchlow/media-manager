using System.Collections.Generic;

namespace MediaManager.LibraryComponent.Evaluators
{
  internal interface IEvaluator
  {
    void Evaluate(List<MovieInformationDto> movieInformations);
  }
}