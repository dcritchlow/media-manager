using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using MediaManager.LibraryComponent.Entities;

namespace MediaManager.LibraryComponent.Repositories
{
  internal class MovieWishListContext : DbContext, IMovieWishListContext
  {
    public MovieWishListContext() : base("DefaultConnection")
    {
      Database.Log = s => Debug.Write(s);
      Database.SetInitializer<MovieWishListContext>(null);
      Configuration.UseDatabaseNullSemantics = true;
      Database.CommandTimeout = 180;
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      modelBuilder.Configurations.Add(new MovieWishList.Configuration());
      modelBuilder.Configurations.Add(new Movie.Configuration());
    }

    public DbSet<MovieWishList> MovieWishListSet { get; set; }
  }
}