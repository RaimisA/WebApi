namespace P01_IntroToApi.Controllers.Models
{
    public class TodoItem
    {
        public TodoItem()
        {
        }

        public TodoItem(int id, string name, string content, DateTime endDate, string userId)
        {
            Id = id;
            Name = name;
            Content = content;
            EndDate = endDate;
            UserId = userId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }
    }
}
