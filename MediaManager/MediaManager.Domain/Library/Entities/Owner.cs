using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;
using MediaManager.SharedKernel;

namespace MediaManager.Domain.Library.Entities
{
  public class Owner
  {
    [ExcludeFromCodeCoverage]
    public int OwnerId { get; private set; }
    public string OwnerName { get; private set; }
    public AuditInfo AuditInfo { get; private set; }

    [ExcludeFromCodeCoverage]
    private Owner() { }

    private Owner(string ownerName, string userId)
    {
      OwnerName = ownerName;
      AuditInfo = AuditInfo.CreateNew(userId);
    }

    public static Owner AddOwner(string ownerName, string userId) => new Owner(ownerName, userId);

    public void UpdateOwnerName(string ownerName, string userId)
    {
      OwnerName = ownerName;
      AuditInfo = AuditInfo.Modify(userId, AuditInfo);
    }

    [ExcludeFromCodeCoverage]
    internal class Configuration : EntityTypeConfiguration<Owner>
    {
      public Configuration()
      {
        ToTable("Owner", "MediaManager");
        HasKey(x => x.OwnerId);
      }
    }
  }
}