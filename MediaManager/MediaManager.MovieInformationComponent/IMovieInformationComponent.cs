using System.Threading.Tasks;

namespace MediaManager.MovieInformationComponent
{
  public interface IMovieInformationComponent
  {
    Task<MovieInformationDto> GetMovieInformation(string title, string year, string imdbId);
  }
}