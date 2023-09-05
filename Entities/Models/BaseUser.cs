namespace Entities.Models;

public class BaseUser
{
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public BaseUser()
    {
        CreatedDate = DateTime.Now;
    }

}