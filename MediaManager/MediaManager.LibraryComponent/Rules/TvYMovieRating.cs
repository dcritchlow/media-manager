namespace MediaManager.LibraryComponent.Rules
{
  internal class TvYMovieRating : IMovieRatingRule
  {
    public void Validate(MovieInformationDto movieInformation)
    {
      movieInformation.Rated = movieInformation.Rated.Replace("TV-Y", "G");
    }
  }
}