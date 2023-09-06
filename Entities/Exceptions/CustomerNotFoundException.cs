namespace Entities.Exceptions;

public class CustomerNotFoundException : NotFoundException
{
    public CustomerNotFoundException(long id) 
    : base($"Customer with id: {id} doesn't exist in the database.")
    {
    }
}