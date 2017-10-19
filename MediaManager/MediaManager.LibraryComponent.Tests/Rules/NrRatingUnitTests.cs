using System.Collections.Generic;
using MediaManager.LibraryComponent.Evaluators;
using NUnit.Framework;

namespace MediaManager.LibraryComponent.Tests.Rules
{
  [TestFixture]
  public class NrRatingUnitTests
  {
    [TestCase("NR", "NOTRATED")]
    public void ValidateNrRating_ReplacesWithCorrectRating(string rating, string expectedRating)
    {
      var movieInformations = new List<MovieInformationDto>()
      {
        new MovieInformationDto
        {
          Title = "Title",
          Plot = string.Empty,
          Error = null,
          Rated = rating,
          Released = "01/01/1999",
          Response = "true",
          Valid = true
        }
      };
      new MovieRatingEvaluator().Evaluate(movieInformations);

      Assert.That(movieInformations[0].Rated, Is.EqualTo(expectedRating));
    }
  }
}