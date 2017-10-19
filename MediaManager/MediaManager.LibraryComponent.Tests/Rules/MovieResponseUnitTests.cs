using System.Collections.Generic;
using MediaManager.LibraryComponent.Evaluators;
using MediaManager.SharedKernel;
using Moq;
using NUnit.Framework;

namespace MediaManager.LibraryComponent.Tests.Rules
{
  [TestFixture]
  public class MovieResponseUnitTests
  {
    [TestCase("True", null, true, null)]
    [TestCase("False", "Movie Not Found", false, "Movie Not Found")]
    public void ValidateMovieResponse_SetsCorrectValidState(string response, string error, bool expectedValidState, string expectedErrorValue)
    {
      var mockedLog = new Mock<ILog>();
      var movieInformations = new List<MovieInformationDto>
      {
        new MovieInformationDto
        {
          Title = "Title",
          Plot = string.Empty,
          Error = error,
          Rated = "NOTRATED",
          Released = "01/01/1999",
          Response = response,
          Valid = false
        }
      };
      new MovieResponseEvaluator(mockedLog.Object).Evaluate(movieInformations);

      Assert.That(movieInformations[0].Valid, Is.EqualTo(expectedValidState));
      Assert.That(movieInformations[0].Error, Is.EqualTo(expectedErrorValue));
    }
  }
}