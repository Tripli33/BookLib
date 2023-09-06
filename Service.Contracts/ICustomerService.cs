using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllCustomers();
    Task<CustomerDto> GetCustomer(long id);
    Task AddCustomer(CustomerForAddDto customer);
    Task DeleteCustomer(long id);
    Task UpdateCustomer(long id, CustomerForUpdateDto customer);
}