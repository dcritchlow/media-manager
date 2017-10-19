namespace MediaManager.LibraryComponent.Rules
{
  internal class NotRatedRating : IMovieRatingRule
  {
    public void Validate(MovieInformationDto movieInformation)
    {
      movieInformation.Rated = movieInformation.Rated.Replace("NOT RATED", "NOTRATED");
    }
  }
}