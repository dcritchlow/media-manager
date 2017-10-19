namespace MediaManager.LibraryComponent.Rules
{
  internal interface IMovieReleaseRule
  {
    void Validate(MovieInformationDto movieInformation);
  }
}