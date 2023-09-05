using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IPublisherService
{
    Task<IEnumerable<PublisherDto>> GetAllPublishers();
    Task<PublisherDto> GetPublisher(long id);
    Task<PublisherDto> GetPublisher(string publisherName);
    Task AddPublisher(PublisherForAddDto publisher);
    Task DeletePublisher(long id);
    Task UpdatePublisher(long id, PublisherForUpdateDto publisher);
}