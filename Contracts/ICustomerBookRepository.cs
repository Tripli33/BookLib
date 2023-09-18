using Entities.Models;
using Shared.DataTransferObjects.Book;
using Shared.DataTransferObjects.CustomerBook;

namespace Contracts;

public interface ICustomerBookRepository
{
    Task<IEnumerable<ExtendBookDto>> GetAllCustomerBooks(long customerId);
    Task<ExtendBookDto> GetCustomerBook(long customerId, long bookId);
    void AddCustomerBook(long customerId, CustomerBookDto book);
    void DeleteCustomerBook(long customerId, long bookId);
    Task<bool> CustomerBookExists(long customerId, long bookId);
}