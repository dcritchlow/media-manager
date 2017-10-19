using System.Diagnostics.CodeAnalysis;
using MediaManager.LibraryComponent.Evaluators;
using MediaManager.LibraryComponent.Repositories;
using Microsoft.Practices.Unity;

namespace MediaManager.LibraryComponent
{
  [ExcludeFromCodeCoverage]
  internal static class ComponentRegistration
  {
    public static void Register(IUnityContainer container)
    {
      SharedKernel.ComponentRegistration.Register(container);
      container.RegisterType<IMovieContext, MovieContext>(new TransientLifetimeManager());
      container.RegisterType<IOwnerContext, OwnerContext>(new TransientLifetimeManager());
      container.RegisterType<IMovieOwnerContext, MovieOwnerContext>(new TransientLifetimeManager());
      container.RegisterType<IMovieRepository, MovieRepository>(new TransientLifetimeManager());
      container.RegisterType<IMovieOwnerRepository, MovieOwnerRepository>(new TransientLifetimeManager());
      container.RegisterType<IOwnerRepository, OwnerRepository>(new TransientLifetimeManager());
      container.RegisterType<IMovieWishListContext, MovieWishListContext>(new TransientLifetimeManager());
      container.RegisterType<IEvaluator, EvaluatorRunner>(new TransientLifetimeManager());
      container.RegisterType<IEvaluatorFactory, EvaluatorFactory>(new HierarchicalLifetimeManager());
    }
  }
}