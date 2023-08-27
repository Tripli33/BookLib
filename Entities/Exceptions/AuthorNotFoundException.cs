namespace Entities.Exceptions;

public class AuthorNotFoundException : NotFoundException
{
    public AuthorNotFoundException(long id) 
    : base($"Author with id: {id} doesn't exist in the database.")
    {
    }
    public AuthorNotFoundException(string authorName) 
    : base($"Author with name: {authorName} doesn't exist in the database.")
    {
    }
}
