using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Publisher 
    {
        public long PublisherId { get; set; }
        [Required(ErrorMessage = "Publisher name is a required field.")]
        [MaxLength(30, ErrorMessage ="Maximum length for the publisher name is 30 characters.")]
        public string PublisherName { get; set; } = string.Empty;
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}