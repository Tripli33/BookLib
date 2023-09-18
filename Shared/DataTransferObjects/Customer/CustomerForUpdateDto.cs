namespace Shared.DataTransferObjects.Customer;

public class CustomerForUpdateDto : CustomerForManipulationDto
{
    public override CustomerDto ConvertCustomerForManipulationDtoToCustomerDto(long id)
    {
        CustomerDto customer = new()
        {
            CustomerId = id, FirstName = this.FirstName, LastName = this.LastName,
            Email = this.Email, Address = this.Address, ContactNumber = this.ContactNumber,
            ModifiedDate = DateTime.Now
        };
        return customer;
    }
}