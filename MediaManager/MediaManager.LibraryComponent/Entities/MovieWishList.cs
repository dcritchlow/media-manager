using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;
using MediaManager.SharedKernel;

namespace MediaManager.LibraryComponent.Entities
{
  internal class MovieWishList
  {
    internal int MovieWishListId { get; private set; }
    internal int MovieId { get; private set; }
    internal AuditInfo AuditInfo { get; private set; }
    internal virtual Movie Movie { get; private set; }

    private MovieWishList() { }

    private MovieWishList(int movieId, string userId)
    {
      MovieId = movieId; 
      AuditInfo = AuditInfo.CreateNew(userId);
    }

    internal static MovieWishList CreateMovieWishList(int movieId, string userId) => new MovieWishList(movieId, userId);

    [ExcludeFromCodeCoverage]
    internal class Configuration : EntityTypeConfiguration<MovieWishList>
    {
      internal Configuration()
      {
        ToTable("MovieWishList", "MediaManager");
        HasKey(x => x.MovieWishListId).HasRequired(m => m.Movie);
      }
    }
  }
}