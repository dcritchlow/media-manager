using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using MediaManager.Domain.Library.Entities;
using MediaManager.Domain.Library.Interfaces;

namespace MediaManager.Domain.Library.Data
{
  [ExcludeFromCodeCoverage]
  public class TvOwnerContext : DbContext, ITvOwnerContext
  {
    public TvOwnerContext() : base("DefaultConnection")
    {
      Database.Log = s => Debug.Write(s);
      Database.SetInitializer<TvOwnerContext>(null);
      Configuration.UseDatabaseNullSemantics = true;
      Database.CommandTimeout = 180;
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      modelBuilder.Configurations.Add(new TvShow.Configuration());
      modelBuilder.Configurations.Add(new Owner.Configuration());
      modelBuilder.Configurations.Add(new TvOwner.Configuration());
      modelBuilder.Ignore<MovieOwner>();
    }

    public DbSet<TvOwner> TvOwnerSet { get; set; }
  }
}