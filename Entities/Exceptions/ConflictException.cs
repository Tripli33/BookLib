namespace Entities.Exceptions;

public class ConflictException : Exception
{
    protected ConflictException(string message) : base(message)
    {  
    }
}