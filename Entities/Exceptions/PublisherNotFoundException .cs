namespace Entities.Exceptions;

public class PublisherNotFoundException : NotFoundException
{
    public PublisherNotFoundException(long id) 
    : base($"Publisher with id: {id} doesn't exist in the database.")
    {
    }
    public PublisherNotFoundException(string publisherName) 
    : base($"Publisher with name: {publisherName} doesn't exist in the database.")
    {
    }
}