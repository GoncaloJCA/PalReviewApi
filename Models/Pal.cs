namespace PalReviewApi.Models
{
    public class Pal
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public DateTime CreatedDate { get; set;}
        public ICollection<Review> Reviews { get; set; }
        public ICollection<PalOwner> PalOwners { get; set; }
        public ICollection<PalCategory> PalCategories { get; set; }
    }
}
