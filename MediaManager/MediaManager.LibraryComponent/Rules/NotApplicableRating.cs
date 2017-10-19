namespace MediaManager.LibraryComponent.Rules
{
  internal class NotApplicableRating : IMovieRatingRule
  {
    public void Validate(MovieInformationDto movieInformation)
    {
      movieInformation.Rated = movieInformation.Rated.Replace("N/A", "NOTRATED");
    }
  }
}