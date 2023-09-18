using Shared.DataTransferObjects.Book;

namespace Service.Contracts;

public interface IBookService
{
    Task<IEnumerable<ExtendBookDto>> GetAllBooks();
    Task<IEnumerable<ExtendBookDto>> GetAllBooksByName(string name);
    Task<IEnumerable<ExtendBookDto>> GetAllBooksByGenre(string genreName);
    Task<IEnumerable<ExtendBookDto>> GetAllBooksByLanguage(string languageName);
    Task<IEnumerable<ExtendBookDto>> GetAllBooksByAuthor(string authorName);
    Task<IEnumerable<ExtendBookDto>> GetAllBooksByPublisher(string publisherName);
    Task<IEnumerable<ExtendBookDto>> GetAllBooksByPublishDate(DateTime publishDate);
    Task<ExtendBookDto> GetBook(long id);
    Task AddBook(ExtendBookForAddDto book);
    Task DeleteBook(long id);
    Task UpdateBook(long id, ExtendBookForUpdateDto book);
}