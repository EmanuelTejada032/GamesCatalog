namespace CORE.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public int ReviewRating { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
    }
}