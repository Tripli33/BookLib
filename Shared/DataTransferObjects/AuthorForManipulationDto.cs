using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Shared.DataTransferObjects;

public abstract class AuthorForManipulationDto
{
    [Required(ErrorMessage = "Author name is a required field.")]
    [MaxLength(30, ErrorMessage ="Maximum length for the author name is 30 characters.")]
    public string AuthorName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public Author ConvertAuthorForManipulationDtoToAuthor(long id)
    {
        var author = new Author()
        {
            AuthorId = id,
            AuthorName = this.AuthorName,
            Description = this.Description
        };
        return author;
    }
}