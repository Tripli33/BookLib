namespace Entities.Exceptions;

public class CustomerBookConflictException : ConflictException
{
    public CustomerBookConflictException(long customerId, long bookId) 
    : base($"Customer {customerId} with book {bookId} already exists")
    {
    }
}