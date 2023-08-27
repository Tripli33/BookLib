namespace Entities.Exceptions;

public class BookNotFoundException : NotFoundException
{
    public BookNotFoundException(long id) 
    : base($"Book with id: {id} doesn't exist in the database.")
    {
    }
}