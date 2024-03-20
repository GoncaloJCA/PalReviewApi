namespace PalReviewApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PalCategory> PalCategories { get; set; }

    }
}
