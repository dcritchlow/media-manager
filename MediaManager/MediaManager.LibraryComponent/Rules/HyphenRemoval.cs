namespace MediaManager.LibraryComponent.Rules
{
  internal class HyphenRemoval : IMovieRatingRule
  {
    public void Validate(MovieInformationDto movieInformation)
    {
      movieInformation.Rated = movieInformation.Rated.Replace("-", "");
    }
  }
}