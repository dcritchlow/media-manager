﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using MediaManager.Domain.Library.Entities;

namespace MediaManager.Domain.Library.Data
{
  [ExcludeFromCodeCoverage]
  public class OwnerContext : DbContext
  {
    public OwnerContext() : base("DefaultConnection")
    {
      Database.Log = s => Debug.Write(s);
      Database.SetInitializer<OwnerContext>(null);
      Configuration.UseDatabaseNullSemantics = true;
      Database.CommandTimeout = 180;
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      modelBuilder.Configurations.Add(new Owner.Configuration());
    }

    public DbSet<Owner> OwnerSet { get; set; }
  }
}