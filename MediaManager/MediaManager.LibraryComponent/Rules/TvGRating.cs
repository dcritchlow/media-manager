namespace MediaManager.LibraryComponent.Rules
{
  internal class TvGRating : IMovieRatingRule
  {
    public void Validate(MovieInformationDto movieInformation)
    {
      movieInformation.Rated = movieInformation.Rated.Replace("TV-G", "G");
    }
  }
}