namespace Entities.Models
{
    public class Publisher 
    {
        public long PublisherId { get; set; }
        public string PublisherName { get; set; } = string.Empty;
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}