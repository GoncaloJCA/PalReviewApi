using PalReviewApi.Models;

namespace PalReviewApi.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnerByPal(int palId);
        ICollection<Pal> GetPalByOwner(int ownerId);
        public bool OwnerExists(int ownerId); 
        bool CreateOwner(Owner owner);
        bool Save();
    }
}
