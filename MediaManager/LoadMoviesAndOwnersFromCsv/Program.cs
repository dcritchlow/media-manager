using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using MediaManager.LibraryComponent;
using MediaManager.LibraryComponent.Exceptions;
using MediaManager.MovieInformationComponent;
using MediaManager.SharedKernel;
using Microsoft.Practices.Unity;
using Microsoft.VisualBasic.FileIO;
using Format = MediaManager.LibraryComponent.Format;
using MovieInformationDto = MediaManager.LibraryComponent.MovieInformationDto;

namespace LoadMoviesAndOwnersFromCsv
{
  public class Program
  {
    [STAThread]
    public static void Main(string[] args)
    {
      var container = new UnityContainer();
      ComponentRegistration.RegisterComponents(container);
      var libraryComponent = container.Resolve<ILibraryComponent>();
      var movieInformationComponent = container.Resolve<IMovieInformationComponent>();
      var log = container.Resolve<ILog>();

      var fileName = ShowFileDialog();

      if (!string.IsNullOrEmpty(fileName) && ValidCsvFile(fileName, log))
      {
        var movies = ReadMovieFile(fileName);
        AddMovies(movies, log, movieInformationComponent, libraryComponent);
        AddMovieOwners(movies, log, libraryComponent);
        AddMovieIntendingToBuyOwners(movies, log, libraryComponent);
      }
      else
      {
        log.Error("Please use a valid csv file.");
      }
      log.Info("Finished. Press enter to exit");
      Console.ReadLine();
    }

    private static string ShowFileDialog()
    {
      var dialog = new OpenFileDialog
      {
        Filter = "csv files (*.csv)|*.csv",
        InitialDirectory = @"C:\",
        Title = "Please select a csv file."
      };

      var fileName = string.Empty;
      if (dialog.ShowDialog() == DialogResult.OK)
      {
        fileName = dialog.FileName;
      }
      return fileName;
    }

    private static bool ValidCsvFile(string fileName, ILog log)
    {
      string[] fields = { };
      using (var parser = new TextFieldParser(fileName, Encoding.Default, true))
      {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");

        var headerRead = false;
        while (!parser.EndOfData && !headerRead)
        {
          fields = parser.ReadFields();
          headerRead = true;
        }
      }
      var validFile = ValidateHeader(fields, log);
      return validFile;
    }

    private static bool ValidateHeader(IReadOnlyList<string> fields, ILog log)
    {
      var headerValues = new[] { "DVD(D) or Bluray(B)", "Title", "Year", "imdbID", "Owner", "Owner 2", "Owner 3", "Intend to buy" };
      var headerErorrs = new Dictionary<string, string>();

      if (fields.Count != 8)
      {
        headerErorrs.Add(fields.Count.ToString(), 8.ToString());
      }

      for (var i = 0; i < 8; i++)
      {
        if(fields[i] != headerValues[i]) headerErorrs.Add(fields[i], headerValues[i]);
      }

      foreach (var headerErorr in headerErorrs)
      {
        log.Error($"{headerErorr.Key} header columns did not match expected {headerErorr.Value} columns");
      }
      return !headerErorrs.Any();
    }

    private static void AddMovies(IEnumerable<MovieDto> movies, ILog log, IMovieInformationComponent movieInformationComponent, ILibraryComponent libraryComponent)
    {
      log.Info("Adding Movies");
      if (!movies.Any())
      {
        log.Info("No movies in file to add");
        return;;
      }
      var movieInformations = GetMovieInformation(movies, log, movieInformationComponent);
      try
      {
        log.Info("Adding movies to database");
        libraryComponent.AddMovies(movieInformations);
        log.Info("Finished adding movies to database");
      }
      catch (DataNotFoundException exception)
      {
        log.Error($"Error encountered while adding movies. Message: {exception.Message}");
      }
      log.Info("Finished Adding Movies");
    }

    private static List<MovieInformationDto> GetMovieInformation(IEnumerable<MovieDto> movies, ILog log,
      IMovieInformationComponent movieInformationComponent)
    {
      Mapper.Initialize(cfg =>
      {
        cfg.CreateMap<MediaManager.MovieInformationComponent.MovieInformationDto, MovieInformationDto>();
        cfg.CreateMap<MediaManager.MovieInformationComponent.Format, Format>();
      });
      log.Info("Getting Movie Information");
      var movieInformations = new List<MovieInformationDto>();
      foreach (var movieDto in movies)
      {
        try
        {
          var movie = movieInformationComponent.GetMovieInformation(movieDto.Title, movieDto.Year, movieDto.ImdbId);
          movie.Result.Format = Mapper.Map(movieDto.Format, movie.Result.Format);

          movieInformations.Add(Mapper.Map(movie.Result, new MovieInformationDto()));
        }
        catch (ArgumentException ex)
        {
          log.Error(ex.Message);
        }
        catch (WebException ex)
        {
          log.Error($"Error encountered when getting movie information. Message: {ex.Message}");
        }
        catch (TaskCanceledException ex)
        {
          log.Error($"Error encountered when getting movie information. Message: {ex.Message} Task: {ex.Task}");
        }
      }
      log.Info("Finished Getting Movie Information");
      return movieInformations;
    }

    private static void AddMovieOwners(IEnumerable<MovieDto> movies, ILog log, ILibraryComponent libraryComponent)
    {
      log.Info("Adding Movie Owners");
      var movieOwners = new List<MovieOwnerDto>();
      foreach (var movieDto in movies)
      {
        movieOwners.AddRange(
          from movieDtoOwner in movieDto.Owners
          where !string.IsNullOrEmpty(movieDtoOwner)
          select new MovieOwnerDto
          {
            MovieTitle = movieDto.Title,
            OwnerName = movieDtoOwner,
            Year = movieDto.Year
          });
      }
      if (!movieOwners.Any())
      {
        log.Info("No movie owners listed");
        return;
      }
      try
      {
        libraryComponent.AddMovieOwners(movieOwners);
      }
      catch (DataNotFoundException exception)
      {
        log.Error($"Error encountered while adding movie owners. Message: {exception.Message}");
      }
    }

    private static void AddMovieIntendingToBuyOwners(IEnumerable<MovieDto> movies, ILog log, ILibraryComponent libraryComponent)
    {
      log.Info("Adding Movie Owners Intending to Buy");
      var movieOwners = (
        from movieDto in movies
        where !string.IsNullOrEmpty(movieDto.IntendToBuy) && movieDto.Owners.All(string.IsNullOrEmpty)
        select new MovieOwnerDto
        {
          MovieTitle = movieDto.Title,
          Year = movieDto.Year,
          IntendingToBuy = movieDto.IntendToBuy
        }).ToList();
      if (!movieOwners.Any())
      {
        log.Info("No movie owners intending to buy listed");
        return;
      }
      try
      {
        libraryComponent.AddMovieOwnersIntendingToBuy(movieOwners);
      }
      catch (DataNotFoundException exception)
      {
        log.Error($"Error encountered while adding movie owners. Message: {exception.Message}");
      }
    }

    private static List<MovieDto> ReadMovieFile(string path)
    {
      var movies = new List<MovieDto>();
      using(var parser = new TextFieldParser(path, Encoding.Default, true))
      {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        var firstLine = true;
        
        while(!parser.EndOfData)
        {
          var fields = parser.ReadFields();
          if (fields == null) return new List<MovieDto>();
          if (firstLine)
          {
            firstLine = false;
            continue;
          }
          movies.Add(new MovieDto
          {
            Format = fields[0] == "D" ? Format.Dvd : Format.BluRay,
            Title = fields[1],
            Year = fields[2],
            ImdbId = fields[3],
            Owners = new List<string> { fields[4], fields[5], fields[6] },
            IntendToBuy = fields[7]
          });
        }
      }
      return movies;
    }
  }
}
