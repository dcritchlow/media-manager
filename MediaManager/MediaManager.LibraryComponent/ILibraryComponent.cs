using System.Collections.Generic;

namespace MediaManager.LibraryComponent
{
  public interface ILibraryComponent
  {
    void AddMovies(List<MovieInformationDto> movieInformations);
    void AddMovieOwners(List<MovieOwnerDto> movieOwnerDtos);
    void AddMovieOwnersIntendingToBuy(List<MovieOwnerDto> movieOwnersDtos);
  }
}