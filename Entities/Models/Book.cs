using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Enums;

namespace Entities.Models;

public class Book
{
    [Column("BookId")]
    public long Id { get; set; }
    [Required(ErrorMessage = "Book name is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the book name is 30 characters.")]
    public string Name { get; set; } = String.Empty;
    [Required(ErrorMessage = "Book genre is a required field.")]
    public Genre Genre { get; set; } = Genre.WithoutGenre;
    [Required(ErrorMessage = "Book language is a required field.")]
    public Language Language { get; set; } = Language.WithoutLanguage;
    [ForeignKey(nameof(Author))]
    public long AuthorId { get; set; }
    public Author? Author { get; set; }
    [ForeignKey(nameof(Publisher))]
    public long PublisherId { get; set; }
    public Publisher? Publisher { get; set; }
    [Required(ErrorMessage = "Book publish date is a required field.")]
    public  DateTime PublishDate { get; set; }
    [Required(ErrorMessage = "Book pages is a required field.")]
    public int Pages { get; set; }
}