using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;

namespace MediaManager.MovieInformationComponent
{
  public class MovieInformationComponent : IMovieInformationComponent
  {
    public MovieInformationComponent(IUnityContainer container)
    {
      if (container == null) throw new ArgumentNullException(nameof(container));
      RegisterComponents(container);
    }

    public async Task<MovieInformationDto> GetMovieInformation(string title, string year, string imdbId)
    {
      if (string.IsNullOrEmpty(title)) throw new ArgumentException("Value cannot be null or empty.", nameof(title));

      var result = await GetOmdbMovieInformation(title, year, imdbId);
      var movieJson = MapResultToMovieInformationDto(result);
      AddTitleSearchedFor(movieJson, title);
      return movieJson;
    }

    private static async Task<string> GetOmdbMovieInformation(string title, string year, string imdbId)
    {
      var apiKey = ConfigurationManager.AppSettings["OmdbApiKey"];
      if(string.IsNullOrEmpty(apiKey)) throw new ArgumentException("ApiKey was empty. Please add OMDB Api key to your app.config appsettings");
      var httpClient = new HttpClient
      {
        BaseAddress = new Uri("http://omdbapi.com/")
      };
      httpClient.DefaultRequestHeaders.Accept.Clear();
      httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      var encodedTitle = System.Uri.EscapeDataString(title);
      var response = await httpClient.GetAsync($"?apikey={apiKey}&t={encodedTitle}&y={year}&i={imdbId}&type=movie&plot=full");
      response.EnsureSuccessStatusCode();
      var result = response.Content.ReadAsStringAsync().Result;
      return result;
    }

    private static MovieInformationDto MapResultToMovieInformationDto(string result)
    {
      var movieJson = JsonConvert.DeserializeObject<MovieInformationDto>(result);
      return movieJson;
    }

    private static void AddTitleSearchedFor(MovieInformationDto movieInformation, string title)
    {
      movieInformation.OriginalTitle = title;
    }

    private void RegisterComponents(IUnityContainer container)
    {
      if (container == null) throw new ArgumentNullException(nameof(container));
      ComponentRegistration.Register(container);
    }
  }
}