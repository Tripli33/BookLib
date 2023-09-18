using Entities.Enums;

namespace Entities.Exceptions;

public class LanguageNotFoundException : NotFoundException
{
    public LanguageNotFoundException(string language) 
    : base($"Book with language: {language} doesn't exist in the database.")
    {
    }

    public LanguageNotFoundException(Language language) 
    : base($"Book with language: {language} doesn't exist in the database.")
    {
    }
}