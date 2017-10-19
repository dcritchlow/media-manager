namespace MediaManager.LibraryComponent.Rules
{
  internal class UnRatedRating : IMovieRatingRule
  {
    public void Validate(MovieInformationDto movieInformation)
    {
      movieInformation.Rated = movieInformation.Rated.Replace("UNRATED", "NOTRATED");
    }
  }
}