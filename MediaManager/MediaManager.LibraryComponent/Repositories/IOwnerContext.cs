using System.Data.Entity;
using MediaManager.LibraryComponent.Entities;

namespace MediaManager.LibraryComponent.Repositories
{
  internal interface IOwnerContext
  {
    DbSet<Owner> OwnerSet { get; set; }
    int SaveChanges();
  }
}