namespace MediaManager.LibraryComponent.Rules
{
  internal interface IMovieRatingRule
  {
    void Validate(MovieInformationDto movieInformation);
  }
}