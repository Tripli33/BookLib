using Contracts;
using Dapper;
using Shared.DataTransferObjects.Customer;

namespace Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly RepositoryContext _context;

    public CustomerRepository(RepositoryContext context)
    {
        _context = context;
    }

    public void AddCustomer(CustomerForAddDto customer)
    {
        var query = @$"INSERT INTO customers
                    (first_name, last_name, email, contact_number, 
                    address, modified_date, created_date) 
                    VALUES 
                    (@FirstName, @LastName, @Email, @ContactNumber, 
                    @Address, @ModifiedDate, @CreatedDate)";
        using var connection = _context.CreateConnection();
        connection.ExecuteAsync(query, customer);
    }

    public async Task<bool> CustomerExists(long id)
    {
        return await GetCustomer(id) is not null;
    }

    public void DeleteCustomer(long id)
    {
        var query = @"DELETE FROM customers
                    WHERE customer_id = @id";
        using var connection = _context.CreateConnection();
        connection.ExecuteAsync(query, new { id });
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
    {
        var query = "SELECT * FROM customers";
        using var connection = _context.CreateConnection();
        var customers = await connection.QueryAsync<CustomerDto>(query);
        return customers.ToList();
    }

    public async Task<CustomerDto> GetCustomer(long id)
    {
        var query = @"SELECT * FROM customers
                    WHERE customer_id = @id";
        using var connection = _context.CreateConnection();
        var customers = await connection.QueryFirstOrDefaultAsync<CustomerDto>(query, new { id });
        return customers;
    }

    public void UpdateCustomer(long id, CustomerForUpdateDto customer)
    {
        var query = @$"UPDATE customers SET
                    first_name = @FirstName, last_name = @LastName,
                    email = @Email, contact_number = @ContactNumber,
                    address = @Address, modified_date = @ModifiedDate
                    WHERE customer_id = @CustomerId";
        using var connection = _context.CreateConnection();
        var temp = customer.ConvertCustomerForManipulationDtoToCustomerDto(id);
        connection.ExecuteAsync(query, temp);
    }
}