using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.Author;

public abstract class AuthorForManipulationDto
{
    [Required(ErrorMessage = "Author name is a required field.")]
    [MaxLength(30, ErrorMessage ="Maximum length for the author name is 30 characters.")]
    public string AuthorName { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;

    public AuthorDto ConvertAuthorForManipulationToAuthorDto(long id) 
    {
        AuthorDto author = new()
        {
            AuthorId = id,
            AuthorName = this.AuthorName,
            Description = this.Description
        };
        return author;
    }
    
}