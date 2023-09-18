using Entities.Enums;

namespace Entities.Exceptions;

public class GenreNotFoundException : NotFoundException
{
    public GenreNotFoundException(string genre) 
    : base($"Book with genre: {genre} doesn't exist in the database.")
    {
    }

    public GenreNotFoundException(Genre genre) 
    : base($"Book with genre: {genre} doesn't exist in the database.")
    {
    }
}