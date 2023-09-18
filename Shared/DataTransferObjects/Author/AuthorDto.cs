namespace Shared.DataTransferObjects.Author;

public class AuthorDto
{
    public long AuthorId { get; init; }
    public string AuthorName { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    
}