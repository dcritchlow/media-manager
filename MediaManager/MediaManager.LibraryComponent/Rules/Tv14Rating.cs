namespace MediaManager.LibraryComponent.Rules
{
  internal class Tv14Rating : IMovieRatingRule
  {
    public void Validate(MovieInformationDto movieInformation)
    {
      movieInformation.Rated = movieInformation.Rated.Replace("TV-14", "PG13");
    }
  }
}