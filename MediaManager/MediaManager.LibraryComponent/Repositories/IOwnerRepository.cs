using System.Collections.Generic;
using MediaManager.LibraryComponent.Entities;

namespace MediaManager.LibraryComponent.Repositories
{
  internal interface IOwnerRepository
  {
    void AddOwner(Owner owner);
    Owner GetOwner(string ownerName);
    IEnumerable<Owner> GetAllOwners();
    void SaveChanges();
  }
}