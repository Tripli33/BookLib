using Entities.Enums;

namespace Entities.Exceptions;

public class LanguageNotFoundException : NotFoundException
{
    public LanguageNotFoundException(string language) 
    : base($"Language with name: {language} doesn't exist in the database.")
    {
    }

    public LanguageNotFoundException(Language language) 
    : base($"Language with name: {language} doesn't exist in the database.")
    {
    }
}