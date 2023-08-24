using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Models;
public class Book
{
    public long BookId { get; set; }
    [Required(ErrorMessage = "Book name is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the book name is 50 characters.")]
    public string Name { get; set; } = String.Empty;
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [Required(ErrorMessage = "Book genre is a required field.")]
    public Genre Genre { get; set; } = Genre.WithoutGenre;
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [Required(ErrorMessage = "Book language is a required field.")]
    public Language Language { get; set; } = Language.WithoutLanguage;
    public long AuthorId { get; set; }
    public long PublisherId { get; set; }
    [Required(ErrorMessage = "Book publish date is a required field.")]
    public  DateTime PublishDate { get; set; }
    [Required(ErrorMessage = "Book pages is a required field.")]
    public int Pages { get; set; }
}