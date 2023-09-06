namespace Shared.DataTransferObjects;

public class CustomerDto : CustomerForManipulationDto
{
    public long CustomerId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}