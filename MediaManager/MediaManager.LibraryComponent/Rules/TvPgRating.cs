namespace MediaManager.LibraryComponent.Rules
{
  internal class TvPgRating : IMovieRatingRule
  {
    public void Validate(MovieInformationDto movieInformation)
    {
      movieInformation.Rated = movieInformation.Rated.Replace("TV-PG", "PG");
    }
  }
}