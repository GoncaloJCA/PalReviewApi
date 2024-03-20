namespace PalReviewApi.Models
{
    public class PalOwner
    {
        public int PalId { get; set; }
        public int OwnerId { get; set; }
        public Pal Pal { get; set; }
        public Owner Owner { get; set; }
    }
}
