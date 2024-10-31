namespace P01_IntroToApi.Controllers.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
        public int PublishYear { get; set; }
    }
}
