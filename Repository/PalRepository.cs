using PalReviewApi.Data;
using PalReviewApi.Interfaces;
using PalReviewApi.Models;

namespace PalReviewApi.Repository
{
    public class PalRepository : IPalRepository
    {
        private readonly DataContext _context;

        public PalRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Pal> GetPals()
        {
            return _context.Pals.OrderBy(p => p.Id).ToList();
        }

        public Pal GetPal(int id)
        {
            return _context.Pals.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pal GetPal(string name)
        {
            return _context.Pals.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPalRating(int palId)
        {
            var review = _context.Reviews.Where(r => r.Id == palId);
            if (review.Count() <= 0)
            {
                return 0;
            }
            return ((decimal) review.Sum(r => r.Rating) / review.Count());
        }

        public bool PalExists(int palId)
        {
            return _context.Pals.Any(p => p.Id == palId);
        }

        public bool CreatePal(int ownerId, int categoryId, Pal pal)
        {
            var palOwnerEntity = _context.Owners.Where(o => ownerId == o.Id).FirstOrDefault();
            var palCategoryEntity = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();

            var palOwner = new PalOwner()
            {
                Owner = palOwnerEntity,
                Pal = pal
            };

            _context.Add(palOwner);

            var palCategory = new PalCategory()
            {
                Category = palCategoryEntity,
                Pal = pal
            };

            _context.Add(palCategory);

            _context.Add(pal);

            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
