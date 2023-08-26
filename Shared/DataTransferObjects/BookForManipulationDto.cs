using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Entities.Enums;
using Entities.Models;

namespace Shared.DataTransferObjects;

public abstract class BookForManipulationDto
{
    [Required(ErrorMessage = "Book name is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the book name is 50 characters.")]
    public string Name { get; init; } = String.Empty;
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [Required(ErrorMessage = "Book genre is a required field.")]
    public Genre Genre { get; init; } = Genre.WithoutGenre;
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [Required(ErrorMessage = "Book language is a required field.")]
    public Language Language { get; init; } = Language.WithoutLanguage;
    public long? AuthorId { get; init; }
    public long? PublisherId { get; init; }
    [Required(ErrorMessage = "Book publish date is a required field.")]
    public  DateTime PublishDate { get; init; }
    [Required(ErrorMessage = "Book pages is a required field.")]
    public int Pages { get; init; }

    public Book ConvertBookForManipulationDtoToBook(long id)
    {
        var book = new Book()
        {
            BookId = id, Name = this.Name, Genre = this.Genre, 
            Language = this.Language, AuthorId = this.AuthorId,
            PublisherId = this.PublisherId, PublishDate = this.PublishDate,
            Pages = this.Pages
        };
        return book;
    }
}
