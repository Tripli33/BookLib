using Entities.Enums;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Contracts;

public interface IBookRepository
{
    Task<IEnumerable<BookDto>> GetAllBooks();
    Task<IEnumerable<BookDto>> GetAllBooksByName(string name);
    Task<IEnumerable<BookDto>> GetAllBooksByGenre(Genre genre);
    Task<IEnumerable<BookDto>> GetAllBooksByLanguage(Language language);
    Task<IEnumerable<BookDto>> GetAllBooksByAuthor(long authorId);
    Task<IEnumerable<BookDto>> GetAllBooksByPublisher(long publisherId);
    Task<IEnumerable<BookDto>> GetAllBooksByPublishDate(DateTime publishDate);
    Task<BookDto> GetBook(long id);
    Task AddBook(BookForAddDto book);
    Task DeleteBook(long id);
    Task UpdateBook(long id, BookForUpdateDto book);
    Task<bool> BookExists(long id);
}