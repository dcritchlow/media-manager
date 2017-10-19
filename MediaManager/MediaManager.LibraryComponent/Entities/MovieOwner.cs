using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;
using MediaManager.SharedKernel;

namespace MediaManager.LibraryComponent.Entities
{
  internal class MovieOwner
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

    internal static MovieOwner AddMovieOwner(int movieId, int ownerId, string userId) => new MovieOwner(movieId, ownerId, userId);
    
    [ExcludeFromCodeCoverage]
    internal class Configuration : EntityTypeConfiguration<MovieOwner>
    {
      internal Configuration()
      {
        ToTable("MovieOwner", "MediaManager");
        HasKey(x => x.MovieOwnerId);
      }
    }
  }
}