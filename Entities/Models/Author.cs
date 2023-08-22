using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Author
{
    [Column("AuthorId")]
    public long Id { get; set; }
    [Required(ErrorMessage = "Author name is a required field.")]
    [MaxLength(30, ErrorMessage ="Maximum length for the author name is 30 characters.")]
    public string AuthorName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<Book> Books { get; set; } = new List<Book>();
}