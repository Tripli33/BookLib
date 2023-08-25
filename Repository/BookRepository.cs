using System.Runtime.CompilerServices;
using Contracts;
using Dapper;
using Entities.Enums;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Repository;

public class BookRepository : IBookRepository
{
    private readonly RepositoryContext _context;

    public BookRepository(RepositoryContext context)
    {
        _context = context;
    }

    public async Task AddBook(BookForAddDto book)
    {
        var query = @$"INSERT INTO books
                    (name, genre, language, author_id, publisher_id, publish_date, pages) 
                    VALUES 
                    (@Name, '{book.Genre}', '{book.Language}', @AuthorId, @PublisherId, @PublishDate, @Pages)";
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, book);
    }

    public async Task DeleteBook(long id)
    {
        var query = @"DELETE FROM books
                    WHERE book_id = @id";
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, new { id });
    }

    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        var query = "SELECT * FROM books";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<Book>(query);
        return books.ToList();
    }

    public async Task<IEnumerable<Book>> GetAllBooksByAuthor(long authorId)
    {
        var query = @"SELECT * FROM books
                    WHERE author_id = @authorId";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<Book>(query, new { authorId });
        return books.ToList();
    }

    public async Task<IEnumerable<Book>> GetAllBooksByAuthor(string authorName)
    {
        var query = @"SELECT * FROM books
                    WHERE author_name = @authorName";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<Book>(query, new { authorName });
        return books.ToList();
    }

    public async Task<IEnumerable<Book>> GetAllBooksByGenre(Genre genre)
    {
        var query = @$"SELECT * FROM books
                    WHERE genre = '{genre}'";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<Book>(query);
        return books.ToList();
    }

    public async Task<IEnumerable<Book>> GetAllBooksByLanguage(Language language)
    {
        var query = @$"SELECT * FROM books
                    WHERE language = '{language}'";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<Book>(query);
        return books.ToList();
    }

    public async Task<IEnumerable<Book>> GetAllBooksByName(string name)
    {
        var query = @"SELECT * FROM books
                    WHERE name = @name";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<Book>(query, new { name });
        return books.ToList();
    }

    public async Task<IEnumerable<Book>> GetAllBooksByPublishDate(DateTime publishDate)
    {
        var query = @"SELECT * FROM books
                    WHERE publish_date = @publishDate";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<Book>(query, new { publishDate });
        return books.ToList();
    }

    public async Task<IEnumerable<Book>> GetAllBooksByPublisher(long publisherId)
    {
        var query = @"SELECT * FROM books
                    WHERE publisher_id = @publisherId";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<Book>(query, new { publisherId });
        return books.ToList();
    }

    public async Task<IEnumerable<Book>> GetAllBooksByPublisher(string publisherName)
    {
        var query = @"SELECT * FROM books
                    WHERE publisher_name = @publisherName";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<Book>(query, new { publisherName });
        return books.ToList();
    }

    public async Task<Book> GetBook(long id)
    {
        var query = @"SELECT * FROM books
                    WHERE book_id = @id";
        using var connection = _context.CreateConnection();
        var book = await connection.QueryFirstOrDefaultAsync<Book>(query, new { id });
        return book;
    }

    public async Task UpdateBook(long id, BookForUpdateDto book)
    {
        var query = @$"UPDATE books SET
                    name = @Name, genre = '{book.Genre}',
                    language = '{book.Language}', author_id = @AuthorId,
                    publisher_id = @PublisherId, publish_date = @PublishDate,
                    pages = @Pages
                    WHERE book_id = @BookId";
        using var connection = _context.CreateConnection();
        var temp = book.ConvertBookForManipulationDtoToBook(id);
        await connection.ExecuteAsync(query, temp);
    }
}