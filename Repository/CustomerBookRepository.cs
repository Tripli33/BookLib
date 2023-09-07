using Contracts;
using Entities.Models;
using Shared.DataTransferObjects;
using Dapper;

namespace Repository;

public class CustomerBookRepository : ICustomerBookRepository
{
    private readonly RepositoryContext _context;

    public CustomerBookRepository(RepositoryContext context)
    {
        _context = context;
    }

    public async Task AddCustomerBook(long customerId, CustomerBookDto book)
    {
        var query = @$"INSERT INTO customer_books
                    (customer_id, book_id) 
                    VALUES 
                    (@customerId, @bookId)";
        using var connection = _context.CreateConnection();
        var temp = new CustomerBook {BookId = book.BookId, CustomerId = customerId};
        await connection.ExecuteAsync(query, temp);
    }
 
    public async Task DeleteCustomerBook(long customerId, long bookId)
    {
        var query = @"DELETE FROM customer_books
                    WHERE customer_id = @customerId
                    AND book_id = @bookId";
        using var connection = _context.CreateConnection();
        var temp = new CustomerBook {BookId = bookId, CustomerId = customerId};
        await connection.ExecuteAsync(query, temp);
    }

    public async Task<IEnumerable<CustomerBookDto>> GetAllCustomerBooks(long customerId)
    {
        var query = @"SELECT * FROM customer_books
                    WHERE customer_id = @customerId";
        using var connection = _context.CreateConnection();
        var books = await connection.QueryAsync<CustomerBookDto>(query, new { customerId });
        return books.ToList();
    }

    public async Task<CustomerBookDto> GetCustomerBook(long customerId, long bookId)
    {
        var query = @"SELECT * FROM customer_books
                    WHERE customer_id = @customerId
                    AND book_id = @bookId";
        using var connection = _context.CreateConnection();
        var temp = new CustomerBook {BookId = bookId, CustomerId = customerId};
        var book = await connection.QueryFirstOrDefaultAsync<CustomerBookDto>(query, temp);
        return book;
    }
}