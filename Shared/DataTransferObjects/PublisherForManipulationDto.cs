using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Shared.DataTransferObjects;

public abstract class PublisherForManipulationDto
{
    [Required(ErrorMessage = "Publisher name is a required field.")]
    [MaxLength(30, ErrorMessage ="Maximum length for the publisher name is 30 characters.")]
    public string PublisherName { get; set; } = string.Empty;

    public Publisher ConvertPublisherForManipulationDtoToPublisher(long id)
    {
        var publisher = new Publisher()
        {
            PublisherId = id,
            PublisherName = this.PublisherName
        };
        return publisher;
    }
}