using System;
using System.Collections.Generic;
using System.Data.Entity;
using MediaManager.LibraryComponent.Entities;
using System.Linq;

namespace MediaManager.LibraryComponent.Repositories
{
  internal class OwnerRepository : IOwnerRepository
  {
    private readonly IOwnerContext _ownerContext;

    public OwnerRepository(IOwnerContext ownerContext)
    {
      _ownerContext = ownerContext ?? throw new ArgumentNullException(nameof(ownerContext));
    }

    public void AddOwner(Owner owner)
    {
      if (owner == null) throw new ArgumentNullException(nameof(owner));
      _ownerContext.OwnerSet.Add(owner);
      _ownerContext.SaveChanges();
    }

    public Owner GetOwner(string ownerName)
    {
      return _ownerContext.OwnerSet.AsNoTracking().FirstOrDefault(o => o.OwnerName.Contains(ownerName)) ?? Owner.AddOwner(ownerName, Environment.UserName);
    }

    public IEnumerable<Owner> GetAllOwners()
    {
      var query = from o in _ownerContext.OwnerSet select o;
      return query.AsNoTracking().ToList();
    }

    public void SaveChanges()
    {
      _ownerContext.SaveChanges();
    }
  }
}