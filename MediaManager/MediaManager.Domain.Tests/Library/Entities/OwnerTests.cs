using MediaManager.Domain.Library.Entities;
using NUnit.Framework;

namespace MediaManager.Domain.Tests.Library.Entities
{
  [TestFixture]
  public class OwnerTests
  {
    [Test]
    public void AddOwner_ReturnsOwnerObject()
    {
      var owner = Owner.AddOwner("TestOwner", "testUser");
      Assert.IsInstanceOf<Owner>(owner);
      Assert.That(owner.OwnerName == "TestOwner");
      Assert.That(owner.AuditInfo.CreatedBy == "testUser");
    }

    [Test]
    public void UpdateOwnerName_ReturnsCorrectName()
    {
      var owner = Owner.AddOwner("TestOwner", "testUser");
      owner.UpdateOwnerName("BetterTestOwner", "testUser2");
      Assert.That(owner.OwnerName == "BetterTestOwner");
      Assert.That(owner.AuditInfo.ModifiedBy == "testUser2");
    }
  }
}