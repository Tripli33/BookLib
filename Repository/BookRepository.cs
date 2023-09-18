using Contracts;
using Dapper;
using Entities.Enums;
using Shared.DataTransferObjects.Author;
using Shared.DataTransferObjects.Book;
using Shared.DataTransferObjects.Publisher;

namespace Repository;

public class BookRepository : IBookRepository
{
    private readonly RepositoryContext _context;

    public BookRepository(RepositoryContext context)
    {
        _context = context;
    }

    public void AddBook(BookForAddDto book)
    {
        var query = @$"INSERT INTO books
                    (name, genre, language, author_id, publisher_id, publish_date, pages) 
                    VALUES 
                    (@Name, CAST(@Genre AS genre_enum), CAST(@Language AS language_enum), @AuthorId, @PublisherId, @PublishDate, @Pages)";
        using var connection = _context.CreateConnection();
        connection.Execute(query, book);
    }

    public async Task<bool> BookExists(long id)
    {
        var query = @"SELECT *
                    FROM books
                    WHERE book_id = @id";
        using var connection = _context.CreateConnection();
        var book = await connection.QuerySingleOrDefaultAsync<BookDto>(query, new { id });
        return book is not null;
    }

    public void DeleteBook(long id)
    {
        var query = @"DELETE FROM books
                    WHERE book_id = @id";
        using var connection = _context.CreateConnection();
        connection.Execute(query, new { id });
    }

    public async Task<IEnumerable<ExtendBookDto>> GetAllBooks()
    {
        var query = @"SELECT
                        b.book_id AS BookId,
                        b.name AS Name,
                        b.genre AS Genre,
                        b.language AS Language,
                        a.author_name AS AuthorName,
                        p.publisher_name AS PublisherName,
                        b.publish_date AS PublishDate,
                        b.pages AS Pages
                    FROM
                        books AS b
                    LEFT JOIN
                        authors AS a ON b.author_id = a.author_id
                    LEFT JOIN
                        publishers AS p ON b.publisher_id = p.publisher_id";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<ExtendBookDto>(query);
        return books.ToList(); 
    }

    public async Task<IEnumerable<ExtendBookDto>> GetAllBooksByAuthor(AuthorDto author)
    {
        var query = @"SELECT
                        b.book_id AS BookId,
                        b.name AS Name,
                        b.genre AS Genre,
                        b.language AS Language,
                        @AuthorName AS AuthorName,
                        p.publisher_name AS PublisherName,
                        b.publish_date AS PublishDate,
                        b.pages AS Pages
                    FROM
                        books AS b
                    LEFT JOIN
                        publishers AS p ON b.publisher_id = p.publisher_id
                    WHERE b.author_id = @AuthorId";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<ExtendBookDto>(query, author);
        return books.ToList();
    }

    public async Task<IEnumerable<ExtendBookDto>> GetAllBooksByGenre(Genre genre)
    {
        var query = @$"SELECT
                        b.book_id AS BookId,
                        b.name AS Name,
                        '{genre}' AS Genre,
                        b.language AS Language,
                        a.author_name AS AuthorName,
                        p.publisher_name AS PublisherName,
                        b.publish_date AS PublishDate,
                        b.pages AS Pages
                    FROM
                        books AS b
                    LEFT JOIN
                        authors AS a ON b.author_id = a.author_id
                    LEFT JOIN
                        publishers AS p ON b.publisher_id = p.publisher_id
                    WHERE genre = '{genre}'";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<ExtendBookDto>(query);
        return books.ToList();
    }

    public async Task<IEnumerable<ExtendBookDto>> GetAllBooksByLanguage(Language language)
    {
        var query = @$"SELECT
                        b.book_id AS BookId,
                        b.name AS Name,
                        b.genre AS Genre,
                        '{language}' AS Language,
                        a.author_name AS AuthorName,
                        p.publisher_name AS PublisherName,
                        b.publish_date AS PublishDate,
                        b.pages AS Pages
                    FROM
                        books AS b
                    LEFT JOIN
                        authors AS a ON b.author_id = a.author_id
                    LEFT JOIN
                        publishers AS p ON b.publisher_id = p.publisher_id
                    WHERE language = '{language}'";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<ExtendBookDto>(query);
        return books.ToList();
    }

    public async Task<IEnumerable<ExtendBookDto>> GetAllBooksByName(string name)
    {
        var query = @"SELECT
                        b.book_id AS BookId,
                        @name AS Name,
                        b.genre AS Genre,
                        b.language AS Language,
                        a.author_name AS AuthorName,
                        p.publisher_name AS PublisherName,
                        b.publish_date AS PublishDate,
                        b.pages AS Pages
                    FROM
                        books AS b
                    LEFT JOIN
                        authors AS a ON b.author_id = a.author_id
                    LEFT JOIN
                        publishers AS p ON b.publisher_id = p.publisher_id
                    WHERE name = @name";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<ExtendBookDto>(query, new { name });
        return books.ToList();
    }

    public async Task<IEnumerable<ExtendBookDto>> GetAllBooksByPublishDate(DateTime publishDate)
    {
        var query = @"SELECT
                        b.book_id AS BookId,
                        b.name AS Name,
                        b.genre AS Genre,
                        b.language AS Language,
                        a.author_name AS AuthorName,
                        @publishDate AS PublisherName,
                        b.publish_date AS PublishDate,
                        b.pages AS Pages
                    FROM
                        books AS b
                    LEFT JOIN
                        authors AS a ON b.author_id = a.author_id
                    LEFT JOIN
                        publishers AS p ON b.publisher_id = p.publisher_id
                    WHERE publish_date = @publishDate";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<ExtendBookDto>(query, new { publishDate });
        return books.ToList();
    }

    public async Task<IEnumerable<ExtendBookDto>> GetAllBooksByPublisher(PublisherDto publisher)
    {
        var query = @"SELECT
                        b.book_id AS BookId,
                        b.name AS Name,
                        b.genre AS Genre,
                        b.language AS Language,
                        a.author_name AS AuthorName,
                        @PublisherName AS PublisherName,
                        b.publish_date AS PublishDate,
                        b.pages AS Pages
                    FROM
                        books AS b
                    LEFT JOIN
                        authors AS a ON b.author_id = a.author_id
                    WHERE publisher_id = @PublisherId";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<ExtendBookDto>(query, publisher);
        return books.ToList();
    }

    public async Task<ExtendBookDto> GetBook(long id)
    {
        var query = @"SELECT
                        @id AS BookId,
                        b.name AS Name,
                        b.genre AS Genre,
                        b.language AS Language,
                        a.author_name AS AuthorName,
                        p.publisher_name AS PublisherName,
                        b.publish_date AS PublishDate,
                        b.pages AS Pages
                    FROM
                        books AS b
                    LEFT JOIN
                        authors AS a ON b.author_id = a.author_id
                    LEFT JOIN
                        publishers AS p ON b.publisher_id = p.publisher_id
                    WHERE book_id = @id";
        using var connection = _context.CreateConnection();
        var book = await connection.QueryFirstOrDefaultAsync<ExtendBookDto>(query, new { id });
        return book;
    }

    public void UpdateBook(long id, BookForUpdateDto book)
    {
        var query = @"UPDATE books SET
                        name = @Name, genre = CAST(@Genre AS genre_enum), language = CAST(@Language AS language_enum),
                        author_id = @AuthorId, publisher_id = @PublisherId, publish_date = @PublishDate,
                        pages = @Pages
                    WHERE book_id = @BookId";
        using var connection = _context.CreateConnection();
        connection.Execute(query, new
        {
            BookId = id, Name = book.Name, Genre = book.Genre,
            Language = book.Language, AuthorId = book.AuthorId,
            PublisherId = book.PublisherId, PublishDate = book.PublishDate,
            Pages = book.Pages
        });
    }
}