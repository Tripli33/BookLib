using Contracts;
using Entities.Enums;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class BookService : IBookService
{
    private readonly IRepositoryManager _repositoryManager;
    public BookService (IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task AddBook(BookForAddDto book)
    {
        await _repositoryManager.Book.AddBook(book);
    }

    public async Task DeleteBook(long id)
    {
        if (!await _repositoryManager.Book.BookExists(id))
        throw new BookNotFoundException(id);
        await _repositoryManager.Book.DeleteBook(id);
    }

    public Task<IEnumerable<Book>> GetAllBooks()
    {
        return _repositoryManager.Book.GetAllBooks();
    }

    public async Task<IEnumerable<Book>> GetAllBooksByAuthor(long authorId)
    {
        if (!await _repositoryManager.Author.AuthorExists(authorId))
        throw new AuthorNotFoundException(authorId);
        return await _repositoryManager.Book.GetAllBooksByAuthor(authorId);
    }
    
    public Task<IEnumerable<Book>> GetAllBooksByGenre(Genre genre)
    {
        return _repositoryManager.Book.GetAllBooksByGenre(genre);
    }

    public Task<IEnumerable<Book>> GetAllBooksByLanguage(Language language)
    {
        return _repositoryManager.Book.GetAllBooksByLanguage(language);
    }

    public async Task<IEnumerable<Book>> GetAllBooksByName(string name)
    {
        return await _repositoryManager.Book.GetAllBooksByName(name);
    }

    public Task<IEnumerable<Book>> GetAllBooksByPublishDate(DateTime publishDate)
    {
        return _repositoryManager.Book.GetAllBooksByPublishDate(publishDate);
    }

    public async Task<IEnumerable<Book>> GetAllBooksByPublisher(long publisherId)
    {
        if (!await _repositoryManager.Publisher.PublisherExists(publisherId))
        throw new PublisherNotFoundException(publisherId);
        return await _repositoryManager.Book.GetAllBooksByPublisher(publisherId);
    }

    public Task<Book> GetBook(long id)
    {
        var book = _repositoryManager.Book.GetBook(id);
        return book ?? throw new BookNotFoundException(id);
    }

    public async Task UpdateBook(long id, BookForUpdateDto book)
    {
        if (!await _repositoryManager.Book.BookExists(id))
        throw new BookNotFoundException(id);
        await _repositoryManager.Book.UpdateBook(id, book);
    }
}