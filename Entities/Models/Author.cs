namespace Entities.Models;

public class Author
{
    public long AuthorId { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<Book> Books { get; set; } = new List<Book>();
}