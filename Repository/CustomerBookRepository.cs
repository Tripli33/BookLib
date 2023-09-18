using Contracts;
using Entities.Models;
using Dapper;
using Shared.DataTransferObjects.CustomerBook;
using Shared.DataTransferObjects.Book;

namespace Repository;

public class CustomerBookRepository : ICustomerBookRepository
{
    private readonly RepositoryContext _context;

    public CustomerBookRepository(RepositoryContext context)
    {
        _context = context;
    }

    public void AddCustomerBook(long customerId, CustomerBookDto book)
    {
        var query = @$"INSERT INTO customer_books
                    (customer_id, book_id) 
                    VALUES 
                    (@customerId, @bookId)";
        using var connection = _context.CreateConnection();
        var temp = new CustomerBook {BookId = book.BookId, CustomerId = customerId};
        connection.Execute(query, temp);
    }

    public async Task<bool> CustomerBookExists(long customerId, long bookId)
    {
        var query = @"SELECT *
                    FROM
                        customer_books
                    WHERE 
                        customer_id = @customerId 
                        AND book_id = @bookId";
        using var connection = _context.CreateConnection();
        var temp = new CustomerBook {BookId = bookId, CustomerId = customerId};
        var customerBook = await connection.QueryFirstOrDefaultAsync<CustomerBook>(query, temp);
        return customerBook is not null;
    }

    public void DeleteCustomerBook(long customerId, long bookId)
    {
        var query = @"DELETE FROM customer_books
                    WHERE customer_id = @customerId
                    AND book_id = @bookId";
        using var connection = _context.CreateConnection();
        var temp = new CustomerBook {BookId = bookId, CustomerId = customerId};
        connection.Execute(query, temp);
    }

    public async Task<IEnumerable<ExtendBookDto>> GetAllCustomerBooks(long customerId)
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
                        customer_books AS cb
                    JOIN
                        books AS b ON cb.book_id = b.book_id
                    LEFT JOIN
                        authors AS a ON b.author_id = a.author_id
                    LEFT JOIN
                        publishers AS p ON b.publisher_id = p.publisher_id
                    WHERE
                        cb.customer_id = @customerId";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<ExtendBookDto>(query, new { customerId });
        return books.ToList();
    }

    public async Task<ExtendBookDto> GetCustomerBook(long customerId, long bookId)
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
                        customer_books AS cb
                    JOIN
                        books AS b ON cb.book_id = b.book_id
                    LEFT JOIN
                        authors AS a ON b.author_id = a.author_id
                    LEFT JOIN
                        publishers AS p ON b.publisher_id = p.publisher_id
                    WHERE
                        cb.customer_id = @customerId
                        AND cb.book_id = @bookId";
        using var connection = _context.CreateConnection();
        var temp = new CustomerBook {BookId = bookId, CustomerId = customerId};
        var book = await connection.QueryFirstOrDefaultAsync<ExtendBookDto>(query, temp);
        return book;
    }
}