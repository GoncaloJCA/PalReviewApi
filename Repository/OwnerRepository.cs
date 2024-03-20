using PalReviewApi.Data;
using PalReviewApi.Interfaces;
using PalReviewApi.Models;
using System.Diagnostics.Metrics;

namespace PalReviewApi.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context) 
        {
            _context = context;
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            return Save();
        }

        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerByPal(int palId)
        {
            return _context.PalOwners.Where(po => po.PalId == palId).Select(o => o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public ICollection<Pal> GetPalByOwner(int ownerId)
        {
            return _context.PalOwners.Where(po => po.OwnerId == ownerId).Select(o => o.Pal).ToList();
        }
        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(o => o.Id == ownerId);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
