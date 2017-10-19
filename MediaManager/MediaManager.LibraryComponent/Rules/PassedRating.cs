namespace MediaManager.LibraryComponent.Rules
{
  internal class PassedRating : IMovieRatingRule
  {
    public void Validate(MovieInformationDto movieInformation)
    {
      movieInformation.Rated = movieInformation.Rated.Replace("PASSED", "NOTRATED");
    }
  }
}