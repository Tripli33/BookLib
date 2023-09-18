using Entities.Enums;
using Shared.DataTransferObjects.Author;
using Shared.DataTransferObjects.Book;
using Shared.DataTransferObjects.Publisher;

namespace Contracts;

public interface IBookRepository
{
    Task<IEnumerable<ExtendBookDto>> GetAllBooks();
    Task<IEnumerable<ExtendBookDto>> GetAllBooksByName(string name);
    Task<IEnumerable<ExtendBookDto>> GetAllBooksByGenre(Genre genre);
    Task<IEnumerable<ExtendBookDto>> GetAllBooksByLanguage(Language language);
    Task<IEnumerable<ExtendBookDto>> GetAllBooksByAuthor(AuthorDto author);
    Task<IEnumerable<ExtendBookDto>> GetAllBooksByPublisher(PublisherDto publisher);
    Task<IEnumerable<ExtendBookDto>> GetAllBooksByPublishDate(DateTime publishDate);
    Task<ExtendBookDto> GetBook(long id);
    void AddBook(BookForAddDto book);
    void DeleteBook(long id);
    void UpdateBook(long id, BookForUpdateDto book);
    Task<bool> BookExists(long id);
}