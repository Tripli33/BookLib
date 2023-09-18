using Shared.DataTransferObjects.Publisher;

namespace Contracts;

public interface IPublisherRepository
{
    Task<IEnumerable<PublisherDto>> GetAllPublishers();
    Task<PublisherDto> GetPublisher(long id);
    Task<PublisherDto> GetPublisher(string publisherName);
    void AddPublisher(PublisherForAddDto publisher);
    void DeletePublisher(long id);
    void UpdatePublisher(long id, PublisherForUpdateDto publisher);
    Task<bool> PublisherExists(long id);
    Task<bool> PublisherExists(string publisherName);
}