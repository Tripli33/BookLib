using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class PublisherService : IPublisherService
{
    private readonly IRepositoryManager _repositoryManager;
    public PublisherService (IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task AddPublisher(PublisherForAddDto publisher)
    {
        await _repositoryManager.Publisher.AddPublisher(publisher);
    }

    public async Task DeletePublisher(long id)
    {
        if (!await _repositoryManager.Publisher.PublisherExists(id))
        throw new PublisherNotFoundException(id);
        await _repositoryManager.Publisher.DeletePublisher(id);
    }

    public async Task<IEnumerable<PublisherDto>> GetAllPublishers()
    {
        return await _repositoryManager.Publisher.GetAllPublishers();
    }

    public async Task<PublisherDto> GetPublisher(long id)
    {
        var publisher = await _repositoryManager.Publisher.GetPublisher(id);
        return publisher ?? throw new PublisherNotFoundException(id);
    }

    public async Task<PublisherDto> GetPublisher(string publisherName)
    {
        var publisher = await _repositoryManager.Publisher.GetPublisher(publisherName);
        return publisher ?? throw new PublisherNotFoundException(publisherName);
    }

    public async Task UpdatePublisher(long id, PublisherForUpdateDto publisher)
    {
        if (!await _repositoryManager.Publisher.PublisherExists(id))
        throw new PublisherNotFoundException(id);
        await _repositoryManager.Publisher.UpdatePublisher(id, publisher);
    }
}