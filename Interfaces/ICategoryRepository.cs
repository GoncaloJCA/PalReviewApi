using PalReviewApi.Models;

namespace PalReviewApi.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pal> GetPalByCategory(int categoryId);
        bool CategoryExists(int id);
    }
}
