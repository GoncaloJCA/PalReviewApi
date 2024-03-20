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
    }
}
