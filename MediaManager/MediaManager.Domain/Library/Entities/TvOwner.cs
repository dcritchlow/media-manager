using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;
using MediaManager.SharedKernel;

namespace MediaManager.Domain.Library.Entities
{
  public class TvOwner
  {
    [ExcludeFromCodeCoverage]
    public int TvOwnerId { get; private set; }
    public int TvShowId { get; private set; }
    public int OwnerId { get; private set; }
    public AuditInfo AuditInfo { get; private set; }
    [ExcludeFromCodeCoverage]
    public virtual TvShow TvShow { get; private set; }
    [ExcludeFromCodeCoverage]
    public virtual Owner Owner { get; private set; }

    [ExcludeFromCodeCoverage]
    private TvOwner() { }

    private TvOwner(int tvShowId, int ownerId, string userId)
    {
      TvShowId = tvShowId;
      OwnerId = ownerId;
      AuditInfo = AuditInfo.CreateNew(userId);
    }

    public static TvOwner AddTvOwner(int tvShowId, int ownerId, string userId) => new TvOwner(tvShowId, ownerId, userId);

    [ExcludeFromCodeCoverage]
    internal class Configuration : EntityTypeConfiguration<TvOwner>
    {
      public Configuration()
      {
        ToTable("TvOwner", "MediaManager");
        HasKey(x => x.TvOwnerId);
      }
    }
  }
}