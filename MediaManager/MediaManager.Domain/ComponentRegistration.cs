using System.Diagnostics.CodeAnalysis;
using MediaManager.Domain.Library.Data;
using MediaManager.Domain.Library.Interfaces;
using MediaManager.Domain.Library.Repositories;
using Microsoft.Practices.Unity;

namespace MediaManager.Domain
{
  [ExcludeFromCodeCoverage]
  public static class ComponentRegistration
  {
    public static void Register(IUnityContainer container)
    {
      container.RegisterType<IMovieContext, MovieContext>();
      container.RegisterType<IMovieOwnerContext, MovieOwnerContext>();
      container.RegisterType<IMovieRepository, MovieRepository>();
      container.RegisterType<IMovieOwnerRepository, MovieOwnerRepository>();
    }
  }
}