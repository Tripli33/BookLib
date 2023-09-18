using Shared.DataTransferObjects.Customer;

namespace Contracts;

public interface ICustomerRepository
{
    Task<IEnumerable<CustomerDto>> GetAllCustomers();
    Task<CustomerDto> GetCustomer(long id);
    void AddCustomer(CustomerForAddDto customer);
    void DeleteCustomer(long id);
    void UpdateCustomer(long id, CustomerForUpdateDto customer);
    Task<bool> CustomerExists(long id);
}