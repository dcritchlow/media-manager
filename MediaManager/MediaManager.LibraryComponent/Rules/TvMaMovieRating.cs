namespace MediaManager.LibraryComponent.Rules
{
  internal class TvMaMovieRating : IMovieRatingRule
  {
    public void Validate(MovieInformationDto movieInformation)
    {
      movieInformation.Rated = movieInformation.Rated.Replace("TV-MA", "R");
    }
  }
}