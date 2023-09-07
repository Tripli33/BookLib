using Entities.Models;
using Shared.DataTransferObjects;

namespace Contracts;

public interface ICustomerBookRepository
{
    Task<IEnumerable<CustomerBookDto>> GetAllCustomerBooks(long customerId);
    Task<CustomerBookDto> GetCustomerBook(long customerId, long bookId);
    Task AddCustomerBook(long customerId, CustomerBookDto book);
    Task DeleteCustomerBook(long customerId, long bookId);
}