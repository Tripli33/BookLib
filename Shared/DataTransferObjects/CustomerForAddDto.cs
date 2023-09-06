namespace Shared.DataTransferObjects;

public class CustomerForAddDto : CustomerForManipulationDto
{
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}