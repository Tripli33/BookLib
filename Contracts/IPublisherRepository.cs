using Entities.Models;
using Shared.DataTransferObjects;

namespace Contracts;

public interface IPublisherRepository
{
    Task<IEnumerable<PublisherDto>> GetAllPublishers();
    Task<PublisherDto> GetPublisher(long id);
    Task<PublisherDto> GetPublisher(string publisherName);
    Task AddPublisher(PublisherForAddDto publisher);
    Task DeletePublisher(long id);
    Task UpdatePublisher(long id, PublisherForUpdateDto publisher);
    Task<bool> PublisherExists(long id);
    Task<bool> PublisherExists(string publisherName);
}