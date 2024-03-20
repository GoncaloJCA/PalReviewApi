namespace PalReviewApi.Models
{
    public class PalCategory
    {
        public int PalId { get; set; }
        public int CategoryId { get; set; }
        public Pal Pal { get; set; }
        public Category Category { get; set; }
    }
}
