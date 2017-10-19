using System.Diagnostics.CodeAnalysis;
using Microsoft.Practices.Unity;

namespace MediaManager.MovieInformationComponent
{
  [ExcludeFromCodeCoverage]
  internal static class ComponentRegistration
  {
    public static void Register(IUnityContainer container)
    {
      container.RegisterType<IMovieInformationComponent, MovieInformationComponent>();
    }
  }
}