using Entities.Models;
using Shared.DataTransferObjects;

namespace Contracts;

public interface IPublisherRepository
{
    Task<IEnumerable<Publisher>> GetAllPublishers();
    Task<Publisher> GetPublisher(long id);
    Task<Publisher> GetPublisher(string publisherName);
    Task AddPublisher(PublisherForAddDto publisher);
    Task DeletePublisher(long id);
    Task UpdatePublisher(long id, PublisherForUpdateDto publisher);
    
}