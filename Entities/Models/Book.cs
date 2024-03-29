using Entities.Enums;

namespace Entities.Models;
public class Book
{
    public long BookId { get; set; }
    public string Name { get; set; } = String.Empty;
    public Genre Genre { get; set; } = Genre.WithoutGenre;
    public Language Language { get; set; } = Language.WithoutLanguage;
    public long? AuthorId { get; set; }
    public long? PublisherId { get; set; }
    public  DateTime PublishDate { get; set; }
    public int Pages { get; set; }
    ICollection<CustomerBook> CustomerBooks { get; set; } = new List<CustomerBook>();
}