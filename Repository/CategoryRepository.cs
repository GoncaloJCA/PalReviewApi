using PalReviewApi.Data;
using PalReviewApi.Interfaces;
using PalReviewApi.Models;

namespace PalReviewApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c => c.Id).ToList();
        }
         
        public Category GetCategory(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Pal> GetPalByCategory(int categoryId)
        {
            return _context.PalCategories.Where(c => c.CategoryId == categoryId).Select(p => p.Pal).ToList();    
        }
    }
}
