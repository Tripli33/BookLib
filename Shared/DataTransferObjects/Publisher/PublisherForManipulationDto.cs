using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.Publisher;

public abstract class PublisherForManipulationDto
{
    [Required(ErrorMessage = "Publisher name is a required field.")]
    [MaxLength(30, ErrorMessage ="Maximum length for the publisher name is 30 characters.")]
    public string PublisherName { get; set; } = string.Empty;

    public PublisherDto ConvertPublisherForManipulationDtoToPublisherDto(long id)
    {
        PublisherDto publisher = new()
        {
            PublisherId = id,
            PublisherName = this.PublisherName
        };
        return publisher;
    }
    
}