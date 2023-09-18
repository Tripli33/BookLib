using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.Book;

public abstract class ExtendBookForManipulationDto
{
    [Required(ErrorMessage = "Book name is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the book name is 50 characters.")]
    public string Name { get; init; } = String.Empty;
    [Required(ErrorMessage = "Book genre is a required field.")]
    public string Genre { get; init; } = "WithoutGenre";
    [Required(ErrorMessage = "Book language is a required field.")]
    public string Language { get; init; } = "WithoutLanguage";
    public string? AuthorName { get; init; }
    public string? PublisherName { get; init; }
    [Required(ErrorMessage = "Book publish date is a required field.")]
    public  DateTime PublishDate { get; init; }
    [Required(ErrorMessage = "Book pages is a required field.")]
    public int Pages { get; init; }

    public T ConvertExtendBookForManipulationDtoToBookForManipulationDto<T>(AuthorDto author,
        PublisherDto publisher) where T : BookForManipulationDto, new()

    {
        T bookForManipulationDto = new T()
        {
            Name = this.Name, Genre = this.Genre, Language = this.Language,
            AuthorId = author.AuthorId, PublisherId = publisher.PublisherId,
            PublishDate = this.PublishDate, Pages = this.Pages
        };
        return bookForManipulationDto;
    }
}