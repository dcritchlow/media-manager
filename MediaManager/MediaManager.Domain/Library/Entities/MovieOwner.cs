using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;
using MediaManager.SharedKernel;

namespace MediaManager.Domain.Library.Entities
{
  public class MovieOwner
  {
    [ExcludeFromCodeCoverage]
    public int MovieOwnerId { get; private set; }
    public int MovieId { get; private set; }
    public int OwnerId { get; private set; }
    public AuditInfo AuditInfo { get; private set; }
    [ExcludeFromCodeCoverage]
    public virtual Movie Movie { get; private set; }
    [ExcludeFromCodeCoverage]
    public virtual Owner Owner { get; private set; }

    [ExcludeFromCodeCoverage]
    private MovieOwner() { }

    private MovieOwner(int movieId, int ownerId, string userId)
    {
      MovieId = movieId;
      OwnerId = ownerId;
      AuditInfo = AuditInfo.CreateNew(userId);
    }

    public static MovieOwner AddMovieOwner(int movieId, int ownerId, string userId) => new MovieOwner(ownerId, movieId, userId);
    
    [ExcludeFromCodeCoverage]
    internal class Configuration : EntityTypeConfiguration<MovieOwner>
    {
      public Configuration()
      {
        ToTable("MovieOwner", "MediaManager");
        HasKey(x => x.MovieOwnerId);
      }
    }
  }
}