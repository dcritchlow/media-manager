using System.Collections.Generic;
using MediaManager.LibraryComponent.Evaluators;
using NUnit.Framework;

namespace MediaManager.LibraryComponent.Tests.Rules
{
  [TestFixture]
  public class NotApplicableReleaseDateUnitTests
  {
    [TestCase("N/A", null)]
    [TestCase("01/01/1999", "01/01/1999")]
    public void ValidateNotApplicableReleaseDate_SetsCorrecReleaseDate(string released, string expectedRelease)
    {
      var movieInformations = new List<MovieInformationDto>()
      {
        new MovieInformationDto
        {
          Title = "Title",
          Plot = string.Empty,
          Error = null,
          Rated = "NOTRATED",
          Released = released,
          Response = "true",
          Valid = true
        }
      };
      new MovieReleaseEvaluator().Evaluate(movieInformations);

      Assert.That(movieInformations[0].Released, Is.EqualTo(expectedRelease));
    }
  }
}