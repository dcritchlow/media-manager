namespace MediaManager.LibraryComponent.Rules
{
  internal class NotApplicableReleaseDate : IMovieReleaseRule
  {
    public void Validate(MovieInformationDto movieInformation)
    {
      if(movieInformation.Released.Equals("N/A"))
      {
        movieInformation.Released = null;
      }
    }
  }
}