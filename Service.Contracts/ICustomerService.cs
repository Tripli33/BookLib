using Shared.DataTransferObjects;
using Shared.DataTransferObjects.Customer;

namespace Service.Contracts;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllCustomers();
    Task<CustomerDto> GetCustomer(long id);
    void AddCustomer(CustomerForAddDto customer);
    Task DeleteCustomer(long id);
    Task UpdateCustomer(long id, CustomerForUpdateDto customer);
}