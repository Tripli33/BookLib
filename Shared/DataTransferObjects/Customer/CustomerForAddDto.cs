namespace Shared.DataTransferObjects.Customer;

public class CustomerForAddDto : CustomerForManipulationDto
{
    public DateTime CreatedDate { get; init; } = DateTime.Now;
    public DateTime ModifiedDate { get; init; } = DateTime.Now;
    public override CustomerDto ConvertCustomerForManipulationDtoToCustomerDto(long id)
    {
        CustomerDto customer = new()
        {
            CustomerId = id, FirstName = this.FirstName, LastName = this.LastName,
            Email = this.Email, Address = this.Address, ContactNumber = this.ContactNumber,
            ModifiedDate = this.ModifiedDate, CreatedDate = this.CreatedDate
        };
        return customer;
    }
}