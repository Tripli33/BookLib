using Entities.Enums;

namespace Entities.Exceptions;

public class GenreNotFoundException : NotFoundException
{
    public GenreNotFoundException(string genre) 
    : base($"Genre with name: {genre} doesn't exist in the database.")
    {
    }

    public GenreNotFoundException(Genre genre) 
    : base($"Genre with name: {genre} doesn't exist in the database.")
    {
    }
}