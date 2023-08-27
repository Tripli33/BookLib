using Entities.Enums;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAllBooks();
    Task<IEnumerable<Book>> GetAllBooksByName(string name);
    Task<IEnumerable<Book>> GetAllBooksByGenre(Genre genre);
    Task<IEnumerable<Book>> GetAllBooksByLanguage(Language language);
    Task<IEnumerable<Book>> GetAllBooksByAuthor(long authorId);
    Task<IEnumerable<Book>> GetAllBooksByPublisher(long publisherId);
    Task<IEnumerable<Book>> GetAllBooksByPublishDate(DateTime publishDate);
    Task<Book> GetBook(long id);
    Task AddBook(BookForAddDto book);
    Task DeleteBook(long id);
    Task UpdateBook(long id, BookForUpdateDto book);
}