using PalReviewApi.Models;

namespace PalReviewApi.Interfaces
{
    public interface IPalRepository
    {
        ICollection<Pal> GetPals();
        Pal GetPal(int id);
        Pal GetPal(string name);
        decimal GetPalRating(int palId);
        bool PalExists(int palId);
        bool CreatePal(int ownerId, int categoryId, Pal pal);
        bool Save();
    }
}
