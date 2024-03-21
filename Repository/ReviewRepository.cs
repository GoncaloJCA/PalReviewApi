using PalReviewApi.Data;
using PalReviewApi.Interfaces;
using PalReviewApi.Models;

namespace PalReviewApi.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }
        public Review GetReview(int reviewId)
        {
            return _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfAPokemon(int pokeId)
        {
            return _context.Reviews.Where(r => r.Pal.Id == pokeId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
           return _context.Reviews.Any(r => r.Id == reviewId);
        }
    }
}
