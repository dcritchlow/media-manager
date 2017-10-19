using MediaManager.LibraryComponent;
using MediaManager.MovieInformationComponent;
using Microsoft.Practices.Unity;

namespace LoadMoviesAndOwnersFromCsv
{
  public static class ComponentRegistration
  {
    public static void RegisterComponents(IUnityContainer container)
    {
      container.RegisterType<ILibraryComponent, LibraryComponent>(new InjectionConstructor(container));
      container.RegisterType<IMovieInformationComponent, MovieInformationComponent>(new InjectionConstructor(container));
    }
  }
}