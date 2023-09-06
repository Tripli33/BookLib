using Shared.DataTransferObjects;

namespace Contracts;

public interface ICustomerRepository
{
    Task<IEnumerable<CustomerDto>> GetAllCustomers();
    Task<CustomerDto> GetCustomer(long id);
    Task AddCustomer(CustomerForAddDto customer);
    Task DeleteCustomer(long id);
    Task UpdateCustomer(long id, CustomerForUpdateDto customer);
    Task<bool> CustomerExists(long id);
}