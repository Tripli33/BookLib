using Entities.Models;

namespace Shared.DataTransferObjects;

public class CustomerForUpdateDto : CustomerForManipulationDto
{
    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    public Customer ConvertCustomerForUpdateDtoToCustomer(long id)
    {
        var customer = new Customer()
        {
            CustomerId = id, FirstName = this.FirstName,
            LastName = this.LastName, Email = this.Email,
            ContactNumber = this.ContactNumber, Address = this.ContactNumber,
            ModifiedDate = this.ModifiedDate
        };
        return customer;
    }
}