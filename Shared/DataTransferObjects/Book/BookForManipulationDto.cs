using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Shared.DataTransferObjects.Book;

public abstract class BookForManipulationDto
{
    [Required(ErrorMessage = "Book name is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the book name is 50 characters.")]
    public string Name { get; init; } = String.Empty;
    [Required(ErrorMessage = "Book genre is a required field.")]
    public string Genre { get; init; } = "WithoutGenre";
    [Required(ErrorMessage = "Book language is a required field.")]
    public string Language { get; init; } = "WithoutLanguage";
    public long? AuthorId { get; init; }
    public long? PublisherId { get; init; }
    [Required(ErrorMessage = "Book publish date is a required field.")]
    public  DateTime PublishDate { get; init; }
    [Required(ErrorMessage = "Book pages is a required field.")]
    public int Pages { get; init; }
}