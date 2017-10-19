namespace MediaManager.LibraryComponent.Rules
{
  internal class ApprovedRating : IMovieRatingRule
  {
    public void Validate(MovieInformationDto movieInformation)
    {
      movieInformation.Rated = movieInformation.Rated.Replace("APPROVED", "NOTRATED");
    }
  }
}