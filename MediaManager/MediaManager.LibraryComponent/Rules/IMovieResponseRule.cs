namespace MediaManager.LibraryComponent.Rules
{
  internal interface IMovieResponseRule
  {
    void Validate(MovieInformationDto movieInformation);
  }
}