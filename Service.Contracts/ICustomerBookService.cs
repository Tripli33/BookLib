using Shared.DataTransferObjects.Book;
using Shared.DataTransferObjects.CustomerBook;

namespace Service.Contracts;

public interface ICustomerBookService
{
    Task<IEnumerable<ExtendBookDto>> GetAllCustomerBooks(long customerId);
    Task<ExtendBookDto> GetCustomerBook(long customerId, long bookId);
    Task AddCustomerBook(long customerId, CustomerBookDto book);
    Task DeleteCustomerBook(long customerId, long bookId);
}