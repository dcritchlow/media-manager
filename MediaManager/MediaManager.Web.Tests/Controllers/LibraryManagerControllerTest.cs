using MediaManager.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediaManager.Web.Tests.Controllers
{
  [TestClass]
  public class LibraryManagerControllerTest
  {
    [TestMethod]
    public void Index()
    {
      var controller = new LibraryManagerController();

      var result = controller.Index();

      Assert.IsNotNull(result);
    }
  }
}
