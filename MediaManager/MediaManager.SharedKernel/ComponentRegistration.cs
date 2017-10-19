using System.Diagnostics.CodeAnalysis;
using Microsoft.Practices.Unity;

namespace MediaManager.SharedKernel
{
  [ExcludeFromCodeCoverage]
  public static class ComponentRegistration
  {
    public static void Register(IUnityContainer container)
    {
      container.RegisterType<ILog, NLog>(new ContainerControlledLifetimeManager());
    }
  }
}