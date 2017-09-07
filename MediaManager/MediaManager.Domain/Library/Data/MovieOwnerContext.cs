using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using MediaManager.Domain.Library.Entities;
using MediaManager.Domain.Library.Interfaces;

namespace MediaManager.Domain.Library.Data
{
  [ExcludeFromCodeCoverage]
  public class MovieOwnerContext : DbContext, IMovieOwnerContext
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
      modelBuilder.Configurations.Add(new Movie.Configuration());
      modelBuilder.Configurations.Add(new Owner.Configuration());
      modelBuilder.Configurations.Add(new MovieOwner.Configuration());
      modelBuilder.Ignore<TvOwner>();
    }

    public DbSet<MovieOwner> MovieOwnerSet { get; set; }
  }
}