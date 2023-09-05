namespace Entities.Models;

public class Customer : BaseUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = String.Empty;
    public string Address { get; set; } = string.Empty;
    ICollection<CustomerBook> CustomerBooks { get; set; } = new List<CustomerBook>();
}