using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class CustomerService : ICustomerService
{
    private readonly IRepositoryManager _repositoryManager;
    public CustomerService (IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task AddCustomer(CustomerForAddDto customer)
    {
        await _repositoryManager.Customer.AddCustomer(customer);
    }

    public async Task DeleteCustomer(long id)
    {
        if (!await _repositoryManager.Customer.CustomerExists(id))
        throw new CustomerNotFoundException(id);
        await _repositoryManager.Customer.DeleteCustomer(id);
    }

    public Task<IEnumerable<CustomerDto>> GetAllCustomers()
    {
        return _repositoryManager.Customer.GetAllCustomers();
    }

    public async Task<CustomerDto> GetCustomer(long id)
    {
        var customer = await _repositoryManager.Customer.GetCustomer(id);
        return customer ?? throw new CustomerNotFoundException(id);
    }

    public async Task UpdateCustomer(long id, CustomerForUpdateDto customer)
    {
        if (!await _repositoryManager.Customer.CustomerExists(id))
        throw new CustomerNotFoundException(id);
        await _repositoryManager.Customer.UpdateCustomer(id, customer);
    }
}