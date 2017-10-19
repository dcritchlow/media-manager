namespace MediaManager.LibraryComponent.Rules
{
  internal class NrRating : IMovieRatingRule
  {
    public void Validate(MovieInformationDto movieInformation)
    {
      movieInformation.Rated = movieInformation.Rated.Replace("NR", "NOTRATED");
    }
  }
}