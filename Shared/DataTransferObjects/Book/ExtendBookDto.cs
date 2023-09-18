using System.Text.Json.Serialization;
using Entities.Enums;

namespace Shared.DataTransferObjects.Book;

public class ExtendBookDto
{
    public long BookId { get; init; }
    public string Name { get; init; } = string.Empty;
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Genre Genre { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Language Language { get; init; }
    public string? AuthorName { get; init; }
    public string? PublisherName { get; init; }
    public DateTime PublishDate { get; init; }
    public int Pages { get; init; }
}