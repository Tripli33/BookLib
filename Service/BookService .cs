using Contracts;
using Entities.Enums;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects.Author;
using Shared.DataTransferObjects.Book;
using Shared.DataTransferObjects.Publisher;

namespace Service;

public class BookService : IBookService
{
    private readonly IRepositoryManager _repositoryManager;
    public BookService (IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task AddBook(ExtendBookForAddDto book)
    {
        AuthorDto author = new();
        PublisherDto publisher = new();
        if (book.AuthorName is not null)
            author = await _repositoryManager.Author.GetAuthor(book.AuthorName)
            ?? throw new AuthorNotFoundException(book.AuthorName);
        if (book.PublisherName is not null)
            publisher = await _repositoryManager.Publisher.GetPublisher(book.PublisherName)
            ?? throw new PublisherNotFoundException(book.PublisherName);
        if (!EnumExtensions.IsEnumNameValid<Genre>(book.Genre))
            throw new GenreNotFoundException(book.Genre);
        if (!EnumExtensions.IsEnumNameValid<Language>(book.Language))
            throw new LanguageNotFoundException(book.Language);
        _repositoryManager.Book.AddBook
        (
                book.ConvertExtendBookForManipulationDtoToBookForManipulationDto<BookForAddDto>(author, publisher)
        );
    }

    public async Task DeleteBook(long id)
    {
        if (!await _repositoryManager.Book.BookExists(id))
        throw new BookNotFoundException(id);
        _repositoryManager.Book.DeleteBook(id);
    }

    public Task<IEnumerable<ExtendBookDto>> GetAllBooks()
    {
        return _repositoryManager.Book.GetAllBooks();
    }

    public async Task<IEnumerable<ExtendBookDto>> GetAllBooksByAuthor(string authorName)
    {
        var author = await _repositoryManager.Author.GetAuthor(authorName)
        ?? throw new AuthorNotFoundException(authorName);
        return await _repositoryManager.Book.GetAllBooksByAuthor(author);
    }

    public async Task<IEnumerable<ExtendBookDto>> GetAllBooksByGenre(string genreName)
    {
        if (!EnumExtensions.IsEnumNameValid<Genre>(genreName))
            throw new GenreNotFoundException(genreName);
        Genre genre = EnumExtensions.EnumNameToEnum<Genre>(genreName, Genre.WithoutGenre);
        return await _repositoryManager.Book.GetAllBooksByGenre(genre);
    }

    public Task<IEnumerable<ExtendBookDto>> GetAllBooksByLanguage(string languageName)
    {
        if (!EnumExtensions.IsEnumNameValid<Language>(languageName))
            throw new LanguageNotFoundException(languageName);
        Language language = EnumExtensions.EnumNameToEnum<Language>(languageName, Language.WithoutLanguage);
        return _repositoryManager.Book.GetAllBooksByLanguage(language);
    }

    public async Task<IEnumerable<ExtendBookDto>> GetAllBooksByName(string name)
    {
        return await _repositoryManager.Book.GetAllBooksByName(name);
    }

    public async Task<IEnumerable<ExtendBookDto>> GetAllBooksByPublishDate(DateTime publishDate)
    {
        return await _repositoryManager.Book.GetAllBooksByPublishDate(publishDate);
    }

    public async Task<IEnumerable<ExtendBookDto>> GetAllBooksByPublisher(string publisherName)
    {
        var publisher = await _repositoryManager.Publisher.GetPublisher(publisherName)
        ?? throw new PublisherNotFoundException(publisherName);
        return await _repositoryManager.Book.GetAllBooksByPublisher(publisher);
    }

    public async Task<ExtendBookDto> GetBook(long id)
    {
        var book = await _repositoryManager.Book.GetBook(id);
        return book ?? throw new BookNotFoundException(id);
    }

    public async Task UpdateBook(long id, ExtendBookForUpdateDto book)
    {
        if (!await _repositoryManager.Book.BookExists(id))
        throw new BookNotFoundException(id);
        AuthorDto author = new();
        PublisherDto publisher = new();
        if (book.AuthorName is not null)
            author = await _repositoryManager.Author.GetAuthor(book.AuthorName)
            ?? throw new AuthorNotFoundException(book.AuthorName);
        if (book.PublisherName is not null)
            publisher = await _repositoryManager.Publisher.GetPublisher(book.PublisherName)
            ?? throw new PublisherNotFoundException(book.PublisherName);
        if (!EnumExtensions.IsEnumNameValid<Genre>(book.Genre))
            throw new GenreNotFoundException(book.Genre);
        if (!EnumExtensions.IsEnumNameValid<Language>(book.Language))
            throw new LanguageNotFoundException(book.Language);
        _repositoryManager.Book.UpdateBook(
            id, 
            book.ConvertExtendBookForManipulationDtoToBookForManipulationDto<BookForUpdateDto>(author, publisher)
        );
    }
}