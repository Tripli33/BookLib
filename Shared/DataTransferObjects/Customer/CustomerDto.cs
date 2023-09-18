namespace Shared.DataTransferObjects.Customer;

public class CustomerDto
{
    public long CustomerId { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string ContactNumber { get; init; } = String.Empty;
    public string Address { get; init; } = string.Empty;
    public DateTime CreatedDate { get; init; }
    public DateTime ModifiedDate { get; init; }
}