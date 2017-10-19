using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using MediaManager.LibraryComponent.Entities;

namespace MediaManager.LibraryComponent.Repositories
{
  [ExcludeFromCodeCoverage]
  internal class MovieOwnerContext : DbContext, IMovieOwnerContext
  {
    public MovieOwnerContext() : base("DefaultConnection")
    {
      Database.Log = s => Debug.Write(s);
      Database.SetInitializer<MovieOwnerContext>(null);
      Configuration.UseDatabaseNullSemantics = true;
      Database.CommandTimeout = 180;
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      modelBuilder.Configurations.Add(new MovieOwner.Configuration());
    }

    public DbSet<MovieOwner> MovieOwnerSet { get; set; }
  }
}